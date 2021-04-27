using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PointLightCaster2D))]
public class PointLightSizeAnimator : MonoBehaviour
{
    public float speed;

    private float target;
    private float lastLength;
    private bool isAnimating;

    private void Update()
    {
        if (!GameManager.instance.isPaused && isAnimating)
        {
            PointLightCaster2D light = GetComponent<PointLightCaster2D>();
            if ((light.size - target) * (lastLength - target) <= 0)
            {
                light.size = target;
                isAnimating = false;
            }
            light.size += ((target - light.size) > 0 ? 1 : -1) * speed * Time.deltaTime;
            lastLength = light.size;
        }
    }

    public void AnimateToSize(float targetSize)
    {
        target = targetSize;
        isAnimating = true;
    }
}
