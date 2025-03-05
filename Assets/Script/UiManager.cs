using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject optionUI;
    public GameObject creditsUI;
    public GameObject gameOverScreen;
    public GameObject Ui;
    public GameObject player;
    [SerializeField] GameObject loreScreen;
    public static UiManager Instance;

    //Variables para asignar sliders
    public Slider musicSlider;
    public Slider sfxSlider;
    public Toggle muteToggle;
    //Variables del medidor de estado
    public Image stateMeter;
    public Sprite stateLow;
    public Sprite stateMedium;
    public Sprite stateHigh;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        optionUI.SetActive(false);
        loreScreen.SetActive(false);
        creditsUI.SetActive(false);
        Time.timeScale = 0;
        DisablePlayerControl();
        if (AudioManager.instance != null)
        {
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
            muteToggle.isOn = PlayerPrefs.GetInt("IsMuted", 0) == 1;
            Debug.Log("Estamos Conectados a los sonidos");
        }
        gameOverScreen.SetActive(false);
        UpdateStateMeter();
    }
    void Update()
    {
        UpdateStateMeter();
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        menuUI.SetActive(false);
        optionUI.SetActive(false);
        creditsUI.SetActive(false);
        loreScreen.SetActive(false);
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
    public void OnMusicVolumeChanged(float volume)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetMusicVolume(volume);
            PlayerPrefs.SetFloat("MusicVolume", volume);
            Debug.Log("Estamos Conectados, podemos proceder a bajar el volumen de la musica");
        }
    }
    public void OnSFXVolumeChange(float volume)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetSFXVolume(volume);
            PlayerPrefs.SetFloat("SFXVolume", volume);
            Debug.Log("Estamos Conectados, podemos proceder a bajar el volumen de los SFX");
        }
    }
    public void OnMuteToggled(bool isMuted)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetMute(isMuted);
            PlayerPrefs.SetInt("IsMuted", isMuted ? 1 : 0);
            Debug.Log("Estamos Conectados, Mutear los sonidos");
        }
    }
    public void GoOptionMenu()
    {
        menuUI.SetActive(false);
        optionUI.SetActive(true);
    }
    public void BackToMainMenu()
    {
        menuUI.SetActive(true);
        optionUI.SetActive(false);
        creditsUI.SetActive(false);
    }
    public void GoCreditMenu()
    {
        menuUI.SetActive(false);
        creditsUI.SetActive(true);
    }
    public void UpdateStateMeter()
    {
        if (GameManager.Instance == null || stateMeter == null) return;
        Debug.Log("Aqui deberian cargar los estados");
        int parasiteLevel = GameManager.Instance.humanParasiteLevel;
        if (parasiteLevel < 4)
        {
            stateMeter.sprite = stateLow;
        } 
        else if (parasiteLevel >= 4 && parasiteLevel < 7)
        {
            stateMeter.sprite = stateMedium;
        }
        else
        {
            stateMeter.sprite = stateHigh;
        }
    }
    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void RestarGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.Instance.gameOver = false;
        gameOverScreen.SetActive(false);
    }
}
