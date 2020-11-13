using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class BeatsManager : MonoBehaviour
{
    public static BeatsManager instance;

    public AudioSource bgm;

    public EventInstance normalBGMEvent;

    public float beatsTime;//节拍时间间隔

    public GameObject beatsContainer;
    public List<GameObject> beatsTips = new List<GameObject>();//节拍物体列表 

    private int beatsIndex;
    private int totalIndex;
    private float lastAudioTime;


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
        normalBGMEvent = RuntimeManager.CreateInstance("event:/MX/BattleScene/Level1-Battle");
        
        if (SettingManager.instance != null)
        {
            //bgm.volume = SettingManager.instance.overAllVolume;
            normalBGMEvent.setVolume(SettingManager.instance.overAllVolume);
        }
    }

    void Update()
    {
        if (!GameManager.instance.isPaused)
        {
            UpdateBeats();
        }
        lastAudioTime = GetBgmTime();
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
        float bgmTime = GetBgmTime();
        if (bgmTime < lastAudioTime)
        {
            totalIndex = 0;
            beatsIndex = 0;
            //Debug.Log("Loop");
        }
        for (int i = 0; i < beatsTips.Count; i++)
        {
            beatsTips[i].transform.localScale = Vector3.Lerp(beatsTips[i].transform.localScale, new Vector3(1, 1, 1), 15.0f * Time.deltaTime);
        }

        while (bgmTime >= beatsTime * totalIndex)
        {
            //Debug.Log((int)(bgm.time / beatsTime));
            //Debug.Log(beatsIndex);
            //变化节拍结束点大小
            beatsTips[beatsIndex].transform.localScale = new Vector3(2, 2, 2);
            //Debug.Log("Beat!");
            CallOtherMethods();
            totalIndex++;
            beatsIndex++;
            if (beatsIndex >= beatsTips.Count)
            {
                beatsIndex = 0;
            }

        }


    }

    void CallOtherMethods()
    {
        RhythmObject[] objects = FindObjectsOfType<RhythmObject>();
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].gameObject.activeSelf)
            {
                objects[i].OnBeat(beatsIndex);
            }
        }
    }

    public void StartBeats()
    {
        beatsIndex = 0;
        beatsTips[beatsIndex].transform.localScale = new Vector3(2, 2, 2);
        totalIndex = 0;
        normalBGMEvent.start();
        normalBGMEvent.setTimelinePosition(148800);
        SetNormalBGMDefault();
        lastAudioTime = GetBgmTime();
        //bgm.Play();
    }

    public float GetTimeToNearestBeat()
    {
        float bgmTime = GetBgmTime();
        return (bgmTime - beatsTime * (totalIndex - 1)) > Mathf.Abs(beatsTime * totalIndex - bgmTime) ? Mathf.Abs(beatsTime * totalIndex - bgmTime) : (bgmTime - beatsTime * (totalIndex - 1));
    }

    public int GetIndexToNearestBeat()
    {
        float bgmTime = GetBgmTime();
        if ((bgmTime - beatsTime * (totalIndex - 1)) > Mathf.Abs(beatsTime * totalIndex - bgmTime))
        {
            return beatsIndex;
        }
        else
        {
            return beatsIndex > 0 ? beatsIndex - 1 : (beatsTips.Count - 1);
        }
    }

    public float GetTimeToLastBeat()
    {
        float bgmTime = GetBgmTime();
        return (bgmTime - beatsTime * (totalIndex - 1));
    }

    public float GetTimeToNextBeat()
    {
        float bgmTime = GetBgmTime();
        return Mathf.Abs(beatsTime * totalIndex - bgmTime);
    }

    public float GetBgmTime()
    {
        int tempMS;
        normalBGMEvent.getTimelinePosition(out tempMS);
        float bgmTime = (float)tempMS / 1000.0f;
        return bgmTime;
    }
    
    public void PauseBGM()
    {
        normalBGMEvent.setPaused(true);
    }

    public void ResumeBGM()
    {
        normalBGMEvent.setPaused(false);
    }

    public void StopBGM()
    {
        normalBGMEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void SetNormalBGMDefault()
    {
        normalBGMEvent.setParameterByName("GamePhase", 2);
        normalBGMEvent.setParameterByName("TimeNumReact", 5);
        normalBGMEvent.setParameterByName("LowHealth", 0);
        normalBGMEvent.setParameterByName("Combo", 0);
    }

    public void SetNormalBGMParameter(string name, float value)
    {
        normalBGMEvent.setParameterByName(name, value);
    }
}
