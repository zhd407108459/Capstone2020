using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FMOD.Studio;
using FMODUnity;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;

    public Button pauseButton;
    [Header("Pause Panel")]
    public GameObject pausePanel;
    public Button pausePanelResumeButton;
    public Button pausePanelMenuButton;
    public Button pausePanelRestartButton;

    [Header("Dead Panel")]
    public GameObject deadPanel;
    public Button deadPanelRestartButton;
    public Button deadPanelMenuButton;

    public string deadBGMEventPath = "event:/MX/Character/MX_Character_Battle_Lost";
    public EventInstance deadBGMEvent;

    [HideInInspector] public bool isPaused;
    [HideInInspector] public bool isGameEnd;
    [HideInInspector] public bool isCutScene;



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

        pauseButton.onClick.AddListener(PauseGame);

        pausePanelResumeButton.onClick.AddListener(PauseGame);
        pausePanelMenuButton.onClick.AddListener(BackToMenu);
        pausePanelRestartButton.onClick.AddListener(RestartCurrentBattle);
        pausePanelRestartButton.onClick.AddListener(HidePausePanel);
        if(deadPanelRestartButton != null)
        {
            deadPanelRestartButton.onClick.AddListener(RestartCurrentBattle);
        }
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
        if (isGameEnd || deadPanel.activeSelf || isCutScene)
        {
            return;
        }
        if (isPaused)
        {
            isPaused = false;
            //BeatsManager.instance.bgm.UnPause();
            BeatsManager.instance.ResumeBGM();
            HidePausePanel();
            pauseButton.gameObject.SetActive(true);
        }
        else
        {
            isPaused = true;
            //BeatsManager.instance.bgm.Pause();
            BeatsManager.instance.PauseBGM();
            ShowPausePanel();
            pauseButton.gameObject.SetActive(false);
        }
    }

    public void PauseGame(bool pause)
    {
        if (isGameEnd || deadPanel.activeSelf || isCutScene)
        {
            return;
        }
        if (!pause && isPaused)
        {
            isPaused = false;
            //BeatsManager.instance.bgm.UnPause();
            BeatsManager.instance.ResumeBGM();
            HidePausePanel();
            pauseButton.gameObject.SetActive(true);
        }
        else if (pause && !isPaused)
        {
            isPaused = true;
            //BeatsManager.instance.bgm.Pause();
            BeatsManager.instance.PauseBGM();
            ShowPausePanel();
            pauseButton.gameObject.SetActive(false);
        }
    }

    public void BackToMenu()
    {
        BeatsManager.instance.StopBGM();
        SceneManager.LoadScene(0);
        if (deadBGMEvent.isValid())
        {
            deadBGMEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
        if(SettingManager.instance != null)
        {
            SettingManager.instance.ClearSkillSelection();
        }
        GridManager.instance.setAbilities.StopBossPreBGM();
    }

    void RestartGame()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void LoadNextScene()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        if(SceneManager.sceneCountInBuildSettings - 1 <= scene)
        {
            return;
        }
        SceneManager.LoadScene(scene + 1, LoadSceneMode.Single);
        BeatsManager.instance.StopBGM();
        if(SettingManager.instance != null)
        {
            SettingManager.instance.targetPhase = 0;
        }
        if (deadBGMEvent.isValid())
        {
            deadBGMEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
        GridManager.instance.setAbilities.StopBossPreBGM();
    }

    public void PlayerDie()
    {
        isPaused = true;
        BeatsManager.instance.PauseBGM();
        deadPanel.SetActive(true);
        if (deadBGMEventPath != null && deadBGMEventPath != "")
        {
            deadBGMEvent = RuntimeManager.CreateInstance(deadBGMEventPath);
            if (SettingManager.instance != null)
            {
                deadBGMEvent.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.musicVolume);
            }
            deadBGMEvent.start();
        }
    }

    void RestartCurrentBattle()
    {
        GridManager.instance.setAbilities.StopBossPreBGM();
        isPaused = false;
        BeatsManager.instance.ResumeBGM();
        GridManager.instance.RestartCurrentPhase();
        deadPanel.SetActive(false);
        if(deadBGMEvent.isValid())
        {
            deadBGMEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
        pauseButton.gameObject.SetActive(true);
    }

    void ExitGame()
    {
        Application.Quit();
        if (deadBGMEvent.isValid())
        {
            deadBGMEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
        if (SettingManager.instance != null)
        {
            SettingManager.instance.ClearSkillSelection();
        }
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
