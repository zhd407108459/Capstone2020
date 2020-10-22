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
        StartBeats();
    }

    void Update()
    {
        if (!GameManager.instance.isPaused)
        {
            UpdateBeats();
        }
        lastAudioTime = bgm.time;
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
        
        if (bgm.time < lastAudioTime)
        {
            totalIndex = 0;
            beatsIndex = 0;
            //Debug.Log("Loop");
        }
        for (int i = 0; i < beatsTips.Count; i++)
        {
            beatsTips[i].transform.localScale = Vector3.Lerp(beatsTips[i].transform.localScale, new Vector3(1, 1, 1), 15.0f * Time.deltaTime);
        }

        while (bgm.time >= beatsTime * totalIndex)
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
        lastAudioTime = bgm.time;
        bgm.Play();
    }

    public float GetTimeToNearestBeat()
    {
        return (bgm.time - beatsTime * (totalIndex - 1)) > Mathf.Abs(beatsTime * totalIndex - bgm.time) ? Mathf.Abs(beatsTime * totalIndex - bgm.time) : (bgm.time - beatsTime * (totalIndex - 1));
    }

    public int GetIndexToNearestBeat()
    {
        if((bgm.time - beatsTime * (totalIndex - 1)) > Mathf.Abs(beatsTime * totalIndex - bgm.time))
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
        return (bgm.time - beatsTime * (totalIndex - 1));
    }

    public float GetTimeToNextBeat()
    {
        return Mathf.Abs(beatsTime * totalIndex - bgm.time);
    }
}
