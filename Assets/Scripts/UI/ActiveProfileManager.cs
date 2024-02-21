using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActiveProfileManager : MonoBehaviour
{
    private const string _PROFILE = "Profile";
    private const string _HIDEPROFILE = "Hide";
    private const string _SHOWPROFILE = "Show";
    private const string _PROFILEPICTUREPATH = "Sprites/Profile Pictures/";
    private const int _STARTMENU = 0;

    [Header("Active Profile")]
    [SerializeField] private TextMeshProUGUI _profileName;
    [SerializeField] private TextMeshProUGUI _profileCoins;
    [SerializeField] private Animator _profileAnimator;
    [SerializeField] private UnityEngine.UI.Image _profilePicture;

    public delegate void ProfilePictures();
    public static event ProfilePictures _toggleProfilePictures;

    private void OnEnable()
    {
        StoreManager._buyItem += BuyItem;
        CreateProfileButtonClick._login += Login;

        MathProblem._startGame += HideProfile;
        MathProblem._endGame += ShowProfile;

        MatchingGame._endGame += ShowProfile;

        SelectProfilePicture._changeProfilePicture += ChangePicture;
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey(_PROFILE))
        {
            PlayerProfile.LoadProfile(PlayerPrefs.GetString(_PROFILE));
            _profileAnimator.SetTrigger(_SHOWPROFILE);
        }
        SetActiveProfile();
        SceneManager.LoadScene(_STARTMENU, LoadSceneMode.Additive);
    }
    /// <summary>
    /// Sets Active Profile text to current Profile.
    /// </summary>
    public void SetActiveProfile()
    {        
        _profileName.text = PlayerProfile._name;
        _profileCoins.text = PlayerProfile._coins;
        _profilePicture.sprite = Resources.Load<Sprite>(_PROFILEPICTUREPATH + PlayerProfile._profilePicture);
    }
    private void ChangePicture(string aProfilePicture)
    {
        _profilePicture.sprite = Resources.Load<Sprite>(_PROFILEPICTUREPATH + aProfilePicture);
        PlayerProfile._profilePicture = aProfilePicture;
        PlayerProfile.SaveProfile();
        //_toggleProfilePictures?.Invoke();
    }
    private void UpdateScore(int aScore)
    {
        int.TryParse(_profileCoins.text, out int lTempCoins);
        _profileCoins.text = lTempCoins + aScore + "";
        PlayerProfile._coins = _profileCoins.text;
        PlayerProfile.SaveProfile();
    }
    private void ShowProfile(string aTextOutput, string aMathProblem, int aScore, int aAnswer)
    {
        UpdateScore(aScore);
        _profileAnimator.SetTrigger(_SHOWPROFILE);
    }
    private void HideProfile()
    {
        _profileAnimator.SetTrigger(_HIDEPROFILE);
    }
    private void Login()
    {
        SetActiveProfile();
    }
    /// <summary>
    /// Checks price of item against player coin count, buys, and store item if the player 
    /// has enough.
    /// </summary>
    /// <param name="aPrice"></param>
    /// <param name="aItemName"></param>
    private bool BuyItem(string aPrice, string aItemName)
    {
        bool lIsBought = false;
        int.TryParse(aPrice, out int lPrice);
        int.TryParse(_profileCoins.text, out int lProfileCoins);
        if(CheckPrice(lProfileCoins, lPrice))
        {
            _profileCoins.text = (lProfileCoins - lPrice).ToString();
            PlayerProfile._coins = _profileCoins.text;
            PlayerProfile._collectionScrollList.Add(aItemName);
            PlayerProfile.SaveProfile();
            lIsBought = true;
        }
        else
        {
            lIsBought = false;
        }
        return lIsBought;

    }
    private bool CheckPrice(int aProfileCoins, int aItemCost)
    { 
        return aProfileCoins >= aItemCost;       
    }    
    private void OnDisable()
    {
        StoreManager._buyItem -= BuyItem;
        CreateProfileButtonClick._login -= Login;

        MathProblem._startGame -= HideProfile;
        MathProblem._endGame -= ShowProfile;

        MatchingGame._endGame -= ShowProfile;

        SelectProfilePicture._changeProfilePicture -= ChangePicture;
    }

}
