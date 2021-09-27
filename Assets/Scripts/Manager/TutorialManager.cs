using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;

    public List<GameObject> tutorialTips = new List<GameObject>();

    public List<GameObject> externalObjects = new List<GameObject>();


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

    public void ShowTutorialTip(int index)
    {
        if(index < 0 || index >= tutorialTips.Count)
        {
            Debug.LogError("Wrong Tutorial Tip Index!!!");
            return;
        }

        for (int i = 0; i < tutorialTips.Count; i++) 
        {
            tutorialTips[i].SetActive(false);
        }
        tutorialTips[index].SetActive(true);
    }

    public void ShowExternalObject(int index)
    {
        if (index < 0 || index >= externalObjects.Count)
        {
            Debug.LogError("Wrong Object Index!!!");
            return;
        }
        externalObjects[index].SetActive(true);
    }

    public void HideExternalObject(int index)
    {
        if (index < 0 || index >= externalObjects.Count)
        {
            Debug.LogError("Wrong Object Index!!!");
            return;
        }
        externalObjects[index].SetActive(false);
    }
}
