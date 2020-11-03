using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathrattleIcon : MonoBehaviour
{
    public SpriteRenderer sprite;

    public float destroyTime;
    public float fadeOutTime;

    private bool isFadeOut;

    void Start()
    {
        Destroy(this.gameObject, destroyTime);
        transform.localScale = Vector3.zero;
        isFadeOut = false;
        Invoke("StartFadeOut", fadeOutTime);
    }

    void Update()
    {
        if (GameManager.instance.isPaused)
        {
            return;
        }
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1, 1, 1), 20.0f * Time.deltaTime);
        if (isFadeOut)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Mathf.Lerp(sprite.color.a, 0, 10.0f * Time.deltaTime));
        }
    }

    void StartFadeOut()
    {
        isFadeOut = true;
    }
}
