using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Threading.Tasks;

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
    [SerializeField] private GameObject _darkenBehindModal;
    [SerializeField] private Animator _darkenBehindModalAnimator;
    [SerializeField] private Animator _modalAnimator;

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
    public async void ToggleProfileModal()
    {
        if (_isShowing)
        {
            _modalAnimator.SetTrigger(_HIDEMODAL);
            _darkenBehindModalAnimator.SetTrigger(_HIDEMODAL);
            _isShowing = false;
            await Task.Delay(1000);
            _darkenBehindModal.SetActive(_isShowing);            
        }
        else
        {
            _modalAnimator.SetTrigger(_SHOWMODAL);            
            _isShowing = true;
            _darkenBehindModal.SetActive(_isShowing);
            _darkenBehindModalAnimator.SetTrigger(_SHOWMODAL);
        }
    }

    private void OnDisable()
    {
        ActiveProfileManager._toggleProfilePictures -= ToggleProfileModal;
    }
}
