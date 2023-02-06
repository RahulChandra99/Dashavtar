using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject loadingScreen;

    private void Awake()
    {
        instance = this;

        SceneManager.LoadSceneAsync((int) SceneIndexes.MAIN_MENU, LoadSceneMode.Additive);
    }

    public void LoadGame()
    {
        loadingScreen.gameObject.SetActive(true);
        SceneManager.UnloadSceneAsync((int) SceneIndexes.MAIN_MENU);
        SceneManager.LoadSceneAsync((int) SceneIndexes.PARSHURAMLEVEL, LoadSceneMode.Additive);
        
    }
}
