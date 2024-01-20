using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardBehaviour : MonoBehaviour 
{
    [SerializeField] private Sprite _Front, _Back;
    [SerializeField] private SpriteRenderer _Renderer;
    [SerializeField] private TextMeshProUGUI _CardText;
    [SerializeField] private MatchingGame _matchingGame;

    public int _cardNumber { get; set; }
    private bool _coroutineAllowed, _faceUp;
    // Start is called before the first frame update
    void Start()
    {
        _matchingGame = GameObject.Find("Game Manager").GetComponent<MatchingGame>();
        _CardText.enabled = false;
        _CardText.text = _cardNumber.ToString();
        _Renderer.sprite = _Back;
        _coroutineAllowed = true;
        _faceUp = false;
    }
   
    private void OnMouseDown()
    {
        if (_coroutineAllowed)
        {
            StartCoroutine(RotateCardFaceUp());
        }        
    }

    //Rotate card face up on click
    private IEnumerator RotateCardFaceUp()
    {
        _coroutineAllowed = false;
        for (float i = 0f; i <= 180f; i += 10f)
        {
            transform.rotation = Quaternion.Euler(0f, i, 0f);
            if (i == 90f)
            {
                _Renderer.sprite = _Front;
                _CardText.enabled = true;
            }
            yield return new WaitForSeconds(0.01f);
        }
        _matchingGame.CardSelection(this.gameObject, _cardNumber);
       
        _coroutineAllowed = true;
        _faceUp = !_faceUp;
    }
    //Rotate card back to face down if not a match; called in MatchingGame
    public IEnumerator RotateCardFaceDown()
    {
        _coroutineAllowed = false;
        for (float i = 180f; i >= 0f; i -= 10f)
        {
            transform.rotation = Quaternion.Euler(0f, i, 0f);
            if (i == 90f)
            {
                _Renderer.sprite = _Back;
                _CardText.enabled = false;
            }
            yield return new WaitForSeconds(0.01f);
        }
        _coroutineAllowed = true;
    }
}
