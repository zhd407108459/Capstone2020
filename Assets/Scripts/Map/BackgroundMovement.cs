﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float width = 68.976f;
    public List<GameObject> backgrounds = new List<GameObject>();
    public List<GameObject> backgrounds2 = new List<GameObject>();
    public List<float> movingSpeed = new List<float>();

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void MoveBackgrounds(float delta)
    {
        for(int i = 0; i < backgrounds.Count; i++)
        {
            backgrounds[i].transform.localPosition -= new Vector3(delta * movingSpeed[i], 0, 0);
            if(backgrounds[i].transform.localPosition.x <= -width/2)
            {
                backgrounds[i].transform.localPosition = new Vector3(backgrounds[i].transform.localPosition.x + width, 0, 0);
            }
        }
        for (int i = 0; i < backgrounds2.Count; i++)
        {
            backgrounds2[i].transform.localPosition -= new Vector3(delta * movingSpeed[i], 0, 0);
            if (backgrounds2[i].transform.localPosition.x <= -width / 2)
            {
                backgrounds2[i].transform.localPosition = new Vector3(backgrounds2[i].transform.localPosition.x + width, 0, 0);
            }
        }
    }
}
