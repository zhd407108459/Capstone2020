using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleTextLocalization : MonoBehaviour
{
    public Text target;
    public List<string> texts = new List<string>();
    public List<Font> fonts = new List<Font>();

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
            if(SettingManager.instance.language < texts.Count)
            {
                target.text = texts[SettingManager.instance.language];
            }
            if (SettingManager.instance.language < fonts.Count)
            {
                target.font = fonts[SettingManager.instance.language];
            }
        }
    }
}
