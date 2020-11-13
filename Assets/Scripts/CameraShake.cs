using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float cameraShakeDistance;
    //public float cameraShakeLerpValue;

    //private Vector3 shakeDis;
    //private Vector3 originalCameraPos;

    void Start()
    {
        //shakeDis = Vector3.zero;
        //originalCameraPos = transform.position;
    }

    void Update()
    {
        //if (shakeDis.magnitude > 0)
        //{
        //    shakeDis = Vector3.Lerp(shakeDis, new Vector3(0, 0, 0), cameraShakeLerpValue * Time.deltaTime);
        //}
        //Camera.main.transform.position = originalCameraPos + shakeDis;
    }

    public void Shake()
    {
        transform.position += new Vector3(Random.Range(-cameraShakeDistance, cameraShakeDistance), Random.Range(-cameraShakeDistance, cameraShakeDistance), 0);
        //shakeDis = new Vector3(Random.Range(-cameraShakeDistance, cameraShakeDistance), Random.Range(-cameraShakeDistance, cameraShakeDistance), 0);
        //originalCameraPos = transform.position;
    }
}
