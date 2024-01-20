using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CountingGame : MathProblem
{
    [Header("Counting Game")]
    [SerializeField] private GameObject _countingContainer;
    [SerializeField] private GameObject _countingItem;

    public override void CreateMathProblem(int[] aMathArray, string aGameMode)
    {
        base.CreateMathProblem(aMathArray, aGameMode);

        fMathProblem.SetText("");
        for (int i = 0; i < _answer; i++)
        {
            Instantiate(_countingItem, _countingContainer.transform);
        }
    }
    public override bool CheckGameState(int aValueHeld)
    {
        bool lBool = true;
        if (IsCorrect(aValueHeld))
        {
            ShowPopUp("Correct!");            
            RemoveCountingChildren();
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
            RemoveCountingChildren();
        }
        return lBool;
    }
    public override void CheckGameState(int aValueHeld, bool aIsOffScreen)
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
            RemoveCountingChildren();
        }
        else if (!IsCorrect(aValueHeld) && GetNumberOfTries() > 0)
        {
            ReduceNumberOfTries();
            ReduceScore();
        }
        else if (GetNumberOfTries() <= 0)
        {
            ShowPopUp("Sorry, you missed the answer and ran out of tries!");
            RemoveCountingChildren();
        }
    }
    private async void RemoveCountingChildren()
    {
        await Task.Delay(1000);
        foreach (Transform child in _countingContainer.transform)
        {
            Destroy(child.gameObject);
        }        
    }
    protected override string GetMathProblem()
    {
        return "";
    }
}
