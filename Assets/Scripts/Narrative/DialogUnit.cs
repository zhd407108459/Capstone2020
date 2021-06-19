using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using FMOD.Studio;
using FMODUnity;

public class DialogUnit : MonoBehaviour
{
    public Text textContent;
    public List<string> textInLanguages = new List<string>();
    public List<Font> fonts = new List<Font>();
    public float typingInterval = 0.01f;
    public Transform targetPosition;
    public bool isFollowTarget;
    public UnityEvent startEvents;

    public enum TypingFX {
        None,
        Vigorus,
        Marty,
        N
    }
    public TypingFX typingFX;

    private string originText;
    private int typingIndex;
    private Coroutine typingCoroutine;
    private EventInstance typingFXEvent;

    private string vigorusTypingFXPath = "event:/FX/VO/VO-Vigorus";
    private string martyTypingFXPath = "event:/FX/VO/VO-Marty";
    private string nTypingFXPath = "event:/FX/VO/VO-N";


    void Start()
    {
    }

    void Update()
    {
        if (isFollowTarget)
        {
            if (targetPosition != null)
            {
                transform.position = targetPosition.position;
            }
        }
    }
    public void Show()
    {
        if(targetPosition != null)
        {
            transform.position = targetPosition.position;
        }
        if(SettingManager.instance == null || textInLanguages.Count < SettingManager.instance.language)
        {
            originText = textContent.text;
        }
        else
        {
            originText = textInLanguages[SettingManager.instance.language];
            if(fonts.Count >= SettingManager.instance.language)
            {
                textContent.font = fonts[SettingManager.instance.language];
            }
        }
        textContent.text = "";
        typingIndex = 0;
        if(typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(Type());
        startEvents.Invoke();
        if(typingFX == TypingFX.Vigorus)
        {
            typingFXEvent = RuntimeManager.CreateInstance(vigorusTypingFXPath);
            if (SettingManager.instance != null)
            {
                typingFXEvent.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume);
            }
            typingFXEvent.start();
        }
        else if (typingFX == TypingFX.Marty)
        {
            typingFXEvent = RuntimeManager.CreateInstance(martyTypingFXPath);
            if (SettingManager.instance != null)
            {
                typingFXEvent.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume);
            }
            typingFXEvent.start();
        }
        else if (typingFX == TypingFX.N)
        {
            typingFXEvent = RuntimeManager.CreateInstance(nTypingFXPath);
            if (SettingManager.instance != null)
            {
                typingFXEvent.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume);
            }
            typingFXEvent.start();
        }
    }

    public void ImmediateShow()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingIndex = originText.Length;
        textContent.text = originText;
        if (typingFXEvent.isValid())
        {
            typingFXEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }

    IEnumerator Type()
    {
        yield return new WaitForSeconds(typingInterval);
        if(typingIndex < originText.Length)
        {
            textContent.text += originText.Substring(typingIndex, 1);
        }
        if (typingIndex < originText.Length - 1)
        {
            typingIndex++;
            if (typingIndex == originText.Length - 1)
            {

                if (typingFXEvent.isValid())
                {
                    typingFXEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                }
            }
            StartCoroutine(Type());
        }
    }

    public void StopTpyingFX()
    {
        if (typingFXEvent.isValid())
        {
            typingFXEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }

    public bool IsPlayFinished()
    {
        return typingIndex >= originText.Length - 1;
    }
}
