using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] goalPositions;
    float timeCount;
    public float timeToSpawn;

    public float waveTime;
    private int ratCount;
    public GameObject ratPrefab;
    public GameObject ratGreenPrefab;

     void Start()
    {
        
    }

    void Update()
    {       
        timeCount+=Time.deltaTime;
        if(timeCount>timeToSpawn)
        {
           int x= Random.Range(0,goalPositions.Length);     
           Instantiate(ratPrefab,goalPositions[x].transform.position,ratPrefab.transform.rotation); 
           timeCount=0f;
           ratCount++;
           if (ratCount==3)
           {
             Instantiate(ratGreenPrefab,goalPositions[x].transform.position,ratPrefab.transform.rotation);
             ratCount=0;
           }
        }

        waveTime+=Time.deltaTime;
        if (waveTime<=60f)
        {
            timeToSpawn=6f;
        }
        else if (waveTime<120f)
        {
            timeToSpawn=4f;

        }
        else if (waveTime<180f)
        {
            timeToSpawn=3.5f;

        }
        else
        {
            GameManager.Instance.GameWin();
        }

    }
}


