using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public int humanLife;
    public int playerParasiteLevel;
    public int humanParasiteLevel;
    public bool gameOver;
    public static GameManager Instance;

    void Awake()
    {
        if (Instance==null)
            {
                Instance=this;
                DontDestroyOnLoad(this.gameObject);
            }
        else
            {
                Destroy(this.gameObject);
            }
    }
    void Start()
    {   
        
        humanLife=0;
    }

    void Update()
    {
        if (humanParasiteLevel>=10)
        {
            GameOver();    
        }
    }
    public void GameOver()
    {
        print("GameOver");
        gameOver=true;
    }

    public void PlayerParasiteLevel()
    {
        playerParasiteLevel++;
    }
    
    public void HumanParasiteLevel()
    {
        humanParasiteLevel++;
    }
    

   
}
