using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class MathProblem : MonoBehaviour
{
    protected const int _MAXNUMTRIES = 2;
    private const string _SHOWMATHSIGN = "Show";
    private const string _HIDEMATHSIGN = "Hide";
    [Header("Math Problem")]
    [SerializeField] protected TextMeshProUGUI fMathProblem;
    [SerializeField] protected Animator _mathSignAnimator;

    protected int _choice, _answer, _numOne, _numTwo, _score, _currentNumberOfTries;
    protected int[] _mathArray;
    protected string _gameMode;

    public delegate void StartGame();
    public static event StartGame _startGame;

    public delegate void EndGame(string aTextOutput, string aMathProblem, int aScore, int aAnswer);
    public static event EndGame _endGame;

    //checks math array and creates a problem based off given answers
    public virtual void CreateMathProblem(int[] aMathArray, string aGameMode)
    {        
        _answer = GetAnswer(aMathArray);
        _gameMode = aGameMode;
        _numOne = UnityEngine.Random.Range(0, _answer);

        _score = aMathArray.Length - 1;
        _currentNumberOfTries = _MAXNUMTRIES;
        _mathSignAnimator.SetTrigger(_SHOWMATHSIGN);
        _startGame?.Invoke();
    }
    /// <summary>
    /// Accepts an array and randomly chooses a value to be the answer.
    /// </summary>
    /// <param name="aMathArray"></param>
    /// <returns></returns>
    protected int GetAnswer(int[] aMathArray)
    {
        _mathArray = aMathArray;
        _choice = UnityEngine.Random.Range(0, 4);
        return aMathArray[_choice];
    }

    #region CheckGameState
    public virtual bool CheckGameState(int aValueHeld)
    {
        bool lBool = true;
        if (IsCorrect(aValueHeld))
        {
            ShowPopUp("Correct!");
        }
        else if (!IsCorrect(aValueHeld) && GetNumberOfTries() > 0)
        {
            ReduceNumberOfTries();
            ReduceScore();
            lBool = false;
        }
        else if (GetNumberOfTries() <= 0) 
        {
            ShowPopUp("You ran out of tries.");
        }
        return lBool;
    }
    //only if mermaid is off screen
    public virtual void CheckGameState(int aValueHeld, bool aIsOffScreen)
    {
        int lNumOfMatches = 0;
        foreach (int val in _mathArray)
        {
            if (val == aValueHeld)
            {
                lNumOfMatches++;
            }
        }
        if (IsCorrect(aValueHeld) && lNumOfMatches == 1)
        {
            ShowPopUp("You missed the answer.");
        }
        else if (!IsCorrect(aValueHeld) && GetNumberOfTries() > 0)
        {
            ReduceNumberOfTries();
            ReduceScore();
        }
        else if (GetNumberOfTries() <= 0)
        {
            ShowPopUp("Sorry, you missed the answer and ran out of tries!");
        }
    }
    #endregion


    public bool IsCorrect(int aAnswer)
    {
        return (aAnswer == _answer);
    }
    public void ReduceScore()
    {
        _score--;
    }
    public void ReduceNumberOfTries()
    {
        _currentNumberOfTries--;
    }
    public int GetNumberOfTries()
    {
        return _currentNumberOfTries;
    }

    public int GetAnswer()
    { 
        return _answer; 
    }
    /// <summary>
    /// Calls UI Manager to display a popup with game finish info.
    /// </summary>
    /// <param name="aMsg"></param>
    public void ShowPopUp(string aMsg)
    {
        _mathSignAnimator.SetTrigger(_HIDEMATHSIGN);        
        //_uiManager.ShowPopUp(aMsg, GetMathProblem(), _score, GetAnswer());
        _endGame?.Invoke(aMsg, GetMathProblem(), _score, GetAnswer());
        Time.timeScale = 0;
    }

    public void UpdateMathArray(int aColumn)
    {
        List<int> lMathlist = _mathArray.ToList();
        lMathlist.Remove(aColumn);
        _mathArray = lMathlist.ToArray();
    }

    protected virtual String GetMathProblem()
    {
        return "";
    }
    private void OnDestroy()
    {
        _startGame = null;
        _endGame = null;
    }

}
