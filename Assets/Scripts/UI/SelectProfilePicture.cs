using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectProfilePicture : MonoBehaviour, IPointerClickHandler
{
    public delegate void ChangeProfilePicture(string aProfilePicture);
    public static event ChangeProfilePicture _changeProfilePicture;
    public void OnPointerClick(PointerEventData eventData)
    {
        _changeProfilePicture?.Invoke(this.gameObject.GetComponent<UnityEngine.UI.Image>().sprite.name);
    }
}
