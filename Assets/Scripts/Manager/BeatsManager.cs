using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatsManager : MonoBehaviour
{
    public static BeatsManager instance;

    public AudioSource bgm;

    public float beatsTime;//节拍时间间隔

    public GameObject beatsContainer;
    public List<GameObject> beatsTips = new List<GameObject>();//节拍物体列表 

    [HideInInspector] public double beatsTimer;//节拍计时器
    private double lastBgmTime;
    private double deltaTime;
    private int beatsIndex;


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
        StartBeats();
    }

    void Update()
    {
        deltaTime = AudioSettings.dspTime - lastBgmTime;
        if (!GameManager.instance.isPaused)
        {
            UpdateBeats();
        }
        lastBgmTime = AudioSettings.dspTime;
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            GameManager.instance.PauseGame(true);
        }
    }


    //Update节拍
    void UpdateBeats()
    {
        beatsTimer += deltaTime;

        for(int i = 0; i < beatsTips.Count; i++)
        {
            beatsTips[i].transform.localScale = Vector3.Lerp(beatsTips[i].transform.localScale, new Vector3(1, 1, 1), 15.0f * (float)deltaTime);
        }

        while (beatsTimer >= beatsTime)
        {
            //Debug.Log(beatsTimer);
            beatsTimer -= beatsTime;
            //变化节拍结束点大小
            beatsTips[beatsIndex].transform.localScale = new Vector3(2, 2, 2);
            beatsIndex++;
            if(beatsIndex >= beatsTips.Count)
            {
                beatsIndex = 0;
            }
            //Debug.Log("Beat!");
            CallOtherMethods();

        }


    }

    void CallOtherMethods()
    {
        RhythmObject[] enemies = FindObjectsOfType<RhythmObject>();
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].gameObject.activeSelf)
            {
                enemies[i].OnBeat();
            }
        }
    }

    public void StartBeats()
    {
        beatsIndex = 0;
        beatsTimer = 0;
        lastBgmTime = AudioSettings.dspTime;
    }

    public float GetTimeToNearestBeat()
    {
        return (float)beatsTimer > Mathf.Abs((float)beatsTimer - beatsTime) ? Mathf.Abs((float)beatsTimer - beatsTime) : (float)beatsTimer;
    }

    public float GetTimeToLastBeat()
    {
        return (float)beatsTimer;
    }

    public float GetTimeToNextBeat()
    {
        return Mathf.Abs((float)beatsTimer - beatsTime);
    }
}
