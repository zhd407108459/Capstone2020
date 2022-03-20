using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class FMODEventManager : MonoBehaviour
{

    public static FMODEventManager instance;

    public List<EventInstance> events = new List<EventInstance>();

    public List<string> eventPathes = new List<string>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        LoadAllEvents();
    }

    void Update()
    {
        
    }

    public void LoadAllEvents()
    {
        events.Clear();
        for (int i = 0; i < eventPathes.Count; i++)
        {
            EventInstance temp = RuntimeManager.CreateInstance(eventPathes[i]);
            events.Add(temp);
        }
    }

    public EventInstance GetEvent(int index)
    {
        return events[index];
    }
}
