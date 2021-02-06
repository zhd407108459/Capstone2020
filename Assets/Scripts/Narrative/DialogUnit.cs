using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogUnit : MonoBehaviour
{
    public Text textContent;
    public float typingInterval = 0.01f;
    public Transform targetPosition;
    public bool isFollowTarget;

    private string originText;
    private int typingIndex;
    private Coroutine typingCoroutine;

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
        originText = textContent.text;
        textContent.text = "";
        typingIndex = 0;
        if(typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(Type());
    }

    public void ImmediateShow()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingIndex = originText.Length;
        textContent.text = originText;
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
            StartCoroutine(Type());
        }
    }

    public bool IsPlayFinished()
    {
        return typingIndex >= originText.Length - 1;
    }
}
