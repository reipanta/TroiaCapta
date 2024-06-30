using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class SceneLoader
    {
        public static void LoadScene(string sceneName, Action onLoaded = null)
        {
            // Loading scene asynchronously since scenes might be quite big
            // and can make game unresponsive for the loading time
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(sceneName);
            
            // This event is triggered when loading is complete
            waitNextScene.completed += _ => onLoaded?.Invoke();
        }
    }
}