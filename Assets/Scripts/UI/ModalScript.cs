using System;
using TMPro;
using UnityEngine;

public class ModalScript : MonoBehaviour
{
    private const string _SHOWMODAL = "Show";
    private const string _HIDEMODAL = "Hide";

    [SerializeField] private Animator _modalAnimator;
    [SerializeField] private Sprite _completed, _profile;
    [Header("Modal Options")]
    [SerializeField] private UnityEngine.UI.Image _modalTitle;
    [SerializeField] private TextMeshProUGUI _mathProblem;
    [SerializeField] private TextMeshProUGUI _answer;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _textOutput;
    [SerializeField] private UnityEngine.UI.Image _finishImage;
    [SerializeField] private UnityEngine.UI.Image _scoreContainer;
    [SerializeField] private GameObject _profilePictureHolder;
    [SerializeField] private GameObject _playAgainButton, _backButton;

    public delegate void Darken();
    public static event Darken _darken;

    private bool _isShowing;

    private void Start()
    {
        _isShowing = false;
    }
    private void OnEnable()
    {
        ProfileButton._toggleModal += ToggleModal;
        GameFinishPopup._modal += ToggleModal;
        BackButton._quitGame += ToggleModal;
        PlayAgainButton._playAgain += ToggleModal;
        ActiveProfileManager._toggleProfilePictures += ToggleModal;
    }
    private void OnDisable()
    {
        ProfileButton._toggleModal -= ToggleModal;
        GameFinishPopup._modal -= ToggleModal;
        BackButton._quitGame -= ToggleModal;
        PlayAgainButton._playAgain -= ToggleModal;
        ActiveProfileManager._toggleProfilePictures -= ToggleModal;
    }
    /// <summary>
    /// Overload for profil modal
    /// </summary>
    private void ToggleModal()
    {
        if(!_isShowing)
        {
            _modalTitle.sprite = _profile;
            _textOutput.gameObject.SetActive(false);
            _mathProblem.gameObject.SetActive(false);
            _answer.gameObject.SetActive(false);
            _finishImage.gameObject.SetActive(false);
            _scoreContainer.gameObject.SetActive(false);
            _profilePictureHolder.SetActive(true);
            _playAgainButton.SetActive(false);
            _backButton.SetActive(false);
        }

        AnimateModal();
    }
    /// <summary>
    /// Overload for game finish modal
    /// </summary>
    /// <param name="aMathProblem"></param>
    /// <param name="aScore"></param>
    /// <param name="aAnswer"></param>
    private void ToggleModal(string aTextOutput, string aMathProblem, int aScore, int aAnswer)
    { 
        if(!_isShowing)
        {
            _modalTitle.sprite = _completed;
            _textOutput.gameObject.SetActive(true);
            _mathProblem.gameObject.SetActive(true);
            _answer.gameObject.SetActive(true);
            _finishImage.gameObject.SetActive(true);
            _scoreContainer.gameObject.SetActive(true);
            _profilePictureHolder.SetActive(false);
            _playAgainButton.SetActive(true);
            _backButton.SetActive(true);

            _textOutput.text = aTextOutput;
            _mathProblem.text = aMathProblem;
            _scoreText.text = aScore.ToString();
            _answer.text = aAnswer.ToString();
        }

        AnimateModal();
    }
    private void AnimateModal()
    {
        if (_isShowing)
            _modalAnimator.SetTrigger(_HIDEMODAL);
        else
            _modalAnimator.SetTrigger(_SHOWMODAL);

        _darken?.Invoke();
        _isShowing = !_isShowing;
    }
}
