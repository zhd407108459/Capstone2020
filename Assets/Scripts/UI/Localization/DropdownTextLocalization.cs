using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownTextLocalization : MonoBehaviour
{
    public Dropdown target;
    public List<string> enTexts = new List<string>();
    public List<string> cnTexts = new List<string>();
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
            if (SettingManager.instance.language < fonts.Count)
            {
                if(SettingManager.instance.language == 0)
                {
                    for (int i = 0; i < target.options.Count; i++)
                    {
                        target.options[i].text = enTexts[i];
                    }
                    target.captionText.text = enTexts[target.value];
                    target.captionText.font = fonts[0];
                    target.itemText.font = fonts[0];
                }
                if (SettingManager.instance.language == 1)
                {
                    for (int i = 0; i < target.options.Count; i++)
                    {
                        target.options[i].text = cnTexts[i];
                    }
                    target.captionText.text = cnTexts[target.value];
                    target.captionText.font = fonts[1];
                    target.itemText.font = fonts[1];
                }
            }
        }
    }
}
