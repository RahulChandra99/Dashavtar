using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Image Bg_img;
    public Image Title_img;
    public Image play_img;
    public Image options_img;
    public Image credits_img;

    [Header("Game Panels")] 
    public GameObject MainMenu;
    public GameObject Settings;
    public GameObject Credits;
    public GameObject GameMode;
    public GameObject PlayerMode;
    
    
    
    
    
    void Start () {
        
        LeanTween.alpha (Title_img.rectTransform, 0f, 0f).setEase (LeanTweenType.linear).setOnComplete(FadeInTitle);
        
        LeanTween.alpha (Bg_img.rectTransform, 0f, 0f).setEase (LeanTweenType.linear);
        LeanTween.alpha (play_img.rectTransform, 0f, 0f).setEase (LeanTweenType.linear);
        LeanTween.alpha (options_img.rectTransform, 0f, 0f).setEase (LeanTweenType.linear);
        LeanTween.alpha (credits_img.rectTransform, 0f, 0f).setEase (LeanTweenType.linear);
        
      /* MainMenu.SetActive(true);
       Settings.SetActive(false);
       Credits.SetActive(false);
       GameMode.SetActive(false);
       PlayerMode.SetActive(false);*/

       LeanTween.moveLocalX(Credits, -2385f, 1f);
       LeanTween.moveLocalY(GameMode, -1234, 1f);
       LeanTween.moveLocalX(Settings, 2393, 1f);
       LeanTween.moveLocalY(PlayerMode, 1275, 1f);

    }

    void FadeInTitle()
    {
        LeanTween.alpha (Title_img.rectTransform, 1f, 2f).setEase (LeanTweenType.linear).setOnComplete(FadeInBG);
    }
    
    void FadeInBG()
    {
        LeanTween.alpha(Bg_img.rectTransform, 1f, 2f).setEase(LeanTweenType.linear).setOnComplete(FadeInOthers);
    }

    void FadeInOthers()
    {

        PlayBtn_BounceUp();
        LeanTween.alpha (play_img.rectTransform, 1f, 2f).setEase (LeanTweenType.linear);
        LeanTween.alpha (options_img.rectTransform, 1f, 2f).setEase (LeanTweenType.linear);
        LeanTween.alpha (credits_img.rectTransform, 1f, 2f).setEase (LeanTweenType.linear);
    }

    void PlayBtn_BounceUp()
    {
        LeanTween.moveLocalY(play_img.gameObject, -152, 1f).setOnComplete(PlayBtn_BounceDown);
    }
    
    void PlayBtn_BounceDown()
    {
        LeanTween.moveLocalY(play_img.gameObject, -188, 1f).setOnComplete(PlayBtn_BounceUp);
    }

    public void TapToStart_btn()
    {
        LeanTween.moveLocalY(MainMenu,  -1234, 2f);
        LeanTween.moveLocalY(GameMode, 0, 2f);
        
        LeanTween.alpha (MainMenu.gameObject.GetComponent<RectTransform>(), 0f, 0.5f).setEase (LeanTweenType.linear);
        LeanTween.alpha (GameMode.gameObject.GetComponent<RectTransform>(), 1f, 0.5f).setEase (LeanTweenType.linear);
    }
    
    public void BackBtn_FromGameMode()
    {
        
        LeanTween.moveLocalY(GameMode,  -1234, 2f);
        LeanTween.moveLocalY(MainMenu, 0, 2f);
        
        LeanTween.alpha (MainMenu.gameObject.GetComponent<RectTransform>(), 1f, 0.5f).setEase (LeanTweenType.linear);
        LeanTween.alpha (GameMode.gameObject.GetComponent<RectTransform>(), 0f, 0.5f).setEase (LeanTweenType.linear);
    }

    public void Credits_btn()
    {
        LeanTween.moveLocalX(MainMenu,  -2385f, 2f);
        LeanTween.moveLocalX(Credits, 0, 2f);
        
        LeanTween.alpha (MainMenu.gameObject.GetComponent<RectTransform>(), 0f, 0.5f).setEase (LeanTweenType.linear);
        LeanTween.alpha (Credits.gameObject.GetComponent<RectTransform>(), 1f, 0.5f).setEase (LeanTweenType.linear);
    }
    
    public void BackBtn_FromCredits()
    {
        
        LeanTween.moveLocalX(Credits,  -2385f, 2f);
        LeanTween.moveLocalX(MainMenu, 0, 2f);
        
        LeanTween.alpha (MainMenu.gameObject.GetComponent<RectTransform>(), 1f, 0.5f).setEase (LeanTweenType.linear);
        LeanTween.alpha (Credits.gameObject.GetComponent<RectTransform>(), 0f, 0.5f).setEase (LeanTweenType.linear);
    }
    
    public void Settings_btn()
    {
        LeanTween.moveLocalX(MainMenu,  2395, 2f);
        LeanTween.moveLocalX(Settings, 0, 2f);
        
        LeanTween.alpha (MainMenu.gameObject.GetComponent<RectTransform>(), 0f, 0.5f).setEase (LeanTweenType.linear);
        LeanTween.alpha (Settings.gameObject.GetComponent<RectTransform>(), 1f, 0.5f).setEase (LeanTweenType.linear);
    }

    
    public void BackBtn_FromSettings()
    {
        
        LeanTween.moveLocalX(Settings,  2395, 2f);
        LeanTween.moveLocalX(MainMenu, 0, 2f);
        
        LeanTween.alpha (MainMenu.gameObject.GetComponent<RectTransform>(), 1f, 0.5f).setEase (LeanTweenType.linear);
        LeanTween.alpha (Settings.gameObject.GetComponent<RectTransform>(), 0f, 0.5f).setEase (LeanTweenType.linear);
    }

    public void Adventure_btn()
    {
        GameManager.instance.LoadGame();
    }

    
}
