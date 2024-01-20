using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtractionGame : MathProblem
{
    public override void CreateMathProblem(int[] aMathArray, string aGameMode)
    {
        base.CreateMathProblem(aMathArray, aGameMode);
        //subtraction problem
        _numTwo = _answer + _numOne;
        fMathProblem.SetText(_numTwo + " - " + _numOne + " = ");
    }
    protected override string GetMathProblem()
    {
        return String.Concat(_numTwo + " - " + _numOne + " = ");
    }
}
