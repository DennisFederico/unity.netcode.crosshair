using UnityEngine;

namespace managers {
    public class SceneLoaderCallBack : MonoBehaviour {
        private bool _isFirstUpdate = true;
        private bool _loaded;

        private void FixedUpdate() {
            if (_isFirstUpdate && !_loaded) {
                _isFirstUpdate = false;
                return;
            }
            
            if (_loaded) return;
            
            _loaded = true;
            SceneLoader.LoadNextScene();
        }
    }
}