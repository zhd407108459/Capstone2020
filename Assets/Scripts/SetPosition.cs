﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    public void SetObjectPositionZero()
    {
        transform.position = new Vector3(0, 0, -10);
        Camera.main.orthographicSize = 5;
    }
}
