using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Text;
using System.Threading;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Game.Scripts.Utils.Scene
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance { get; private set; }
        private Scenes currentScene;
        public Scenes CurrentScene => currentScene;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            DontDestroyOnLoad(gameObject);
        }

        public void LoadScene(Scenes scene) => LoadSceneAsync(scene, this.GetCancellationTokenOnDestroy()).Forget();

        private async UniTask LoadSceneAsync(Scenes scene, CancellationToken token)
        {
            if (currentScene != Scenes.LoadScene)
            {
                currentScene = Scenes.LoadScene;
                var loadSceneName = ScenesStorage.GetScene(currentScene);
                await SceneManager.LoadSceneAsync(loadSceneName).WithCancellation(token);
            }

            currentScene = scene;

            var sceneName = ScenesStorage.GetScene(currentScene);

            await SceneManager.LoadSceneAsync(sceneName).WithCancellation(token);
        }
    }
}
