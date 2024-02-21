using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseModal : MonoBehaviour
{
    public delegate void ToggleModal();
    public static event ToggleModal _toggleModal;

    public void OnClick()
    {
        _toggleModal?.Invoke();
    }
}
