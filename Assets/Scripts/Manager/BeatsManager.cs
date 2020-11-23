using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class BeatsManager : MonoBehaviour
{
    public static BeatsManager instance;

    //public AudioSource bgm;

    public bool isBossFight;

    public EventInstance bgmEvent;
    public string normalBGMEventPath = "event:/MX/BattleScene/Level1-Battle";
    public string boss1BGMEventPath = "event:/MX/BossFight/MX_Boss_Strange_Villa";
    public string boss2BGMEventPath = "event:/MX/BattleScene/Level1-Battle";
    public SongInfo bossSongInfo;
    public string boss1SongInfoPath;
    public string boss2SongInfoPath;

    public float beatsTime;//节拍时间间隔

    public GameObject beatsContainer;
    public List<GameObject> beatsTips = new List<GameObject>();//节拍物体列表 

    private int beatsIndex;
    private int totalIndex;
    private float lastAudioTime;

    private float[] normalBGMParameters = new float[4];
    private float bgmVolume;

    private bool isVolumeFading;

    private int isNeedSwitch = 0;//0 = not need, 1 = boss2

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
        if (!isBossFight)
        {
            bgmEvent = RuntimeManager.CreateInstance(normalBGMEventPath);
        }
        else
        {
            bgmEvent = RuntimeManager.CreateInstance(boss1BGMEventPath);
            bossSongInfo = new SongInfo();
            bossSongInfo.LoadFromPath(boss1SongInfoPath);
            beatsTime = (float)bossSongInfo.interval;
            //Debug.Log(bossSongInfo.length);
        }

        
        if (SettingManager.instance != null)
        {
            //bgm.volume = SettingManager.instance.overAllVolume;
            bgmEvent.setVolume(SettingManager.instance.overAllVolume);
            bgmVolume = SettingManager.instance.overAllVolume;
        }
        else
        {
            bgmEvent.setVolume(1);
            bgmVolume = 1;
        }
    }

    void Update()
    {
        if (!GameManager.instance.isPaused)
        {
            UpdateBeats();
            if (!isBossFight)
            {
                UpdateNormalBGMParameter();
            }
            else
            {

            }
            UpdateBGMVolume();
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
            //Debug.Log(totalIndex);
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
        if (isBossFight)
        {
            BeatBoss[] boss = FindObjectsOfType<BeatBoss>();
            for (int i = 0; i < boss.Length; i++)
            {
                if (boss[i].gameObject.activeSelf)
                {
                    boss[i].OnBeat(totalIndex);
                }
            }
        }
    }

    public void StartBeats()
    {
        beatsIndex = 0;
        beatsTips[beatsIndex].transform.localScale = new Vector3(2, 2, 2);
        totalIndex = 0;
        bgmEvent.start();
        if (!isBossFight)
        {
            bgmEvent.setTimelinePosition(148800);
            SetNormalBGMDefault();
        }
        else
        {
            bgmEvent.setTimelinePosition(0);
        }
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
        bgmEvent.getTimelinePosition(out tempMS);
        float bgmTime = (float)tempMS / 1000.0f;
        return bgmTime;
    }
    
    public void PauseBGM()
    {
        bgmEvent.setPaused(true);
    }

    public void ResumeBGM()
    {
        bgmEvent.setPaused(false);
    }

    public void StopBGM()
    {
        bgmEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void SetNormalBGMDefault()
    {
        bgmEvent.setParameterByName("GamePhase", 2);
        bgmEvent.setParameterByName("TimeNumReact", 5);
        bgmEvent.setParameterByName("LowHealth", 0);
        bgmEvent.setParameterByName("Combo", 0);
        normalBGMParameters[0] = 2;
        normalBGMParameters[1] = 5;
        normalBGMParameters[2] = 0;
        normalBGMParameters[3] = 0;
    }

    public void SetNormalBGMParameter(string name, float value)
    {
        if (name.Equals("GamePhase"))
        {
            //if(Mathf.Abs(normalBGMParameters[0] - value) > 1.1f)
            //{
            //    BGMVolumeFade();
            //}
            normalBGMParameters[0] = value;
        }
        if (name.Equals("TimeNumReact"))
        {
            //if (Mathf.Abs(normalBGMParameters[1] - value) > 1.1f)
            //{
            //    BGMVolumeFade();
            //}
            normalBGMParameters[1] = value;
        }
        if (name.Equals("LowHealth"))
        {
            //if (Mathf.Abs(normalBGMParameters[2] - value) > 1.1f)
            //{
            //    BGMVolumeFade();
            //}
            normalBGMParameters[2] = value;
        }
        if (name.Equals("Combo"))
        {
            //if (Mathf.Abs(normalBGMParameters[3] - value) > 1.1f)
            //{
            //    BGMVolumeFade();
            //}
            normalBGMParameters[3] = value;
        }
    }

    float GetBGMParameter(string name)
    {
        float result;
        bgmEvent.getParameterByName(name, out result);
        return result;
    }

    void UpdateNormalBGMParameter()
    {
        if(GetBGMParameter("GamePhase") != normalBGMParameters[0])
        {
            bgmEvent.setParameterByName("GamePhase", Mathf.Lerp(GetBGMParameter("GamePhase"), normalBGMParameters[0], 3.0f * Time.deltaTime));
        }
        if (GetBGMParameter("TimeNumReact") != normalBGMParameters[1])
        {
            bgmEvent.setParameterByName("TimeNumReact", Mathf.Lerp(GetBGMParameter("TimeNumReact"), normalBGMParameters[1], 3.0f * Time.deltaTime));
        }
        if (GetBGMParameter("LowHealth") != normalBGMParameters[2])
        {
            bgmEvent.setParameterByName("LowHealth", Mathf.Lerp(GetBGMParameter("LowHealth"), normalBGMParameters[2], 3.0f * Time.deltaTime));
        }
        if (GetBGMParameter("Combo") != normalBGMParameters[3])
        {
            bgmEvent.setParameterByName("Combo", Mathf.Lerp(GetBGMParameter("Combo"), normalBGMParameters[3], 3.0f * Time.deltaTime));
        }
    }


    public void SwitchToBoss1BGM()
    {

    }

    public void SwitchToBoss2BGM()
    {
        bgmEvent = RuntimeManager.CreateInstance(boss2BGMEventPath);
        bossSongInfo = new SongInfo();
        bossSongInfo.LoadFromPath(boss2SongInfoPath);
        beatsTime = (float)bossSongInfo.interval;
    }

    public void PlayBGM()
    {
        bgmEvent.start();
    }

    public void BGMVolumeFade()
    {
        isVolumeFading = true;
        bgmVolume = 0.2f;
    }

    void UpdateBGMVolume()
    {
        float volume;
        bgmEvent.getVolume(out volume);
        if(volume != bgmVolume)
        {
            bgmEvent.setVolume(Mathf.Lerp(volume, bgmVolume, 8.0f * Time.deltaTime));
            if(isVolumeFading && Mathf.Abs(volume - bgmVolume) <= 0.001f)
            {
                if (SettingManager.instance != null)
                {
                    bgmVolume = SettingManager.instance.overAllVolume;
                }
                else
                {
                    bgmVolume = 1;
                }
                isVolumeFading = false;
            }
        }
    }

    public float GetBoss1BGMLength()
    {
        SongInfo temp = new SongInfo();
        temp.LoadFromPath(boss1SongInfoPath);
        return (float)temp.interval * temp.length;
    }
}
