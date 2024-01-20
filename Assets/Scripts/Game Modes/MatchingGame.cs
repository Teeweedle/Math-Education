using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MatchingGame : MonoBehaviour
{
    [SerializeField] private GridScript _gridScript; 

    private List<GameObject> _cardlist = new List<GameObject>();
    private List<int> _cardValues = new List<int>();
    private List<GameObject> _cardObjects = new List<GameObject>();
    private int _score;
    private const float DELAY = 1.0f;
    private const string CHECKGAMESTATE = "CheckGameState";

    public delegate void EndGame(string aTextOutput, string aMathProblem, int aScore, int aAnswer);
    public static event EndGame _endGame;

    private void OnEnable()
    {
        PlayAgainButton._playAgain += PlayAgain;
    }
    void Start()
    {
        _score = PlayerInfo.GetDifficulty()[1];
    }

    public void CardSelection(GameObject aCard, int aValue)
    {
        _cardObjects.Add(aCard);
        _cardValues.Add(aValue);

       
        if (_cardObjects.Count == 2)
        {
            DeactivateCardList(_cardlist);
            Invoke(CHECKGAMESTATE, DELAY);
        }
    }   

    private void CheckGameState()
    {
        if (_cardValues[0] == _cardValues[1])
        {
            foreach (GameObject aCard in _cardObjects)
            {                
                Destroy(aCard, 0.1f);
                _cardlist.Remove(aCard);
            }
        }
        else
        {
            foreach (GameObject aCard in _cardObjects)
            {
                StartCoroutine(aCard.GetComponent<CardBehaviour>().RotateCardFaceDown());
            }
        }
        _cardValues.Clear();
        _cardObjects.Clear();
        if(_cardlist.Count == 0)
        {
            _endGame?.Invoke("Finished", "", _score, 0);                      
        }
        else
        {
            ActivateCardList(_cardlist);
        }
    }
    public void AddCardList(List<GameObject> aList)
    {
        _cardlist = aList;
    }
    public void PlayAgain()
    {
        _gridScript.SpawnGrid();  
    }
    public void DeactivateCardList(List<GameObject> aList)
    {
        foreach (GameObject card in aList)
        {
            card.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    public void ActivateCardList(List<GameObject> aList)
    {
        foreach (GameObject card in aList)
        {
            card.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    private void OnDisable()
    {
        PlayAgainButton._playAgain -= PlayAgain;
    }
    private void OnDestroy()
    {
        _endGame = null;
    }
}
