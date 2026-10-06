using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Game.Scripts.Helpers
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance { get; private set; }
        private Coroutine loadCoroutine;
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

        public void LoadScene(Scenes scene)
        {
            if (loadCoroutine != null) return;

            currentScene = scene;

            if (currentScene != Scenes.LoadScene)
                LoadScene(Scenes.LoadScene);

            var sceneName = ScenesStorage.GetScene(scene);

            loadCoroutine = StartCoroutine(LoadCoroutineAsync(sceneName));
        }

        private IEnumerator LoadCoroutineAsync(string sceneName)
        {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName);

            while (!loadOperation.isDone)
            {
                yield return null;
            }
        }
    }
}
