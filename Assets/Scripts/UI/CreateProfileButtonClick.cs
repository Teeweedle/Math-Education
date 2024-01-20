using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateProfileButtonClick : ButtonManager
{
    private static readonly string _DEFAULTTEXT = "Create Profile";
    private static readonly string _STARTGAMESCENE = "Start Game";
    private const int _STARTGAMESCENEINDEX = 0;
    private const int _GAMESELECTIONSCENEINDEX = 1;

    [Header("Create Profile")]
    [SerializeField] private TextMeshProUGUI _thisText;

    public delegate void Login();
    public static event Login _login;

    public void ProfileLogin()
    {
        _login?.Invoke();
    }

    /// <summary>
    /// Gives the option to create a new profile or select an existing one based on the text of the button when clicked.
    /// </summary>
    public void CreateProfile()
    {
        if (_thisText.text == _DEFAULTTEXT)
        {
            //if you are creating a new profile, turn off profile name list
            //then turn on create new profile
            ShowCreateProfile();
            HideProfilePanel();            
        }
        else//you clicked a button with a profile name
        {
            PlayerProfile.LoadProfile(_thisText.text);
            PlayerPrefs.SetString("Profile", _thisText.text);            

            if (SceneManager.GetSceneAt(1).buildIndex == _STARTGAMESCENEINDEX) 
            {
                LoadScene._instance.LoadSceneTransition(_STARTGAMESCENE, _GAMESELECTIONSCENEINDEX);
            }
            else
            {
                ProfileLogin();
                HideProfilePanel();
                ShowGameSelection();
            }
        }        
    }

}
