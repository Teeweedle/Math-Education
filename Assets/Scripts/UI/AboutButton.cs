using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AboutButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    public delegate void ToggleModal(string aButtonName);
    public static event ToggleModal _toggleModal;
    public void OnClick()
    {
        _toggleModal?.Invoke(_button.name);
    }
}
