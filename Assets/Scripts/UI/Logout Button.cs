using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoutButton : MonoBehaviour
{
    private const int _GAMESELECTION = 1;
    public delegate void ToggleModal();
    public static event ToggleModal _toggleModal;

    public ButtonManager _buttonManager;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += FindReferences;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= FindReferences;
    }
    public void OnClick()
    {
         _toggleModal?.Invoke();//hide modal
        if (_buttonManager.GetAcceptProfile()._isShowing)
        {
            _buttonManager.HideCreateProfile();
        }else if (_buttonManager.GetGameSelection()._isShowing)
        {
            _buttonManager.HideGameSelection();
        }else if (_buttonManager.GetDifficultySelectionGroup()._isShowing)
        {
            _buttonManager.HideDifficultySelection();
        }
        _buttonManager.HideActiveProfilePanel();
        _buttonManager.HideBackButton();
        _buttonManager.ShowProfilePanel();
    }
    private void FindReferences(Scene aScene, LoadSceneMode aMode)
    {
        if (aScene.buildIndex == _GAMESELECTION)
            _buttonManager = GameObject.Find("Button Manager").
                GetComponent<ButtonManager>();
    }
}
