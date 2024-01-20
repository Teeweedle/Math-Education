using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    [SerializeField] private Grid _Grid;
    [SerializeField] private GameObject _Card;
    [SerializeField] private MatchingGame _matchingGame;

    public List<GameObject> _cardlist = new List<GameObject>();
    private List<int> _cardNumbersList = new List<int>();
    private int[] _difficulty;
    // Start is called before the first frame update
    void Start()
    {
        _difficulty = PlayerInfo.GetDifficulty();        
        
        SpawnGrid();
    }

    public void SpawnGrid()
    {
        _cardNumbersList = CreateCardNumbers(_difficulty);
        GameObject lCard;
        int lGridY = _difficulty[1] / 10;
        int lRngItem;
        for (int x = -2; x < 3; x++)
        {
            for (int y = -lGridY; y < lGridY; y++)
            {
                Vector3 lWorldPosition = _Grid.GetCellCenterWorld(new Vector3Int(x, y));
                lCard = Instantiate(_Card, lWorldPosition, Quaternion.identity);
                //might have to change to use global list
                lRngItem = Random.Range(0, _cardNumbersList.Count);
                lCard.GetComponent<CardBehaviour>()._cardNumber = _cardNumbersList[lRngItem];
                _cardNumbersList.RemoveAt(lRngItem);
                _cardlist.Add(lCard);
            }
        }
        _matchingGame.AddCardList(_cardlist);
    }

    private List<int> CreateCardNumbers(int[] aDifficulty)
    {
        List<int> lNumberList = new List<int>();
        int lTempNumber;
        for (int x = 0; x < aDifficulty[1] / 2; x++)
        {
            lTempNumber = Random.Range(aDifficulty[0], aDifficulty[1]);
            lNumberList.Add(lTempNumber);
            lNumberList.Add(lTempNumber);
        }
        return lNumberList;
    }
}
