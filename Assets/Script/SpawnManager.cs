using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] goalPositions;
    float timeCount;
    public float timeToSpawn;
    private int ratCount;
    public GameObject ratPrefab;
    public GameObject ratGreenPrefab;

     void Start()
    {
        
    }

    void Update()
    {   
        timeCount+=Time.deltaTime;
        if(timeCount>timeToSpawn)//añadir un gamemanager.instance gameStarted; 
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
    }
}


