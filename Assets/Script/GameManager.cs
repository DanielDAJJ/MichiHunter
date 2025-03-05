using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public int humanLife;
    public int playerParasiteLevel;
    public int humanParasiteLevel;
    public int wave;
    public bool gameOver;
    public bool gameWin;
    public bool gameoverSoubnd=false;
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
            if(!gameoverSoubnd)
            {
                print("sonido");    
            AudioManager.instance.PlaySound(AudioManager.instance.catDeathSound);  
            gameoverSoubnd=true;
            } 
        }
    }
    public void GameOver()
    {
        print("GameOver");
        gameOver=true;
        wave=0;
        if (UiManager.Instance != null)
        {
            UiManager.Instance.ShowGameOverScreen();
        }
    }

    public void PlayerParasiteLevel()
    {
        playerParasiteLevel++;
        
    }
    
    public void HumanParasiteLevel()
    {
        humanParasiteLevel++;
    }
    
    public void WaveCount()
    {
        wave++;
    }
    
     public void GameWin()
     {
        gameWin=true;
        print("You Win");

     }   


}
