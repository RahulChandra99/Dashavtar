using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PLManager : MonoBehaviour
{
    public bool isGameStarted = false;
    
    public GameObject GameUI;
    public GameObject CutSceneUI;
    public VideoPlayer vid;

    public AudioSource forestBGSound;

    void Start()
    {
        isGameStarted = false;
        vid.loopPointReached += CheckOver;
        GameUI.SetActive(false);
        
        
    }
 
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        isGameStarted = true;
        print  ("Video Is Over");
        
       GameUI.SetActive(true); 
       CutSceneUI.SetActive(false);
       forestBGSound.Play();
    }

    public void SkipCutScene()
    {
        isGameStarted = true;
        GameUI.SetActive(true); 
        CutSceneUI.SetActive(false);
        forestBGSound.Play();
    }

    public void ReplayBtn()
    {
        SceneManager.LoadSceneAsync("ParshuramLevel 1");
        
    }

    public void ExitBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
