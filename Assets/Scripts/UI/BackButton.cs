using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{    
    private const int _GAMESELECTION = 1;
    public ButtonManager _buttonManager;

    public delegate void EndGame();
    public static event EndGame _quitGame;

    /// <summary>
    /// Subscribe to sceneLoaded event.
    /// </summary>
    private void OnEnable()
    {
        SceneManager.sceneLoaded += FindReferences;
    }
    public void OnClick()
    {
        Scene lScene = SceneManager.GetSceneAt(1);

        if (lScene.buildIndex == _GAMESELECTION)
        { 
            if (_buttonManager.GetAcceptProfile()._isShowing)//go back to profile selection
            {
                _buttonManager.ShowProfilePanel();
                _buttonManager.HideCreateProfile();
            }else if (_buttonManager.GetGameSelection()._isShowing) 
            {
                _buttonManager.HideGameSelection();
                _buttonManager.ShowProfilePanel();
            }else if (_buttonManager.GetDifficultySelectionGroup()._isShowing)
            {
                _buttonManager.HideDifficultySelection();
                _buttonManager.ShowGameSelection();
            }
        }
        else
        {
            LoadScene._instance.LoadSceneTransition(lScene.name, _GAMESELECTION);
            Time.timeScale = 1;
            _quitGame?.Invoke();
        }
    }
    /// <summary>
    /// Subscribed to Unity Scene change event. Checks to see if Game Selection scene is loaded
    /// and gets a ButtonManager reference for button animations.
    /// </summary>
    /// <param name="aScene"></param>
    /// <param name="aMode"></param>
    private void FindReferences(Scene aScene, LoadSceneMode aMode)
    {
        if (aScene.buildIndex == _GAMESELECTION)
            _buttonManager = GameObject.Find("Button Manager").
                GetComponent<ButtonManager>();

    }
    /// <summary>
    /// Unsubscribe from event.
    /// </summary>
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= FindReferences;
    }

}
