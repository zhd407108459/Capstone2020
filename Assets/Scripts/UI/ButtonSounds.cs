using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using FMODUnity;

public class ButtonSounds : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public string hoverFX = "event:/FX/UI/UI-Select";
    public string clickFX = "event:/FX/UI/UI-Start";
    public string upFX = "";

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Enter");
        if(hoverFX != null || hoverFX != "")
        {
            RuntimeManager.PlayOneShot(hoverFX);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Exit");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Down");
        if (clickFX != null || clickFX != "")
        {
            RuntimeManager.PlayOneShot(clickFX);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (upFX != null || upFX != "")
        {
            RuntimeManager.PlayOneShot(upFX);
        }
    }
}