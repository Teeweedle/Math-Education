using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class ProfilePanel : MonoBehaviour
{
    private const string _PROFILEPATH = "/player_profile/";

    [SerializeField] private TextMeshProUGUI[] _profileNameList = new TextMeshProUGUI[3];

    private string[] _profileList;
    private string _profileDirectory;

    public bool _isShowing = false;
    private void Awake()
    {
        _profileDirectory = Application.persistentDataPath + _PROFILEPATH;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!System.IO.Directory.Exists(_profileDirectory))
            System.IO.Directory.CreateDirectory(_profileDirectory);

        LoadProfiles();
    }
    /// <summary>
    /// Loads all profiles found on the profile buttons for player selection.
    /// </summary>
    private void LoadProfiles()
    {
        _profileList = System.IO.Directory.GetFiles(_profileDirectory)
            .Where(name => name.EndsWith(".json")).ToArray();

        if (_profileList.Length > 0)
        {
            int i = 0;
            //display all profiles
            foreach (string lProfile in _profileList)
            {
                _profileNameList[i].text = Path.GetFileNameWithoutExtension(lProfile);
                i++;
            }
        }
    }
}
