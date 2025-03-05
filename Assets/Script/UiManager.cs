using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject player;
    [SerializeField] GameObject loreScreen;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        loreScreen.SetActive(false);
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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        EnablePlayerControl();
    }
    void DisablePlayerControl()
    {
        if (player != null)
        {
            player.GetComponent<Cat_Locomotion>().enabled = false;
            player.GetComponent<CharacterAiming>().enabled = false;
            Debug.Log("Se han desativado los controles del player");
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
    public void LoreScreen()
    {
        if (loreScreen != null)
        {
            loreScreen.SetActive(true);
            Debug.Log("LoreScreen activada");
        }
        else
        {
            Debug.LogError("loreScreen no está asignado en el Inspector.");
        }
    }
}
