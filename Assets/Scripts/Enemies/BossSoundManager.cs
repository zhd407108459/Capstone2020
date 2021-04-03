using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class BossSoundManager : MonoBehaviour
{
    public List<string> pathList = new List<string>();

    public void InvokeSound(int index)
    {
        if(index < 0 || index >= pathList.Count)
        {
            Debug.LogError("Wrong Index: " + index);
            return;
        }
        EventInstance sound;
        sound = RuntimeManager.CreateInstance(pathList[index]);
        if (SettingManager.instance != null)
        {
            sound.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume);
        }
        sound.start();
    }
}
