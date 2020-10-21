using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;


    public GameObject pausePanel;
    public Button resumeButton;

    public GameObject deadPanel;
    public Button deadPanelRestartButton;


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

        resumeButton.onClick.AddListener(PauseGame);
        deadPanelRestartButton.onClick.AddListener(RestartCurrentBattle);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
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
