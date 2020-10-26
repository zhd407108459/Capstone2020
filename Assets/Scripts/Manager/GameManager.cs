using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;

    [Header("Pause Panel")]
    public GameObject pausePanel;
    public Button pausePanelResumeButton;
    public Button pausePanelMenuButton;

    [Header("Dead Panel")]
    public GameObject deadPanel;
    public Button deadPanelRestartButton;
    public Button deadPanelMenuButton;


    [HideInInspector] public bool isPaused;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        isPaused = false;

        HidePausePanel();

        pausePanelResumeButton.onClick.AddListener(PauseGame);
        pausePanelMenuButton.onClick.AddListener(BackToMenu);
        deadPanelRestartButton.onClick.AddListener(RestartCurrentBattle);
        deadPanelMenuButton.onClick.AddListener(BackToMenu);
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    ExitGame();
        //}
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    RestartGame();
        //}
    }

    public void PauseGame()
    {
        if (isPaused)
        {
            isPaused = false;
            BeatsManager.instance.bgm.UnPause();
            HidePausePanel();
        }
        else
        {
            isPaused = true;
            BeatsManager.instance.bgm.Pause();
            ShowPausePanel();
        }
    }

    public void PauseGame(bool pause)
    {
        if (!pause && isPaused)
        {
            isPaused = false;
            BeatsManager.instance.bgm.UnPause();
            HidePausePanel();
        }
        else if (pause && !isPaused)
        {
            isPaused = true;
            BeatsManager.instance.bgm.Pause();
            ShowPausePanel();
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    void RestartGame()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void PlayerDie()
    {
        isPaused = true;
        BeatsManager.instance.bgm.Pause();
        deadPanel.SetActive(true);
    }

    void RestartCurrentBattle()
    {
        isPaused = false;
        BeatsManager.instance.bgm.UnPause();
        GridManager.instance.RestartCurrentPhase();
        deadPanel.SetActive(false);
    }

    void ExitGame()
    {
        Application.Quit();
    }

    public void ShowPausePanel()
    {
        pausePanel.SetActive(true);
    }

    public void HidePausePanel()
    {
        pausePanel.SetActive(false);
    }
}
