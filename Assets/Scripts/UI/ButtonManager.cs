using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [Header("Button Manager")]
    [SerializeField] protected PlayGameButton _playButton;
    [SerializeField] protected ProfilePanel _profilePanel;
    [SerializeField] protected AcceptProfileNameClick _acceptProfile;
    [SerializeField] protected GameSelection _gameSelection;
    [SerializeField] protected DifficultySelectionGroup _difficultySelectionGroup;
    [SerializeField] private Button _mermaidButton;
    [SerializeField] private Button _pirateButton;

    [Header("Button Manager - Animators")]
    [SerializeField] protected Animator _playAnimator;    
    [SerializeField] protected Animator _profilePanelAnimator;    
    [SerializeField] protected Animator _acceptProfileAnimator;
    [SerializeField] protected Animator _gameSelectionAnimator;
    [SerializeField] protected Animator _difficultySelectionAnimator;


    private void OnEnable()
    {
        PrefabSelection._onPrefabSelected += ChangeSelection;
    }
    private void OnDisable()
    {
        PrefabSelection._onPrefabSelected -= ChangeSelection;
    }    
    private void ChangeSelection(string aName)
    {
        //if (aName.Equals("Mermaids"))
        //{
        //    EventSystem.current.SetSelectedGameObject(_mermaidButton.gameObject);
        //}
        //else
        //{
        //    EventSystem.current.SetSelectedGameObject(_pirateButton.gameObject); 
        //}
    }
    public void ShowDifficultySelection()
    {
        _difficultySelectionAnimator.SetTrigger("Show Difficulty");
        _difficultySelectionGroup._isShowing = true;
    }
    public void HideDifficultySelection()
    {
        _difficultySelectionAnimator.SetTrigger("Hide Difficulty");
        _difficultySelectionGroup._isShowing = false;
    }
    public void ShowGameSelection()
    {
        _gameSelectionAnimator.SetTrigger("Game Selection Show");
        _gameSelection._isShowing = true;
    }
    public void HideGameSelection()
    {
        _gameSelectionAnimator.SetTrigger("Game Selection Hide");
        _gameSelection._isShowing = false;
    }
    public void ShowPlayButton()
    {
        _playAnimator.SetTrigger("Back to Start");
        _playButton._isShowing = true;
    }
    public void HidePlayButton()
    {
        _playAnimator.SetTrigger("Play Button Clicked");
        _playButton._isShowing = false;
    }
    public void ShowProfilePanel()
    {
        _profilePanelAnimator.SetTrigger("Show Profile Panel");
        _profilePanel._isShowing = true;
    }
    public void HideProfilePanel()
    {
        _profilePanelAnimator.SetTrigger("Hide Profile Panel");
        _profilePanel._isShowing = false;
    }
    public void ShowCreateProfile()
    {
        _acceptProfileAnimator.SetTrigger("Show Create Profile");
        _acceptProfile._isShowing = true;
    }
    public void HideCreateProfile()
    {
        _acceptProfileAnimator.SetTrigger("Hide Create Profile");
        _acceptProfile._isShowing = false;
    }   
    
    public ProfilePanel GetProfilePanel()
    {
        return _profilePanel;
    }
    public AcceptProfileNameClick GetAcceptProfile()
    {
        return _acceptProfile;
    }
    public GameSelection GetGameSelection()
    {
        return _gameSelection;
    }
    public DifficultySelectionGroup GetDifficultySelectionGroup()
    {
        return _difficultySelectionGroup;
    }
}
