using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseModal : MonoBehaviour
{
    public delegate void Darken();
    public static event Darken _darken;

    public delegate void ToggleModal();
    public static event ToggleModal _toggleModal;

    public void OnClick()
    {
        _darken?.Invoke();
        _toggleModal?.Invoke();
    }
}
