using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float delay = 1.0f;

    void Start()
    {
        Destroy(this.gameObject, delay);
    }
}
