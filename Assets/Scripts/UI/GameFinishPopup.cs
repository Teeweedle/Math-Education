using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinishPopup : MonoBehaviour
{
    private const string _SHOWPOPUP = "Show";
    private const string _HIDEPOPUP = "Hide";
    private const string _HIDDEN = "Hidden Popup";

    [SerializeField] private TextMeshProUGUI _popUpText;
    [SerializeField] private TextMeshProUGUI _scoreOutputPopup;
    [SerializeField] private TextMeshProUGUI _answer;
    [SerializeField] private TextMeshProUGUI _mathProblem;
    [SerializeField] private Animator _popupAnimator;

    private void OnEnable()
    {
        PlayAgainButton._playAgain += HidePopup;
        MathProblem._endGame += ShowPopup;
        MatchingGame._endGame += ShowPopup;
        BackButton._quitGame += HidePopup;
    }    
    /// <summary>
    /// Plays the hide game finish popup animation if it isn't already hidden.
    /// </summary>
    private void HidePopup()
    {
        if(!_popupAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals(_HIDDEN)) 
        {
            _popupAnimator.SetTrigger(_HIDEPOPUP);
        }        
    }    
    private void ShowPopup(string aTextOutput, string aMathProblem, int aScore, int aAnswer)
    {
        _popUpText.text = aTextOutput;
        _mathProblem.text = aMathProblem;
        _scoreOutputPopup.text = aScore.ToString();
        _answer.text = aAnswer.ToString();
        _popupAnimator.SetTrigger(_SHOWPOPUP);
    }    
    private void OnDisable()
    {
        PlayAgainButton._playAgain -= HidePopup;
        MathProblem._endGame -= ShowPopup;
        MatchingGame._endGame -= ShowPopup;
        BackButton._quitGame -= HidePopup;
    }
}
