using UnityEngine.SceneManagement;

namespace managers {
    public static class SceneLoader {
        public enum Scenes {
            TitleScene,
            SelectionScene,
            LoadingScene,
            GameScene
        }

        public static Scenes nextScene;
        
        public static void LoadScene(Scenes scene) {
            nextScene = scene;
            SceneManager.LoadScene(Scenes.LoadingScene.ToString());
        }
        
        public static void LoadNextScene() {
            SceneManager.LoadScene(nextScene.ToString());
        }
    }
}