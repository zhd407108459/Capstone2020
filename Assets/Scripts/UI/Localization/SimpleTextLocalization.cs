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

    private void Start()
    {
        ApplyLanguage();
    }

    public void ApplyLanguage()
    {
        if (SettingManager.instance != null)
        {
            if(target == null)
            {
                if(GetComponent<Text>() == null)
                {
                    return;
                }
                else
                {
                    target = GetComponent<Text>();
                }
            }
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
