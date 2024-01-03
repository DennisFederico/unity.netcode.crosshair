using System;
using managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class TitleMenu : MonoBehaviour {
        [SerializeField] private Button startGameButton;
        [SerializeField] private Button quitGameButton;

        private void Awake() {
            startGameButton.onClick.AddListener(StartGame);
            quitGameButton.onClick.AddListener(QuitGame);
        }

        private void StartGame() {
            SceneLoader.LoadScene(SceneLoader.Scenes.GameScene);
        }
        
        private void QuitGame() {
            Application.Quit();
        }
    }
}