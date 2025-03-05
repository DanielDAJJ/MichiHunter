using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject player;
    void Start()
    {
        Time.timeScale = 0;
        DisablePlayerControl();


    }
    void Update()
    {
        
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        menuUI.SetActive(false);
        EnablePlayerControl();
    }
    void DisablePlayerControl()
    {
        if (player != null)
        {
            player.GetComponent<Cat_Locomotion>().enabled = false;
            player.GetComponent<CharacterAiming>().enabled = false;
        }
    }
    void EnablePlayerControl()
    {
        if (player != null)
        {
            player.GetComponent<Cat_Locomotion>().enabled = true;
            player.GetComponent<CharacterAiming>().enabled = true;
        }
    }
}
