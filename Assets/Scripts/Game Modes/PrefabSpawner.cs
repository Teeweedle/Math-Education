using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{    
    private const int _ZCOORD = 0;

    [SerializeField] private PrefabSpawnerManager _prefabSpawnerManager;
    [SerializeField] private MathProblem fMathProblem;
    [SerializeField] private GameObject _wrongAnswer;

    private int _column;

    /// <summary>
    /// Spawns mermaid at give spawner and returns the value it is holding.
    /// </summary>
    /// <param name="aMin"></param>
    /// <param name="aMax"></param>
    /// <returns></returns>
    public int SpawnPrefab(int aMin, int aMax, Transform aLocation)
    {
        //# held by prefab
        int lValueHeld = Random.Range(aMin, aMax);

        GameObject lPrefab = _prefabSpawnerManager.GetPrefab(Random.Range(0, 3));

        lPrefab.GetComponent<FallingPrefab>().SetValues(_column, lValueHeld, fMathProblem, _wrongAnswer);
        //set mermaid number        
        lPrefab.transform.GetChild(0).transform.GetChild(0).gameObject
            .GetComponent<TextMeshProUGUI>().text = lValueHeld.ToString();
        //instantiates and make sure future prefabs are in front of camera
        Instantiate(lPrefab,
            new Vector3(this.transform.position.x, this.transform.position.y, _ZCOORD),
            Quaternion.identity, aLocation);
        return lValueHeld;
    }
}
