using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGenerator : MonoBehaviour
{
    public GameObject bubbleParticlePrefab;
    public float minInterval;
    public float maxInterval;

    private float interval;
    private float timer;

    void Start()
    {
        timer = 0;
        interval = Random.Range(minInterval, maxInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isCutScene || GameManager.instance.isPaused)
        {
            return;
        }
        timer += Time.deltaTime;
        if(timer >= interval)
        {
            Instantiate(bubbleParticlePrefab, transform.position, Quaternion.identity, this.transform);
            timer = 0;
            interval = Random.Range(minInterval, maxInterval);
        }
    }
}
