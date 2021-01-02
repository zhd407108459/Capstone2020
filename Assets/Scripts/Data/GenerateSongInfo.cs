using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;

public class GenerateSongInfo : MonoBehaviour
{
    private void Start()
    {
        //GenerateDefaultBoss1SongInfo();
        //GenerateDefaultBoss2SongInfo();
        KnifeBossTemplate();
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

    void KnifeBossTemplate()
    {
        int bossSolidDelay = 0;
        SongInfo temp = new SongInfo();
        temp.length = 256;
        temp.interval = 0.6f;
        for (int i = 0; i < 256; i++)
        {
            BeatInfo bi = new BeatInfo();
            bi.index = i;
            //Add ActionInfo
            //Section1,Beat0-31
            if(i == 0)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(9);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(4);
                bi.actions.Add(ai2);
            }
            if (i == 2)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(8);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(3);
                bi.actions.Add(ai2);
            }
            if (i == 4)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);
            }
            if (i == 6)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(6);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(1);
                bi.actions.Add(ai2);
            }
            if (i == 8)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 1;
                ai2.actionParameters.Add(4);
                bi.actions.Add(ai2);
            }
            if (i == 10)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 1;
                ai2.actionParameters.Add(3);
                bi.actions.Add(ai2);
            }
            if (i == 12)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 1;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);
            }
            if (i == 14)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 1;
                ai2.actionParameters.Add(1);
                bi.actions.Add(ai2);
            }
            //example solid
            if (i == 255 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 5;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
            }
            //End Adding ActionInfo
            temp.beatsInfo.Add(bi);
        }
        SaveAFile(temp, "./Data/KnifeBossTemplate.info");
    }

    void SaveAFile(SongInfo info, string path)
    {
        string jsonstr = JsonMapper.ToJson(info);
        File.WriteAllText(path, jsonstr);
    }
}
