using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseModal : MonoBehaviour
{
    private const int _GAMESELECTION = 1;

    public delegate void ToggleModal();
    public static event ToggleModal _toggleModal;

    public void OnClick()
    {
        Scene lScene = SceneManager.GetSceneAt(1);
        _toggleModal?.Invoke();
        if (lScene.buildIndex > _GAMESELECTION)
        {
            LoadScene._instance.LoadSceneTransition(lScene.name, _GAMESELECTION);
            Time.timeScale = 1;
        }        
    }
}
