using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgainButton : MonoBehaviour
{   
    public delegate void PlayAgain();
    public static event PlayAgain _playAgain;
    public void OnClick()
    {
        _playAgain?.Invoke();
    }
}
