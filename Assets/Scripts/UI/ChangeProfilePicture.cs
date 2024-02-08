using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ChangeProfilePicture : MonoBehaviour, IPointerClickHandler
{
    private List<Sprite> _profileImages = new List<Sprite>();
    private const string _PROFILEPICTUREPATH = "Sprites/Profile Pictures/";
    private bool _isLoaded = false;
    private bool _isShowing = false;

    [SerializeField] private GameObject _profilePicturePrefab;
    [SerializeField] private GameObject _profilePictureHolder;

    /// <summary>
    /// Loads profile picture directory into a grid so the player can choose a new profile picture. 
    /// Once loaded the pictures are toggle on and off rather than loading them every time.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_isLoaded)
        {
            _profileImages = Resources.LoadAll<Sprite>(_PROFILEPICTUREPATH).ToList();
            GameObject lTempGO;
            foreach (Sprite aSprite in _profileImages)
            {
                lTempGO = Instantiate(_profilePicturePrefab, _profilePictureHolder.transform);
                lTempGO.GetComponent<UnityEngine.UI.Image>().sprite = aSprite;
            }
            _isLoaded = true;
            _isShowing = true;
        }
        else if (!_isShowing)
            ShowPictures();
        else
            HidePictures();
    }

    private void HidePictures()
    {
        _profilePictureHolder?.SetActive(false);
        _isShowing = false;
    }

    private void ShowPictures()
    {
        _profilePictureHolder?.SetActive(true);
        _isShowing = true;
    }
}
