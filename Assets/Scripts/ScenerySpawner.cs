using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenerySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fGameObjects;
    [SerializeField] private Camera _myCamera;
    private const string _RESOURCEPATH = "Prefabs/Scene Animation Prefabs/Dynamic";
    private float _nextSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        _myCamera = Camera.main;
        fGameObjects = Resources.LoadAll<GameObject>(_RESOURCEPATH);
        SetSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        _nextSpawnTime -= Time.deltaTime;
        if(_nextSpawnTime <= 0)
        {
            SpawnObject(fGameObjects);
            SetSpawnTime();
        }
    }

    private void SpawnObject(GameObject[] aGameObject)
    {
        GameObject lGameObject = aGameObject[Random.Range(0, aGameObject.Length)];
        Vector3 lSpawnPoint = _myCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 5.0f));
        lSpawnPoint.y = GetSpawnHeight();
        lSpawnPoint.x += 1; //offset so sprite spawns off screen
        
        if (Random.Range(0, 2) == 1)
        {
            lSpawnPoint.x = -lSpawnPoint.x;
            Instantiate(lGameObject, lSpawnPoint, GetFlippedRotation());            
        }else
            Instantiate(lGameObject, lSpawnPoint, Quaternion.identity);
        
    }

    private void SetSpawnTime()
    {
        _nextSpawnTime = Random.Range(0.0f, 10.0f);
    }

    private GameObject FlipSeaCreature(GameObject aGameObject)
    {
        aGameObject.transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
        return aGameObject;
    }
     private Quaternion GetFlippedRotation()
    {
        return Quaternion.Euler(0.0f, 180.0f, 0.0f);
    }

    private float GetSpawnHeight()
    {
        //get rng height clamped between top of screen and top of sand
        float lRngY = Mathf.Clamp(Random.Range(_myCamera.ScreenToWorldPoint(new Vector2(0, 0)).y,
            _myCamera.ScreenToWorldPoint(new Vector2(0, Screen.height)).y), -2.0f, 4.5f);
        return lRngY;
    }
}
