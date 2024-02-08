using System.Collections.Generic;
using UnityEngine;

public static class PlayerProfile
{
    public static string _name;
    public static string _coins;
    public static string _profilePicture;
    public static List<string> _collectionScrollList;
    public static List<string> _itemNameList;
    public static List<Vector2> _itemPositionList;

    public static void MakeProfileStatic(TempProfile aProfile)
    {
        _name = aProfile._name;
        _coins = aProfile._coins;
        _profilePicture = aProfile._profilePicture;
        _collectionScrollList = aProfile._collectionScrollList;
        _itemNameList = aProfile._itemNameList;
        _itemPositionList = aProfile._itemPositionList;        
    }
    public static void CreateNewProfile(string aProfile)
    {
        TempProfile lProfile = new TempProfile();
        lProfile.CreateNewProfile(aProfile);
        MakeProfileStatic(lProfile);
    }
    public static void LoadProfile(string aProfile)
    {
        TempProfile lTempProfile = new TempProfile();
        lTempProfile = SaveSystem.LoadPlayer(aProfile);
        _name = lTempProfile._name;
        _coins = lTempProfile._coins;
        if(string.IsNullOrEmpty(lTempProfile._profilePicture)) {
            _profilePicture = "Mermaid_01";
        }else
            _profilePicture = lTempProfile._profilePicture;
        _collectionScrollList = lTempProfile._collectionScrollList;
        _itemNameList = lTempProfile._itemNameList;
        _itemPositionList = lTempProfile._itemPositionList;
    }

    public static TempProfile MakeObject()
    {
        TempProfile aProfile = new TempProfile();
        aProfile._name = _name;
        aProfile._coins = _coins;
        aProfile._profilePicture = _profilePicture;
        aProfile._collectionScrollList = _collectionScrollList;
        aProfile._itemNameList = _itemNameList;
        aProfile._itemPositionList = _itemPositionList;
        return aProfile;
    }
    public static void SaveProfile()
    {
        SaveSystem.SaveProfile(MakeObject());
    }
}
