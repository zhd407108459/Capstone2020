using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathrattleIcon : MonoBehaviour
{
    public Image icon;
    public Text tipText;

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
            icon.color = new Color(icon.color.r, icon.color.g, icon.color.b, Mathf.Lerp(icon.color.a, 0, 10.0f * Time.deltaTime));
            tipText.color = new Color(tipText.color.r, tipText.color.g, tipText.color.b, Mathf.Lerp(tipText.color.a, 0, 10.0f * Time.deltaTime));
        }
    }

    public void SetUp(string content)
    {
        tipText.text = content;
    }

    void StartFadeOut()
    {
        isFadeOut = true;
    }
}
