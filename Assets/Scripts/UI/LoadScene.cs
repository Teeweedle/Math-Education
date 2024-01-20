using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private const string _CROSSFADEEND = "End";
    private const string _CROSSFADESTART = "Start";
    private const string _DOORSOPEN = "Open Doors";
    private const string _DOORSCLOSE = "Close Doors";

    [SerializeField] private Animator _crossFadeAnimator;
    [SerializeField] private Animator _pictureAnimator;

    public static LoadScene _instance { get; private set; }
    void Start()
    {
        if (_instance == null)
            _instance = this;
        else Destroy(gameObject);
        HideSceneTransition();
    }
    public async void HideSceneTransition()
    {
        await Task.Delay(1000);
        _pictureAnimator.SetTrigger(_DOORSOPEN);
        _crossFadeAnimator.SetTrigger(_CROSSFADEEND);        
    }
    public async void LoadSceneTransition(string aUnloadLevel, int aLoadLevel)
    {   
        _pictureAnimator.SetTrigger(_DOORSCLOSE);
        await Task.Delay(200);
        _crossFadeAnimator.SetTrigger(_CROSSFADESTART);
        await Task.Delay(1000);
        SceneManager.UnloadSceneAsync(aUnloadLevel);
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene(aLoadLevel, LoadSceneMode.Additive);
        HideSceneTransition();        
    }
}
