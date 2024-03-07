using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private const int _GAMESELECTION = 1;

    [Header("Button Manager")]
    [SerializeField] protected PlayGameButton _playButton;
    [SerializeField] protected ProfilePanel _profilePanel;
    [SerializeField] protected AcceptProfileNameClick _acceptProfile;
    [SerializeField] protected GameSelection _gameSelection;
    [SerializeField] protected DifficultySelectionGroup _difficultySelectionGroup;
    [SerializeField] private Button _mermaidButton;
    [SerializeField] private Button _pirateButton;
    [SerializeField] private GameObject _backButton;

    [Header("Button Manager - Animators")]
    [SerializeField] protected Animator _playAnimator;    
    [SerializeField] protected Animator _profilePanelAnimator;    
    [SerializeField] protected Animator _acceptProfileAnimator;
    [SerializeField] protected Animator _gameSelectionAnimator;
    [SerializeField] protected Animator _difficultySelectionAnimator;
    [SerializeField] protected Animator _activeProfilePanel;


    private void OnEnable()
    {
        PrefabSelection._onPrefabSelected += ChangeSelection;
        SceneManager.sceneLoaded += FindReferences;
    }
    private void OnDisable()
    {
        PrefabSelection._onPrefabSelected -= ChangeSelection;
        SceneManager.sceneLoaded -= FindReferences;
    }   
    /// <summary>
    /// Colors the button with the name of the param green to show it is selected and colors the opposite white (normal).
    /// </summary>
    /// <param name="aName"></param>
    private void ChangeSelection(string aName)
    {
        if (aName.Equals("Mermaids"))
        {
            _mermaidButton.GetComponent<Image>().color = Color.green;
            _pirateButton.GetComponent<Image>().color = Color.white;
        }
        else
        {
            _mermaidButton.GetComponent<Image>().color = Color.white;
            _pirateButton.GetComponent<Image>().color = Color.green;
        }
    }
    private void FindReferences(Scene aScene, LoadSceneMode aMode)
    {
        if (aScene.buildIndex == _GAMESELECTION)
        {
            _backButton = GameObject.Find("Back Button");
            _activeProfilePanel = GameObject.Find("Active Profile").GetComponent<Animator>();
        }
    }
    public void HideBackButton()
    {
        _backButton.SetActive(false);
    }
    public void ShowBackButton()
    {
        _backButton.gameObject.SetActive(true);
    }
    public void ShowActiveProfilePanel()
    {
        _activeProfilePanel.SetTrigger("Show");
    }
    public void HideActiveProfilePanel()
    {
        _activeProfilePanel.SetTrigger("Hide");
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
