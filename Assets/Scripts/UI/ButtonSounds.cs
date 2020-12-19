using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using FMOD.Studio;
using FMODUnity;

public class ButtonSounds : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public string hoverFX = "event:/FX/UI/UI-Select";
    public string clickFX = "event:/FX/UI/UI-Start";
    public string upFX = "";

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Enter");
        if(hoverFX != null && hoverFX != "")
        {
            EventInstance buttonFX;
            buttonFX = RuntimeManager.CreateInstance(hoverFX);
            if (SettingManager.instance != null)
            {
                buttonFX.setVolume(SettingManager.instance.overAllVolume);
            }
            buttonFX.start();
            //RuntimeManager.PlayOneShot(hoverFX);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Exit");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Down");
        if (clickFX != null && clickFX != "")
        {
            EventInstance buttonFX;
            buttonFX = RuntimeManager.CreateInstance(clickFX);
            if (SettingManager.instance != null)
            {
                buttonFX.setVolume(SettingManager.instance.overAllVolume);
            }
            buttonFX.start();
            //RuntimeManager.PlayOneShot(clickFX);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (upFX != null && upFX != "")
        {
            EventInstance buttonFX;
            buttonFX = RuntimeManager.CreateInstance(upFX);
            if (SettingManager.instance != null)
            {
                buttonFX.setVolume(SettingManager.instance.overAllVolume);
            }
            buttonFX.start();
            //RuntimeManager.PlayOneShot(upFX);
        }
    }
}