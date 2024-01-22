using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingGameSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _Card;
    [SerializeField] GameObject _Grid;

    private int _TempDifficulty = 30;
    private int[,] _GridSize = new int[5,3];
    private int _Offset;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _TempDifficulty; i++)
        {
            Instantiate(_Card, _Grid.transform);
        }

    }
}
