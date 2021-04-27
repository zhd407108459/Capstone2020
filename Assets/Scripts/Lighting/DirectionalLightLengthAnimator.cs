using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DirectionalLightCaster2D))]
public class DirectionalLightLengthAnimator : MonoBehaviour
{
    public float speed;

    private float target;
    private float lastLength;
    private bool isAnimating;

    private void Update()
    {
        if (!GameManager.instance.isPaused && isAnimating)
        {
            DirectionalLightCaster2D light = GetComponent<DirectionalLightCaster2D>();
            if((light.length - target)*(lastLength - target) <= 0)
            {
                light.length = target;
                isAnimating = false;
            }
            light.length += ((target - light.length) > 0 ? 1 : -1) * speed * Time.deltaTime;
            lastLength = light.length;
        }
    }

    public void AnimateToLength(float targetLength)
    {
        target = targetLength;
        isAnimating = true;
    }
}
