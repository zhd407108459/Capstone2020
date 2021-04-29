using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class FMODEventPlayer : MonoBehaviour
{
    public string path;
    public bool isBGM;

    private EventInstance sound;

    public void Play()
    {
        sound = RuntimeManager.CreateInstance(path);
        if (SettingManager.instance != null)
        {
            sound.setVolume(SettingManager.instance.overAllVolume * (isBGM ? SettingManager.instance.musicVolume : SettingManager.instance.soundEffectVolume));
        }
        sound.start();
    }

    public void Stop()
    {
        if (sound.isValid())
        {
            sound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
}
