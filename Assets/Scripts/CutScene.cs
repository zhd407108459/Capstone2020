using System.Collections;
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

    private float timer;
    private float lastTimer;
    private bool isPlaying = false;

    void Update()
    {
        if (isPlaying)
        {
            timer += Time.deltaTime;

            for(int i = 0; i < events.Count; i++)
            {
                if(lastTimer <= triggerTimes[i] && triggerTimes[i] <= timer)
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
    }

    public void Stop()
    {
        isPlaying = false;
        for (int i = 0; i < hideObjects.Count; i++)
        {
            hideObjects[i].SetActive(true);
        }
        for (int i = 0; i < showObjects.Count; i++)
        {
            showObjects[i].SetActive(false);
        }
        GameManager.instance.isCutScene = false;
    }
}
