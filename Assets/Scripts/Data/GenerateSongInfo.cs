using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;

public class GenerateSongInfo : MonoBehaviour
{
    private void Start()
    {
        GenerateDefaultBoss1SongInfo();
        GenerateDefaultBoss2SongInfo();
    }

    void GenerateDefaultBoss1SongInfo()
    {
        SongInfo temp = new SongInfo();
        temp.length = 256;
        temp.interval = 0.5f;
        int at = 1;
        int ap = 0;
        for (int i = 0; i < 256; i++)
        {
            BeatInfo bi = new BeatInfo();
            bi.index = i;
            if(i >= 4 && i < 252)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = at;
                ai.actionParameters.Add(ap);
                ap++;
                if (at == 1 || at == 2)
                {
                    if (ap > 4)
                    {
                        at++;
                        ap = 0;
                    }
                }
                if (at == 3 || at == 4)
                {
                    if (ap > 9)
                    {
                        at++;
                        ap = 0;
                    }
                }
                if (at == 5 || at == 6)
                {
                    if (ap > 4)
                    {
                        at++;
                        ap = 0;
                    }
                }
                if (at == 7 || at == 8)
                {
                    if (ap > 9)
                    {
                        at++;
                        if (at > 4)
                        {
                            at = 1;
                        }
                        ap = 0;
                    }
                }
                bi.actions.Add(ai);
            }
            temp.beatsInfo.Add(bi);
        }
        SaveAFile(temp, "./Data/TestBoss1.info");
    }

    void GenerateDefaultBoss2SongInfo()
    {
        SongInfo temp = new SongInfo();
        temp.length = 256;
        temp.interval = 0.6f;
        int at = 1;
        int ap = 0;
        for(int i = 0; i < 256; i++)
        {
            BeatInfo bi = new BeatInfo();
            bi.index = i;
            if (i >= 4 && i < 252)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = at;
                ai.actionParameters.Add(ap);
                ap++;
                if (at == 1 || at == 2)
                {
                    if (ap > 4)
                    {
                        at++;
                        ap = 0;
                    }
                }
                if (at == 3 || at == 4)
                {
                    if (ap > 9)
                    {
                        at++;
                        ap = 0;
                    }
                }
                if (at == 5)
                {
                    ai.actionType = 9;
                    ai.actionParameters.Clear();
                    ai.actionParameters.Add(0);
                    at = 1;
                    ap = 0;
                }
                bi.actions.Add(ai);
            }
            temp.beatsInfo.Add(bi);
        }
        SaveAFile(temp, "./Data/TestBoss2.info");
    }

    void SaveAFile(SongInfo info, string path)
    {
        string jsonstr = JsonMapper.ToJson(info);
        File.WriteAllText(path, jsonstr);
    }
}
