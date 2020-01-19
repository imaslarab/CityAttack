using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    private string sceneNameToLoad;

    public void LoadScene(string _sceneName) {
        sceneNameToLoad = _sceneName;
        StartCoroutine(InitializeSceneLoading());

    }

    IEnumerator InitializeSceneLoading() {
        yield return SceneManager.LoadSceneAsync("Scene_Loading");
        //load the target
        StartCoroutine(LoadTargetScene());
        
    }

    IEnumerator LoadTargetScene() {
        var loading = SceneManager.LoadSceneAsync(sceneNameToLoad);
        loading.allowSceneActivation = false;

        print("loading progress=" + loading.progress);
        while (!loading.isDone) {
            if (loading.progress >= 0.9f) {
                loading.allowSceneActivation = true;
            }
            yield return null;
        }
    }

}
