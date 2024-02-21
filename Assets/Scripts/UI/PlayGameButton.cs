using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameButton : ButtonManager
{
    private const string _PROFILE = "Profile";
    private const int _STARTMENU = 0;
    private const int _GAMESELECTION = 1;

    [Header("Play Button")]
    public bool _isShowing = true;

    public delegate void PlayAgain();
    public static event PlayAgain _playAgain;

    private void Start()
    {
        //checks for last played profile, if it exists loads next scene
        if (PlayerPrefs.HasKey(_PROFILE)){
            //load game selection
            SceneManager.UnloadSceneAsync(_STARTMENU);
            SceneManager.LoadScene(_GAMESELECTION, LoadSceneMode.Additive);
        }
    }    
    //plays animation to hide Play Game button
    public void PlayGame()
    {
        _playAgain?.Invoke();
        //HidePlayButton();
        //ShowProfilePanel();
    }    
}
