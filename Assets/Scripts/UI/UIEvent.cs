using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UIEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent pointerEnterEvent;
    public UnityEvent pointerExitEvent;
    public UnityEvent pointerDownEvent;
    public UnityEvent pointerUpEvent;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        pointerEnterEvent.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pointerExitEvent.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDownEvent.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerUpEvent.Invoke();
    }
}
