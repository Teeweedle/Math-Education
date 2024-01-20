using System.IO;
using UnityEngine;
using JetBrains.Annotations;
using System.Text;
using Newtonsoft.Json;

public static class SaveSystem
{   
    /// <summary>
    /// Converts TempProfile to a JSON to write to disk.
    /// </summary>
    /// <param name="aProfile"></param>
    public static void SaveProfile(TempProfile aProfile)
    {
        string lJson = JsonUtility.ToJson(aProfile);

        string lPath = Application.persistentDataPath + ProfilePath(aProfile._name);
        File.WriteAllText(lPath, lJson);
    }

    /// <summary>
    /// Loads a profile from a JSON file based on a profile name (string).
    /// </summary>
    /// <param name="aProfileName"></param>
    /// <returns></returns>
    public static TempProfile LoadPlayer(string aProfileName)
    {
        string lPath = Application.persistentDataPath + ProfilePath(aProfileName);
        TempProfile lProfile = null;
        if (File.Exists(lPath))
        {
            string lJson = File.ReadAllText(lPath);
            lProfile = JsonUtility.FromJson<TempProfile>(lJson);
        }
        else
        {
            Debug.Log("File not found! " + lPath);
        }
        return lProfile;
    }
    /// <summary>
    /// Returns a profile path.
    /// </summary>
    /// <param name="aProfileName"></param>
    /// <returns></returns>
    private static string ProfilePath(string aProfileName)
    {
        return "/player_profile/" + aProfileName + ".json";
    }

}
