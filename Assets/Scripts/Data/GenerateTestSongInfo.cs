using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;

public class GenerateTestSongInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GenerateBoss3TestFile();
    }

    void GenerateBoss3TestFile()
    {
        SongInfo temp = new SongInfo();
        temp.length = 219;
        temp.interval = 0.48f;
        for (int i = 0; i < 219; i++)
        {
            BeatInfo bi = new BeatInfo();
            bi.index = i;
            //End Adding ActionInfo
            temp.beatsInfo.Add(bi);
        }
        for (int i = 0; i < 219; i++)
        {
            if (i == 3)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 20;
                temp.beatsInfo[i].actions.Add(ai);
            }

            if (i == 10)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 11)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 12)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(4);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 13)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(3);
                ai.actionParameters.Add(6);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 14)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(4);
                ai.actionParameters.Add(8);
                temp.beatsInfo[i].actions.Add(ai);
            }


            if (i == 15)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 16)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 17)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 18)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(3);
                ai.actionParameters.Add(3);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 19)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(4);
                ai.actionParameters.Add(4);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 20)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(5);
                ai.actionParameters.Add(5);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 21)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(6);
                ai.actionParameters.Add(6);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 22)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(7);
                ai.actionParameters.Add(7);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 23)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(8);
                ai.actionParameters.Add(8);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 24)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(9);
                ai.actionParameters.Add(9);
                temp.beatsInfo[i].actions.Add(ai);
            }


            if (i == 25)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 26)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 27)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 28)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai);
            }
        }
        SaveAFile(temp, "./Data/Boss3Test.info");
    }


    void SaveAFile(SongInfo info, string path)
    {
        string jsonstr = JsonMapper.ToJson(info);
        File.WriteAllText(path, jsonstr);
    }
}
