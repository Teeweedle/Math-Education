using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelection : ButtonManager
{
    [SerializeField] private TextMeshProUGUI _DifficultySelection;
    private const string _GAMESELECTION = "Game Selection";
    public void OnClick() {
        PlayerInfo._difficulty = _DifficultySelection.text;
        HideDifficultySelection();
        LoadScene._instance.LoadSceneTransition(_GAMESELECTION, PlayerInfo._levelSelection);     
    }
}
