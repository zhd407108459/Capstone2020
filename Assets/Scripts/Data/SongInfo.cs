using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;

public class SongInfo
{
    public int length;
    public double interval;
    public List<BeatInfo> beatsInfo = new List<BeatInfo>();

    public void LoadFromPath(string path)
    {
        SongInfo temp = JsonMapper.ToObject<SongInfo>(File.ReadAllText(path));
        length = temp.length;
        interval = temp.interval;
        beatsInfo = temp.beatsInfo;
    }
}
