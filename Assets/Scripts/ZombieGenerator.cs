using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ZombieGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject zombie;
    public int LevelNo;
    float time = 0f;
    public float TimeBetweenEvents = 10f;
    public void Start()
    {
        switch (LevelNo)
        {
            case 1:
                for (int i = 0; i < 15; i++)
                {
                    Instantiate(zombie, new Vector3(Random.Range(3, 13), 0, Random.Range(3, 13)),
                        Quaternion.identity);
                }
                break;
            case 2:
                for (int i = 0; i < 20; i++)
                {
                    Instantiate(zombie, new Vector3(Random.Range(3, 13), 0, Random.Range(3, 13)),
                        Quaternion.identity);
                }
                break;
            case 3:
                for (int i = 0; i < 25; i++)
                {
                    Instantiate(zombie, new Vector3(Random.Range(3, 13), 0, Random.Range(3, 13)),
                        Quaternion.identity);
                }
                break;
        }
        
    }

    public void Update()
    {
        time += Time.deltaTime;
        if (time>=TimeBetweenEvents)
        {
            time = 0f;
            Instantiate(zombie, new Vector3(Random.Range(0, 15), 0, Random.Range(0, 15)),
                Quaternion.identity);
        }
    }
}
