using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProfileButton : MonoBehaviour
{
    private List<Sprite> _profileImages = new List<Sprite>();
    private const string _PROFILEPICTUREPATH = "Sprites/Profile Pictures/";
    private bool _isLoaded = false;

    [SerializeField] private GameObject _profilePicturePrefab;
    [SerializeField] private GameObject _profilePictureHolder;
    [SerializeField] private Button _button;

    public delegate void ToggleModal(string aButtonName);
    public static event ToggleModal _toggleModal;

    /// <summary>
    /// Loads profile picture directory into a grid so the player can choose a new profile picture. 
    /// Once loaded the pictures are toggle on and off rather than loading them every time.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnClick()
    {
        Scene lScene = SceneManager.GetSceneAt(1);
        //button only works if on the game selection screen
        if (lScene.buildIndex == 1)
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
                _toggleModal?.Invoke(_button.name);
                _isLoaded = true;
            }
            else
            {
                _toggleModal?.Invoke(_button.name);
            }
        }        
    }
}
