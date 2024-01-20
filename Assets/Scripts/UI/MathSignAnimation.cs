using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathSignAnimation : MonoBehaviour
{
    private const string _SHOWMATHSIGN = "Show";
    private const string _HIDEMATHSIGN = "Hide";

    [SerializeField] protected Animator _mathSignAnimator;

    private void OnEnable()
    {
        MathProblem._startGame += ShowMathSign;
        MathProblem._endGame += HideMathSign;
    }
    private void ShowMathSign()
    {
        _mathSignAnimator.SetTrigger(_SHOWMATHSIGN);
    }

    private void HideMathSign(string aTextOutput, string aMathProblem, int aScore, int aAnswer)
    {
        _mathSignAnimator.SetTrigger(_HIDEMATHSIGN);
    }
    private void OnDisable()
    {
        MathProblem._startGame -= ShowMathSign;
        MathProblem._endGame -= HideMathSign;
    }
}
