using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationChangePosition : MonoBehaviour
{
    public RectTransform target;
    public List<Vector3> positions = new List<Vector3>();

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
            if (SettingManager.instance.language < positions.Count)
            {
                target.anchoredPosition3D = positions[SettingManager.instance.language];
            }
        }
    }
}
