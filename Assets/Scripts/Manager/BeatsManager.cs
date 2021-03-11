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

    public float parameterSwitchSpeed;

    public EventInstance bgmEvent;
    public int normalBGMStartOffset = 148800;
    public string normalBGMEventPath = "event:/MX/BattleScene/Level1-Battle";
    public string boss1BGMEventPath = "event:/MX/BossFight/MX_Boss_Strange_Villa";
    public string boss2BGMEventPath = "event:/MX/BattleScene/Level1-Battle";
    public SongInfo bossSongInfo;
    public string boss1EasySongInfoPath;
    public string boss1NormalSongInfoPath;
    public string boss1HardSongInfoPath;
    public string boss2EasySongInfoPath;
    public string boss2NormalSongInfoPath;
    public string boss2HardSongInfoPath;

    public float beatsTime;//节拍时间间隔

    public GameObject beatsContainer;
    public List<GameObject> beatsTips = new List<GameObject>();//节拍物体列表 

    private int beatsIndex;
    private int totalIndex;
    private float lastAudioTime;

    private float[] normalBGMParameters = new float[5];
    private float[] lastNormalBGMParameters = new float[5];
    private float[] currentNormalBGMParameters = new float[5];
    private float bgmVolume;

    private bool isVolumeFading;

    private EventDescription description;
    private int songLength;

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
            if (SettingManager.instance != null)
            {
                if (SettingManager.instance.difficulty == 0)
                {
                    bossSongInfo.LoadFromPath(boss1EasySongInfoPath);
                }
                if (SettingManager.instance.difficulty == 1)
                {
                    bossSongInfo.LoadFromPath(boss1NormalSongInfoPath);
                }
                if (SettingManager.instance.difficulty == 2)
                {
                    bossSongInfo.LoadFromPath(boss1HardSongInfoPath);
                }
            }
            else
            {
                bossSongInfo.LoadFromPath(boss1NormalSongInfoPath);
            }
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
                UpdateNormalBGMParameters();
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

        int pos;
        bgmEvent.getTimelinePosition(out pos);
        //Debug.Log(pos + "," + songLength);
        if (bgmTime < lastAudioTime)
        {
            if (pos >= songLength - 400)
            {
                totalIndex = 0;
                beatsIndex = 0;
            }
            else
            {
                bgmTime = lastAudioTime;
            }
            //Debug.Log("Loop");
        }
        if(bgmTime < beatsTime && totalIndex >= 2)
        {
            totalIndex = 0;
            beatsIndex = 0;
        }
        for (int i = 0; i < beatsTips.Count; i++)
        {
            beatsTips[i].transform.localScale = Vector3.Lerp(beatsTips[i].transform.localScale, new Vector3(1, 1, 1), 15.0f * Time.deltaTime);
        }
        //Debug.Log(bgmTime + "," + (beatsTime * (totalIndex + 0.5f)).ToString());
        if (bgmTime >= beatsTime * (totalIndex - 0.5f))
        {
            CallOtherSemiBeatMethods();
        }
        Debug.Log("Time: " + bgmTime + " Last Time: " + lastAudioTime + ", Index: " + totalIndex + ", bIndex: " + beatsIndex + ", SongLength: " + songLength + ", Position: " + pos);
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

    void CallOtherSemiBeatMethods()
    {
        RhythmObject[] objects = FindObjectsOfType<RhythmObject>();
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].gameObject.activeSelf)
            {
                objects[i].OnSemiBeat(beatsIndex);
            }
        }
    }

    void CallOtherMethods()
    {
        GridManager.instance.OnBeat(beatsIndex);
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
            bgmEvent.setTimelinePosition(normalBGMStartOffset);
            totalIndex = 254;
            SetNormalBGMDefault();
        }
        else
        {
            bgmEvent.setTimelinePosition(0);
        }
        lastAudioTime = GetBgmTime();
        bgmEvent.getDescription(out description);
        description.getLength(out songLength);
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
        bgmEvent.setParameterByName("Debuff", 0);
        normalBGMParameters[0] = 2;
        normalBGMParameters[1] = 5;
        normalBGMParameters[2] = 0;
        normalBGMParameters[3] = 0;
        normalBGMParameters[4] = 0;
        lastNormalBGMParameters[0] = 2;
        lastNormalBGMParameters[1] = 5;
        lastNormalBGMParameters[2] = 0;
        lastNormalBGMParameters[3] = 0;
        lastNormalBGMParameters[4] = 0;
        currentNormalBGMParameters[0] = 2;
        currentNormalBGMParameters[1] = 5;
        currentNormalBGMParameters[2] = 0;
        currentNormalBGMParameters[3] = 0;
        currentNormalBGMParameters[4] = 0;
    }

    public void SetNormalBGMParameter(string name, float value)
    {
        if (name.Equals("GamePhase"))
        {
            //if(Mathf.Abs(normalBGMParameters[0] - value) > 1.1f)
            //{
            //    BGMVolumeFade();
            //}
            lastNormalBGMParameters[0] = GetBGMParameter("GamePhase");
            normalBGMParameters[0] = value;
        }
        if (name.Equals("TimeNumReact"))
        {
            //if (Mathf.Abs(normalBGMParameters[1] - value) > 1.1f)
            //{
            //    BGMVolumeFade();
            //}
            lastNormalBGMParameters[1] = GetBGMParameter("TimeNumReact");
            normalBGMParameters[1] = value;
        }
        if (name.Equals("LowHealth"))
        {
            //if (Mathf.Abs(normalBGMParameters[2] - value) > 1.1f)
            //{
            //    BGMVolumeFade();
            //}
            lastNormalBGMParameters[2] = GetBGMParameter("LowHealth");
            normalBGMParameters[2] = value;
        }
        if (name.Equals("Combo"))
        {
            //if (Mathf.Abs(normalBGMParameters[3] - value) > 1.1f)
            //{
            //    BGMVolumeFade();
            //}
            lastNormalBGMParameters[3] = GetBGMParameter("Combo");
            normalBGMParameters[3] = value;
        }
        if (name.Equals("Debuff"))
        {
            lastNormalBGMParameters[4] = GetBGMParameter("Debuff");
            normalBGMParameters[4] = value;
        }
    }

    public void SetNormalBGMParameterImmediately(string name, float value)
    {
        if (name.Equals("GamePhase"))
        {
            //if(Mathf.Abs(normalBGMParameters[0] - value) > 1.1f)
            //{
            //    BGMVolumeFade();
            //}
            lastNormalBGMParameters[0] = value;
            currentNormalBGMParameters[0] = value;
            normalBGMParameters[0] = value;
            bgmEvent.setParameterByName("GamePhase", value);
        }
        if (name.Equals("TimeNumReact"))
        {
            //if (Mathf.Abs(normalBGMParameters[1] - value) > 1.1f)
            //{
            //    BGMVolumeFade();
            //}
            lastNormalBGMParameters[1] = value;
            currentNormalBGMParameters[1] = value;
            normalBGMParameters[1] = value;
            bgmEvent.setParameterByName("TimeNumReact", value);
        }
        if (name.Equals("LowHealth"))
        {
            //if (Mathf.Abs(normalBGMParameters[2] - value) > 1.1f)
            //{
            //    BGMVolumeFade();
            //}
            lastNormalBGMParameters[2] = value;
            currentNormalBGMParameters[2] = value;
            normalBGMParameters[2] = value;
            bgmEvent.setParameterByName("LowHealth", value);
        }
        if (name.Equals("Combo"))
        {
            //if (Mathf.Abs(normalBGMParameters[3] - value) > 1.1f)
            //{
            //    BGMVolumeFade();
            //}
            lastNormalBGMParameters[3] = value;
            currentNormalBGMParameters[3] = value;
            normalBGMParameters[3] = value;
            bgmEvent.setParameterByName("Combo", value);
        }
        if (name.Equals("Debuff"))
        {
            lastNormalBGMParameters[4] = value;
            currentNormalBGMParameters[4] = value;
            normalBGMParameters[4] = value;
            bgmEvent.setParameterByName("Debuff", value);
        }
    }

    float GetBGMParameter(string name)
    {
        float result;
        bgmEvent.getParameterByName(name, out result);
        return result;
    }

    void UpdateNormalBGMParameters()
    {
        UpdateNormalBGMParameter("GamePhase", 0);
        UpdateNormalBGMParameter("TimeNumReact", 1);
        UpdateNormalBGMParameter("LowHealth", 2);
        UpdateNormalBGMParameter("Combo", 3);
        UpdateNormalBGMParameter("Debuff", 4);
        //if (GetBGMParameter("GamePhase") != normalBGMParameters[0])
        //{
        //    if(GetBGMParameter("GamePhase") <= lastNormalBGMParameters[0] + 0.5f && GetBGMParameter("GamePhase") > lastNormalBGMParameters[0])
        //    {
        //        bgmEvent.setParameterByName("GamePhase", GetBGMParameter("GamePhase") + parameterSwitchSpeed * Time.deltaTime);
        //        if(GetBGMParameter("GamePhase") >= lastNormalBGMParameters[0] + 0.5f)
        //        {
        //            bgmEvent.setParameterByName("GamePhase", normalBGMParameters[0] + 0.5f);
        //        }
        //    }
        //    if(GetBGMParameter("GamePhase") <= normalBGMParameters[0] + 0.5f && GetBGMParameter("GamePhase") > normalBGMParameters[0])
        //    {
        //        bgmEvent.setParameterByName("GamePhase", GetBGMParameter("GamePhase") - parameterSwitchSpeed * Time.deltaTime);
        //        if (GetBGMParameter("GamePhase") <= normalBGMParameters[0])
        //        {
        //            bgmEvent.setParameterByName("GamePhase", normalBGMParameters[0]);
        //            lastNormalBGMParameters[0] = normalBGMParameters[0];
        //        }
        //    }
        //    //bgmEvent.setParameterByName("GamePhase", Mathf.Lerp(GetBGMParameter("GamePhase"), normalBGMParameters[0], 3.0f * Time.deltaTime));
        //}
        //if (GetBGMParameter("TimeNumReact") != normalBGMParameters[1])
        //{
        //    bgmEvent.setParameterByName("TimeNumReact", Mathf.Lerp(GetBGMParameter("TimeNumReact"), normalBGMParameters[1], 3.0f * Time.deltaTime));
        //}
        //if (GetBGMParameter("LowHealth") != normalBGMParameters[2])
        //{
        //    bgmEvent.setParameterByName("LowHealth", Mathf.Lerp(GetBGMParameter("LowHealth"), normalBGMParameters[2], 3.0f * Time.deltaTime));
        //}
        //if (GetBGMParameter("Combo") != normalBGMParameters[3])
        //{
        //    bgmEvent.setParameterByName("Combo", Mathf.Lerp(GetBGMParameter("Combo"), normalBGMParameters[3], 3.0f * Time.deltaTime));
        //}
        //if (GetBGMParameter("GamePhase") != normalBGMParameters[0])
        //{
        //    bgmEvent.setParameterByName("GamePhase",normalBGMParameters[0]);
        //}
        //if (GetBGMParameter("TimeNumReact") != normalBGMParameters[1])
        //{
        //    bgmEvent.setParameterByName("TimeNumReact", normalBGMParameters[1]);
        //}
        //if (GetBGMParameter("LowHealth") != normalBGMParameters[2])
        //{
        //    bgmEvent.setParameterByName("LowHealth", normalBGMParameters[2]);
        //}
        //if (GetBGMParameter("Combo") != normalBGMParameters[3])
        //{
        //    bgmEvent.setParameterByName("Combo", normalBGMParameters[3]);
        //}
    }

    void UpdateNormalBGMParameter(string name, int index)
    {
        if (lastNormalBGMParameters[index] != normalBGMParameters[index])
        {
            if (currentNormalBGMParameters[index] <= lastNormalBGMParameters[index] + 0.5f && currentNormalBGMParameters[index] >= lastNormalBGMParameters[index])
            {
                currentNormalBGMParameters[index] += parameterSwitchSpeed * Time.deltaTime;
                if (currentNormalBGMParameters[index] >= lastNormalBGMParameters[index] + 0.5f)
                {
                    currentNormalBGMParameters[index] = normalBGMParameters[index] + 0.5f;
                }
            }
            if (currentNormalBGMParameters[index] <= normalBGMParameters[index] + 0.5f && currentNormalBGMParameters[index] >= normalBGMParameters[index])
            {
                currentNormalBGMParameters[index] -= parameterSwitchSpeed * Time.deltaTime;
                if (currentNormalBGMParameters[index] <= normalBGMParameters[index])
                {
                    currentNormalBGMParameters[index] = normalBGMParameters[index];
                    lastNormalBGMParameters[index] = normalBGMParameters[index];
                }
            }
            bgmEvent.setParameterByName(name, currentNormalBGMParameters[index]);
            //Debug.Log(lastNormalBGMParameters[0] + ", " + normalBGMParameters[0] + ": " + GetBGMParameter(name));
            //if (GetBGMParameter(name) <= lastNormalBGMParameters[index] + 0.5f && GetBGMParameter(name) >= lastNormalBGMParameters[index])
            //{
            //    float temp = GetBGMParameter(name) + parameterSwitchSpeed * Time.deltaTime;
            //    Debug.Log(temp + ": " + GetBGMParameter(name));
            //    bgmEvent.setParameterByName(name, temp);
            //    Debug.Log(temp + ": " + GetBGMParameter(name));
            //    if (GetBGMParameter(name) >= lastNormalBGMParameters[index] + 0.5f)
            //    {
            //        bgmEvent.setParameterByName(name, normalBGMParameters[index] + 0.5f);
            //    }
            //}
            //if (GetBGMParameter(name) <= normalBGMParameters[index] + 0.5f && GetBGMParameter(name) >= normalBGMParameters[index])
            //{
            //    float target = GetBGMParameter(name) - parameterSwitchSpeed * Time.deltaTime;
            //    bgmEvent.setParameterByName(name, target);
            //    if (GetBGMParameter(name) <= normalBGMParameters[index])
            //    {
            //        bgmEvent.setParameterByName(name, normalBGMParameters[index]);
            //        lastNormalBGMParameters[index] = normalBGMParameters[index];
            //    }
            //}
            //bgmEvent.setParameterByName("GamePhase", Mathf.Lerp(GetBGMParameter("GamePhase"), normalBGMParameters[0], 3.0f * Time.deltaTime));
        }
        //if (index == 1)
        //{
        //    Debug.Log(GetBGMParameter(name));
        //}
    }

    public void SwitchToBoss1BGM()
    {

    }

    public void SwitchToBoss2BGM()
    {
        bgmEvent = RuntimeManager.CreateInstance(boss2BGMEventPath);
        bossSongInfo = new SongInfo();
        if (SettingManager.instance != null)
        {
            if (SettingManager.instance.difficulty == 0)
            {
                bossSongInfo.LoadFromPath(boss2EasySongInfoPath);
            }
            if (SettingManager.instance.difficulty == 1)
            {
                bossSongInfo.LoadFromPath(boss2NormalSongInfoPath);
            }
            if (SettingManager.instance.difficulty == 2)
            {
                bossSongInfo.LoadFromPath(boss2HardSongInfoPath);
            }
        }
        else
        {
            bossSongInfo.LoadFromPath(boss2NormalSongInfoPath);
        }
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
        if (SettingManager.instance != null)
        {
            if (SettingManager.instance.difficulty == 0)
            {
                temp.LoadFromPath(boss1EasySongInfoPath);
            }
            if (SettingManager.instance.difficulty == 1)
            {
                temp.LoadFromPath(boss1NormalSongInfoPath);
            }
            if (SettingManager.instance.difficulty == 2)
            {
                temp.LoadFromPath(boss1HardSongInfoPath);
            }
        }
        else
        {
            temp.LoadFromPath(boss1NormalSongInfoPath);
        }
        return (float)temp.interval * temp.length;
    }
}
