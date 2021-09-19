using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRendererLocalization : MonoBehaviour
{
    public SpriteRenderer target;
    public List<Sprite> sources = new List<Sprite>();

    private void OnEnable()
    {
        ApplyLanguage();
    }

    void Start()
    {
    }

    public void ApplyLanguage()
    {
        if (SettingManager.instance != null)
        {
            if (SettingManager.instance.language < sources.Count)
            {
                target.sprite = sources[SettingManager.instance.language];
            }
        }
    }
}
