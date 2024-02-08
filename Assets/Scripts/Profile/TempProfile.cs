using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TempProfile
{
    public string _name;
    public string _coins;
    public string _profilePicture;
    public List<string> _collectionScrollList;
    public List<string> _itemNameList;
    public List<Vector2> _itemPositionList;

    public TempProfile() 
    {
        _name = string.Empty;
        _coins = string.Empty;
        _profilePicture = string.Empty;
        _collectionScrollList = new List<string>();
        _itemNameList = new List<string>();
        _itemPositionList = new List<Vector2>();
    }
    public void CreateNewProfile(string aName)
    {
        _name = aName;
        _coins = "0";
        _profilePicture = "Mermaid_01";
        _collectionScrollList = new List<string>();
        _itemNameList = new List<string>();
        _itemPositionList = new List<Vector2>();
        SaveSystem.SaveProfile(this);
    }
}
