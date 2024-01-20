using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelectionButton : ButtonManager
{
    [SerializeField] private TextMeshProUGUI _gameSelectionText;
    [SerializeField] private GameSelection _buttonManager;
    
    public void OnClick() {
        PlayerInfo._levelSelection = _buttonManager.GetDictionary()[_gameSelectionText.text];
        PlayerInfo._gameMode = _gameSelectionText.text;
        ShowDifficultySelection();
        HideGameSelection();
    }
}
