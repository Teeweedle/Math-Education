using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionGame : MathProblem
{
    public override void CreateMathProblem(int[] aMathArray, string aGameMode)
    {
        base.CreateMathProblem(aMathArray, aGameMode);
        //addition problem
        _numTwo = _answer - _numOne;
        fMathProblem.SetText(_numOne + " + " + _numTwo + " = ");        
    }
    protected override string GetMathProblem()
    {
        return String.Concat(_numOne + " + " + _numTwo + " = ");
    }
}
