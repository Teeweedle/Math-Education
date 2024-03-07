using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AboutButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    public delegate void ToggleModal(string aButtonName);
    public static event ToggleModal _toggleModal;
    public void OnClick()
    {
        Scene lScene = SceneManager.GetSceneAt(1);
        //button only works if on the game selection screen
        if (lScene.buildIndex == 1)
        {
            _toggleModal?.Invoke(_button.name);
        }        
    }
}
