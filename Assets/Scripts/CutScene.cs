﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CutScene : MonoBehaviour
{
    public float time;
    public List<UnityEvent> events = new List<UnityEvent>();
    public List<float> triggerTimes = new List<float>();
    public List<GameObject> showObjects = new List<GameObject>();
    public List<GameObject> hideObjects = new List<GameObject>();

    public bool hasSecondaryEvents = false;
    public float secondaryTime;


    public UnityEvent skipEvent;
    public GameObject skipTip;

    public UnityEvent secondarySkipEvent;


    private float timer;
    private float lastTimer;
    private bool isPlaying = false;
    private bool isSkipTipOn = false;

    void Update()
    {
        if (isPlaying)
        {
            if ((Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) && isSkipTipOn)
            {
                if (hasSecondaryEvents)
                {
                    if(timer < secondaryTime)
                    {
                        timer = secondaryTime;
                        lastTimer = timer;
                        skipEvent.Invoke();
                    }
                    else
                    {
                        secondarySkipEvent.Invoke();
                        Stop();
                    }
                }
                else
                {
                    skipEvent.Invoke();
                    Stop();
                }
            }
            else if (Input.anyKeyDown && !isSkipTipOn)
            {
                isSkipTipOn = true;
                skipTip.SetActive(true);
            }


            timer += Time.deltaTime;

            for(int i = 0; i < events.Count; i++)
            {
                if(lastTimer <= triggerTimes[i] && triggerTimes[i] <= timer && triggerTimes[i] > 0)
                {
                    events[i].Invoke();
                }
            }

            if(timer >= time)
            {
                Stop();
            }
            lastTimer = timer;
        }
    }

    public void Invoke()
    {
        isPlaying = true;
        isSkipTipOn = false;
        timer = 0;
        lastTimer = 0;
        for(int i = 0; i < hideObjects.Count; i++)
        {
            hideObjects[i].SetActive(false);
        }
        for (int i = 0; i < showObjects.Count; i++)
        {
            showObjects[i].SetActive(true);
        }
        GameManager.instance.isCutScene = true;
        skipTip.SetActive(false);
        for (int i = 0; i < events.Count; i++)
        {
            if (triggerTimes[i] == 0)
            {
                events[i].Invoke();
            }
        }
    }

    public void Stop()
    {
        isPlaying = false;
        isSkipTipOn = false;
        for (int i = 0; i < hideObjects.Count; i++)
        {
            hideObjects[i].SetActive(true);
        }
        for (int i = 0; i < showObjects.Count; i++)
        {
            showObjects[i].SetActive(false);
        }
        GameManager.instance.isCutScene = false;
        skipTip.SetActive(false);
    }
}
