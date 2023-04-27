using System;
using UnityEngine;
//using Vobling.FireSimulator.Utilities;
namespace Vobling.FireSimulator.Scenarios
{
    public class RunRandomScenes : TrainingSelectorManager
    {
        private static SceneLoader _sceneLoader;
        void Start()
        {
            _sceneLoader = FindObjectOfType<SceneLoader>();
        }
        public void RunRandomScenarios()
        {
            // Select a random scenario
            randomIndex = UnityEngine.Random.Range(0, sceneNames.Count);
            if (sceneNames.Count > 0)
            {
                sceneToLoad = sceneNames[randomIndex];
            }
            // Load the selected scene
            if (sceneToLoad != null)
            {
                currentActiveScene = sceneToLoad;
                currentSceneIndex = randomIndex;

                _sceneLoader.OnSceneLoaded += IsRandomSceneLoaded;
                _sceneLoader.LoadScene(sceneToLoad);
            }
            CheckIfCourseDone();
        }
        private void IsRandomSceneLoaded(string sceneName)
        {
            if (sceneName == currentActiveScene)
            {
                // Remove the selected scenario from the list
                if (sceneNames.Count > 0)
                {
                    int randomIndex = sceneNames.FindIndex(name => name == sceneName);

                    if (randomIndex >= 0)
                    {
                        sceneNames.RemoveAt(randomIndex);
                    }
                }
            }
        }
    }
}