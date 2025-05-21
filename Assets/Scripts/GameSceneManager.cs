using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    const string gameScene = "Game";
    public static GameSceneManager instance;

    public UnityEvent OnBeginSceneLoad = new UnityEvent();
    public UnityEvent OnEndSceneLoad = new UnityEvent();

    private void Awake()
    {
        instance = this;
    }



    public void SwitchScene(string scene)
    {
        OnBeginSceneLoad.Invoke();
        StartCoroutine(SwitchSceneRoutine(scene));
    }

    List<Scene> scenesToUnload = new List<Scene>();
    IEnumerator SwitchSceneRoutine(string sceneName)
    {
        // Make list of scenes that are supposed to be unloaded.
        scenesToUnload ??= new List<Scene>(2);
        scenesToUnload.Clear();
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);

            if (scene.name != gameScene)
            {
                scenesToUnload.Add(scene);
            }
        }

        // Unload all non-game scenes.
        foreach (Scene scene in scenesToUnload)
        {
            yield return SceneManager.UnloadSceneAsync(scene);
        }

        // Load new scene.
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        OnEndSceneLoad.Invoke();
    }

    // Runs when Unity or the play-mode is loaded. Ensures that the game scene is loaded.
    [RuntimeInitializeOnLoadMethod]
    static void LoadGameScene()
    {
        if(!SceneManager.GetSceneByName(gameScene).IsValid())
        {
            SceneManager.LoadScene(gameScene, LoadSceneMode.Additive);
        }
    }
}
