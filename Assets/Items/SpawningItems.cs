using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class SpawningAmmoAndFAK : MonoBehaviour
{
    public GameObject[] _objects;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Contains("Level1"))
        {
            GenerateLevel1Items();
            
        }
        else if (SceneManager.GetActiveScene().name.Contains("Level2"))
        {
            GenerateLevel2Items();
        }
        else
        {
            GenerateLevel3Items();
           
        }
    }

    private void GenerateLevel3Items()
    {
        for (int i = 0; i < 6; i++)
        {
            Vector3 randomSpawnPos = new Vector3(Random.Range(0, 10)+0.25f, 0.01f, Random.Range(0, 10)+0.25f);
            Instantiate(_objects[0], randomSpawnPos, Quaternion.identity).transform.Rotate(-90, 0, 0);
        }for (int j = 0; j < 4; j++)
        {
            Vector3 randomSpawnPos = new Vector3(Random.Range(0, 10), 0.01f, Random.Range(0, 10));
            Instantiate(_objects[1], randomSpawnPos, Quaternion.identity);
        }
    }
    private void GenerateLevel2Items()
    {
        
        for (int i = 0; i < 7; i++)
        {
            Vector3 randomSpawnPos = new Vector3(Random.Range(0, 10)+0.25f, 0.01f, Random.Range(0, 10)+1f);
            Instantiate(_objects[0], randomSpawnPos, Quaternion.identity).transform.Rotate(-90, 0, 0);
        }for (int j = 0; j < 5; j++)
        {
            Vector3 randomSpawnPos = new Vector3(Random.Range(0, 10), 0.01f, Random.Range(0, 10));
            Instantiate(_objects[1], randomSpawnPos, Quaternion.identity);
        }
    }
    private void GenerateLevel1Items()
    {
        for (int i = 0; i < 8; i++)
        {
            Vector3 randomSpawnPos = new Vector3(Random.Range(0, 10)+0.25f, 0.01f, Random.Range(0, 10)+0.25f);
            Instantiate(_objects[0], randomSpawnPos, Quaternion.identity).transform.Rotate(-90, 0, 0);
        }for (int j = 0; j < 6; j++)
        {
            Vector3 randomSpawnPos = new Vector3(Random.Range(0, 10), 0.01f, Random.Range(0, 10));
            Instantiate(_objects[1], randomSpawnPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
