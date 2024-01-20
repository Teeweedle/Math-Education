using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AcceptProfileNameClick : ButtonManager
{    
    [SerializeField] private TextMeshProUGUI fInputFieldText;
    [SerializeField] private ActiveProfileManager _activeProfileManager;

    private const string _STARTGAMESCENE = "Start Game";
    private const string _PROFILEKEY = "Profile";
    private const int _GAMESELECTIONSCENE = 1;
    private StringBuilder _stringBuilder;
        
    public bool _isShowing;
    // Start is called before the first frame update
    void Start()
    {
        _isShowing = false;
        _stringBuilder = new StringBuilder();
    }

    public void AcceptProfileName()
    {
        string lProfileNameString = fInputFieldText.text;
        if (DoesProfileExist(lProfileNameString) || lProfileNameString.Length == 1)
        {
            Debug.Log("You didn't enter a name or that name already exists!");
        }
        else
        {
            //TempProfile lProfile = new TempProfile();
            //lProfile.CreateNewProfile(lProfileNameString);
            //PlayerProfile.MakeProfileStatic(lProfile);
            PlayerProfile.CreateNewProfile(lProfileNameString);
            PlayerPrefs.SetString(_PROFILEKEY, lProfileNameString);            

            if (SceneManager.GetActiveScene().name.Equals(_STARTGAMESCENE))
            {
                SceneManager.LoadScene(_GAMESELECTIONSCENE);
            }
            else
            {
                _activeProfileManager.SetActiveProfile();
                HideCreateProfile();
                ShowGameSelection();
            }
        }
    }

    private bool DoesProfileExist(string aProfileName)
    {
        return System.IO.File.Exists(ProfilePath(aProfileName));
    }

    private string ProfilePath(string aProfileName)
    {
        _stringBuilder.Clear();
        _stringBuilder.Append(Application.persistentDataPath);
        _stringBuilder.Append("/player_profile/");
        _stringBuilder.Append(aProfileName);
        _stringBuilder.Append(".json");
        return _stringBuilder.ToString();
    }
}
