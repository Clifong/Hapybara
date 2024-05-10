using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public static class LevelChanger{
    private static string previousLevel;
    private static CrossObjectEvent startLoading;
    private static CrossObjectEvent loadingComplete;

    public static void LoadLevel(MonoBehaviour mono, string name){
    //   if (loadingComplete == null && startLoading == null) {
    //     startLoading = (CrossObjectEvent)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(AssetDatabase.FindAssets("Start loading")[0]), typeof(CrossObjectEvent));
    //     loadingComplete = (CrossObjectEvent)AssetDatabase.LoadAssetAtPath(AssetDatabase.FindAssets("Finish loading")[0], typeof(CrossObjectEvent));
    //   }
    //   if (name != "Lose") {
    //     previousLevel = SceneManager.GetActiveScene().name;
    //   }
      mono.StartCoroutine(LevelChanger.LoadScene(name));
    }

    public static string GetCurrentLevel() {
      return SceneManager.GetActiveScene().name;
    }

    private static IEnumerator LoadScene(string name){
        // startLoading.TriggerEvent();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);

        while (!asyncLoad.isDone){
            yield return null;
        }

        // if (loadingComplete != null) {
        //   loadingComplete.TriggerEvent();
        // }

        // DataPersistenceManager.dataPersistenceManager.LoadGame();
    }

    public static void Retry(MonoBehaviour mono) {
        Debug.Log(previousLevel);
        mono.StartCoroutine(LevelChanger.LoadScene(previousLevel));
    }
}
