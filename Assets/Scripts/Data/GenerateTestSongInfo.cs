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
            if (i == 85 || i == 105 || i == 125 || i == 145 || i == 165 || i == 185)
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


            if (i == 34)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 35)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 36)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 37)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(3);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 38)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(4);
                temp.beatsInfo[i].actions.Add(ai);
            }

            if (i == 39)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 40)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 41)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 42)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(3);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 43)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(4);
                temp.beatsInfo[i].actions.Add(ai);
            }


            if (i == 44)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 45)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 46)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 47)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(3);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 48)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(4);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 49)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(5);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 50)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(6);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 51)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(7);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 52)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(8);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 53)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(9);
                temp.beatsInfo[i].actions.Add(ai);
            }

            if (i == 54)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 55)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 56)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 57)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(3);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 58)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(4);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 59)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(5);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 60)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(6);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 61)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(7);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 62)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(8);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 63)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(9);
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
