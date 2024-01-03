using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using Random = UnityEngine.Random;


public class Spawner : NetworkBehaviour {
    public static Spawner Instance { get; private set; }
    //TODO ScriptableObjects in case we need and index reference?
    [SerializeField] List<Transform> prefabs;

    private static readonly (float minTime, float maxTime) SpawnRate = (2f, 4f);
    private float _spawnTimer;

    private void Awake() {
        if (Instance != null) {
            Debug.LogError($"There's more than one Spawner in the scene! {transform} - {Instance}");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Update() {
        if (!IsServer) return;
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer < 0) {
            _spawnTimer = Random.Range(SpawnRate.minTime, SpawnRate.maxTime);
            SpawnRandomObject();
        }
    }
    
    //Called from clients for testing
    [ServerRpc(RequireOwnership = false)]
    public void SpawnRandomObjectServerRpc() {
        SpawnRandomObject();
    }

    private void SpawnRandomObject() {
        var prefab = prefabs[Random.Range(0, prefabs.Count)];
        var spawn = Instantiate(prefab, RandomPosition.GetRandomPosition(), Random.rotation);
        spawn.GetComponent<NetworkObject>().Spawn();
    }
}