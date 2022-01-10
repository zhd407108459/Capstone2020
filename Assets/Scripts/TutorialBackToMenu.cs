using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBackToMenu : MonoBehaviour
{
    public static TutorialBackToMenu instance;

    public bool isFinished = false;

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

}
