using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProfileButton : MonoBehaviour
{
    private const string _SHOWMODAL = "Show";
    private const string _HIDEMODAL = "Hide";

    private List<Sprite> _profileImages = new List<Sprite>();
    private const string _PROFILEPICTUREPATH = "Sprites/Profile Pictures/";
    private bool _isLoaded = false;
    private bool _isShowing = false;

    [SerializeField] private GameObject _profilePicturePrefab;
    [SerializeField] private GameObject _profilePictureHolder;
    [SerializeField] private Animator _modalAnimator;

    public delegate void Darken();
    public static event Darken _darken;

    private void OnEnable()
    {
        ActiveProfileManager._toggleProfilePictures += ToggleProfileModal;
    }
    /// <summary>
    /// Loads profile picture directory into a grid so the player can choose a new profile picture. 
    /// Once loaded the pictures are toggle on and off rather than loading them every time.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnClick()
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
            ToggleProfileModal();
            _isLoaded = true;
        }
        else
        {
            ToggleProfileModal();
        }
    }
    public void ToggleProfileModal()
    {
        if (_isShowing)
            _modalAnimator.SetTrigger(_HIDEMODAL);        
        else
            _modalAnimator.SetTrigger(_SHOWMODAL);                    
        _darken?.Invoke();
        _isShowing = !_isShowing;
    }

    private void OnDisable()
    {
        ActiveProfileManager._toggleProfilePictures -= ToggleProfileModal;
    }
}
