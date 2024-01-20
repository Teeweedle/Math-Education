using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameSelection : ButtonManager
{
    private Dictionary<string, int> _gameSelectionDictionary = new Dictionary<string, int>();
    [Header("Game Selection")]
    public bool _isShowing;
    void Start()
    {
        _isShowing = true;
        CreateGameDictionary();
    }
    /// <summary>
    /// Creates a dictionary for scene loading references.
    /// </summary>
    private void CreateGameDictionary()
    {
        _gameSelectionDictionary.Add("Addition Game", 2);
        _gameSelectionDictionary.Add("Subtraction Game", 3);
        _gameSelectionDictionary.Add("Counting Game", 4);
        _gameSelectionDictionary.Add("Matching Game", 5);
    }
    public Dictionary<string, int> GetDictionary()
    {
        return _gameSelectionDictionary;
    }
}
