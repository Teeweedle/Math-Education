using TMPro;
using UnityEngine;

public class GameFinishPopup : MonoBehaviour
{
    public delegate void Darken();
    public static event Darken _darken;

    public delegate void Modal(string aTextOutput, string aMathProblem, int aScore, int aAnswer);
    public static event Modal _modal;

    private void OnEnable()
    {
        MathProblem._endGame += ShowPopup;
        MatchingGame._endGame += ShowPopup;
    }    
    private void ShowPopup(string aTextOutput, string aMathProblem, int aScore, int aAnswer)
    {
        _modal?.Invoke(aTextOutput, aMathProblem, aScore, aAnswer);
    }    
    private void OnDisable()
    {
        MathProblem._endGame -= ShowPopup;
        MatchingGame._endGame -= ShowPopup;
    }
}
