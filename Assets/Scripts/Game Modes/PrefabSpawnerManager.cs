using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PrefabSpawnerManager : MonoBehaviour
{
    private const int _ZCOORD = 0;

    [SerializeField] private Camera _myCamera;
    [SerializeField] private GameObject[] _prefabArray;
    [SerializeField] private GameObject[] _spawnerArray = new GameObject[5];
    [SerializeField] private MathProblem _mathProblem;
    [SerializeField] private GameObject _spawnLocation;

    private int[] _mathArray = new int[5];
    private int[] _difficulty;

    private void OnEnable()
    {
        PlayAgainButton._playAgain += StartGameAgain;
    }

    void Start()
    {   
        _myCamera = Camera.main;
        _difficulty = PlayerInfo.GetDifficulty();
        if (PlayerInfo._gameMode == "Counting Game")
        {//so counting game doesn't have you count 0
            _difficulty[0] += 1;
        }
        //change to dynamically create spawners and add to array
        PlaceSpawners(Screen.width, Screen.height, _ZCOORD);
        //loading player selected prefabs
        PopulatePrefabArray(PlayerInfo._prefabSelection);
        //spawning intial set
        SpawnFallingPrefabs();   
    }  
    /// <summary>
    /// Spawns prefabs at all spawners and stores their values in _mathArray[].
    /// </summary>
    void SpawnFallingPrefabs()
    {
        for (int i = 0; i < _mathArray.Length; i++)
        {
            _mathArray[i] = _spawnerArray[i].GetComponent<PrefabSpawner>()
                .SpawnPrefab(_difficulty[0], _difficulty[1], _spawnLocation.transform);
        }
        _mathProblem.CreateMathProblem(_mathArray, PlayerInfo._gameMode);
    }

    //placing spawners at start of game
    void PlaceSpawners(float aX, float aY, float aZ)
    {
        float lSpacer = 0.1f;
        for (int i = 0; i < _spawnerArray.Length; i++)
        {
            _spawnerArray[i].transform.position = _myCamera.ScreenToWorldPoint(new Vector3(aX * lSpacer, aY, aZ));
            lSpacer += 0.2f;
        }
    }
    public GameObject GetPrefab(int aPrefab)
    {
        return _prefabArray[aPrefab];
    }
    public void StartGameAgain()
    {
        RemoveActivePrefabs();
        SpawnFallingPrefabs();
        Time.timeScale = 1;
    }
    /// <summary>
    /// Remove active prefabs based on user choice.
    /// </summary>
    private void RemoveActivePrefabs()
    {
        GameObject[] lprefabArray = GameObject.FindGameObjectsWithTag(PlayerInfo._prefabSelection);
        foreach (GameObject gameObject in lprefabArray)
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// Load specific prefabs based on user choice.
    /// </summary>
    /// <param name="aSelection"></param>
    private void PopulatePrefabArray(string aSelection)
    {
        _prefabArray = Resources.LoadAll<GameObject>("Prefabs/" + aSelection);
    }

    private void OnDisable()
    {
        PlayAgainButton._playAgain -= StartGameAgain;
    }
}
