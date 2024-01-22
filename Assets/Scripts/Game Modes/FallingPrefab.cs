using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class FallingPrefab : MonoBehaviour
{
    [SerializeField] private MathProblem _mathProblem;
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private GameObject _wrongAnswer;
    private int _column;
    public int _valueHeld;
    private float _btmOfScreen;
    private bool _isOffScreen;

    public delegate void PlaySound(string aSoundName);
    public static event PlaySound _onPlaySound;
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        //set rng drop rate
        _rigidBody.gravityScale = UnityEngine.Random.Range(0.005f, 0.01f);
        //grabbing top of screen at spawn time
        _btmOfScreen = -this.transform.position.y;
        _isOffScreen = false;
    }
    void Update()
    {
        if(this.transform.position.y < _btmOfScreen)
        {
            _isOffScreen = true;
            _mathProblem.CheckGameState(_valueHeld, _isOffScreen);
            Destroy(this.gameObject);
            UpdateMathArray();
        }
    }
    /// <summary>
    /// Copies values for prefab to "hold"
    /// </summary>
    /// <param name="aColumn"></param>
    /// <param name="aValueHeld"></param>
    /// <param name="aMathProblem"></param>
    /// <param name="aWrongAnswer"></param>
    public void SetValues(int aColumn, int aValueHeld, MathProblem aMathProblem, GameObject aWrongAnswer)
    {
        _column = aColumn;
        _valueHeld = aValueHeld;
        _mathProblem = aMathProblem;
        _wrongAnswer = aWrongAnswer;
    }
    /// <summary>
    /// Checks the answer of the Mermaid clicked. If incorrect spawn "x" and play the incorrect sound effect.
    /// </summary>
    private void OnMouseDown()
    {
        if (!_mathProblem.CheckGameState(_valueHeld))
        {            
            _onPlaySound?.Invoke("WrongAnswer_SE");
            
            for (int i = 0; i < UnityEngine.Random.Range(2, 4); i++)
            {   //spawn x's to indicate wrong answer
                Instantiate(_wrongAnswer, this.transform.position, quaternion.identity);
            }
        }
        Destroy(this.gameObject);        
    }
    private void UpdateMathArray()
    {
        _mathProblem.UpdateMathArray(_column);
    }
}
