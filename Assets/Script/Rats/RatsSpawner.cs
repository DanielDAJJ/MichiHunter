using UnityEngine;

public class RatsSpawner : MonoBehaviour
{   

    public Transform[] goalPositions;
    float timeCount;

    public GameObject ratPrefab;

     void Start()
    {
        
    }

    void Update()
    {   
        timeCount+=Time.deltaTime;
        if(timeCount>10f)//añadir un gamemanager.instance gameStarted; 
        {
           int x= Random.Range(0,goalPositions.Length);     
           Instantiate(ratPrefab,goalPositions[x].transform.position,ratPrefab.transform.rotation); 
           timeCount=0f;
        }
    }
}
