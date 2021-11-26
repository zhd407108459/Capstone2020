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
        KnifeBoss3Phase1Hard(); 
        KnifeBoss3Phase1Easy();
    }

    void GenerateBoss3TestFile()
    {
        SongInfo temp = new SongInfo();
        temp.length = 259;
        temp.interval = 0.46f;
        for (int i = 0; i < 259; i++)
        {
            BeatInfo bi = new BeatInfo();
            bi.index = i;
            //End Adding ActionInfo
            temp.beatsInfo.Add(bi);
        }
        for (int i = 0; i < 259; i++)
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
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(6);
                temp.beatsInfo[i].actions.Add(ai2);
                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 23;
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(2);
                ai3.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai3);

            }
            if (i == 11)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 12)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(4);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 24;
                ai3.actionParameters.Add(2);
                ai3.actionParameters.Add(3);
                ai3.actionParameters.Add(4);
                temp.beatsInfo[i].actions.Add(ai3);
            }
            if (i == 13)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(3);
                ai.actionParameters.Add(6);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 14)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(4);
                ai.actionParameters.Add(8);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
            }


            if (i == 15)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(0);
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
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);
                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(7);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 17)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(4);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 18)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(3);
                ai.actionParameters.Add(3);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 19)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(4);
                ai.actionParameters.Add(4);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 20)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(5);
                ai.actionParameters.Add(5);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 21)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(6);
                ai.actionParameters.Add(6);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 22)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(7);
                ai.actionParameters.Add(7);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 23)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(8);
                ai.actionParameters.Add(8);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 24)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(9);
                ai.actionParameters.Add(9);
                ai.actionParameters.Add(1);
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

            if (i == 180)
            {
                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(5);
                temp.beatsInfo[i].actions.Add(ai2);
            }
        }
        SaveAFile(temp, "./Data/Boss3Test.info");
    }

    void KnifeBoss3Phase1Hard()
    {
        SongInfo temp = new SongInfo();
        temp.length = 259;
        temp.interval = 0.46f;
        for (int i = 0; i < 259; i++)
        {
            BeatInfo bi = new BeatInfo();
            bi.index = i;
            //End Adding ActionInfo
            temp.beatsInfo.Add(bi);
        }
        for (int i = 0; i < 259; i++)
        {
            //Section1, Beat0-31
            //Laser type1
            if (i == 2 || i == 6 || i == 14 || i == 18 || i == 22)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 21;
                ai2.actionParameters.Add(4);
                ai2.actionParameters.Add(1);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(2);
                ai3.actionParameters.Add(1);
                ai3.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 22;
                ai4.actionParameters.Add(7);
                ai4.actionParameters.Add(1);
                ai4.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai4);
            }
            if (i == 10 || i == 26)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 21;
                ai2.actionParameters.Add(3);
                ai2.actionParameters.Add(1);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(1);
                ai3.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 22;
                ai4.actionParameters.Add(9);
                ai4.actionParameters.Add(1);
                ai4.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai4);
            }

            //Laser type2
            if (i == 26)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(3);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 22;
                ai4.actionParameters.Add(6);
                ai4.actionParameters.Add(0);
                ai4.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai4);
            }
            if (i == 27)
            {
                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(4);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(5);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai3);
            }

            //Bullets
            if (i == 0 || i == 16)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 4 || i == 12 || i == 20)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(3);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 8 || i == 24)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(4);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai2);
            }

            //Section2, Beat32-63
            //Bullets Down
            if (i == 32 || i == 35 || i == 37 || i == 40 || i == 42 || i == 45 || i == 47 || i == 50 || i == 52 || i == 55 || i == 57)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(8);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 33 || i == 39 || i == 43 || i == 49 || i == 53 || i == 59)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(7);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 34 || i == 38 || i == 44 || i == 48 || i == 54 || i == 58)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(9);
                temp.beatsInfo[i].actions.Add(ai2);
            }

            //Bullets Up
            if (i == 32 || i == 36 || i == 40 || i == 44 || i == 48 || i == 52 || i == 56)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(6);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 33 || i == 37 || i == 41 || i == 45 || i == 49 || i == 53 || i == 57)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(5);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 34 || i == 38 || i == 42 || i == 46 || i == 50 || i == 54 || i == 58)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(3);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 35 || i == 39 || i == 43 || i == 47 || i == 51 || i == 55 || i == 59)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(4);
                temp.beatsInfo[i].actions.Add(ai);
            }

            //Laser type2
            if (i == 59)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 21;
                ai2.actionParameters.Add(4);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 22;
                ai4.actionParameters.Add(9);
                ai4.actionParameters.Add(0);
                ai4.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai4);
            }

            //Section3, Beat64-127
            //Bullets Down
            if (i == 64 || i == 80)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(3);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(6);
                temp.beatsInfo[i].actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 3;
                ai4.actionParameters.Add(9);
                temp.beatsInfo[i].actions.Add(ai4);
            }
            if (i == 66 || i == 82)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(4);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(7);
                temp.beatsInfo[i].actions.Add(ai3);
            }
            if (i == 68 || i == 84)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(5);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(8);
                temp.beatsInfo[i].actions.Add(ai3);
            }

            //Bullets Up
            if (i == 72 || i == 88)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 4;
                ai2.actionParameters.Add(3);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 4;
                ai3.actionParameters.Add(6);
                temp.beatsInfo[i].actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 4;
                ai4.actionParameters.Add(9);
                temp.beatsInfo[i].actions.Add(ai4);
            }
            if (i == 74 || i == 90)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 4;
                ai2.actionParameters.Add(4);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 4;
                ai3.actionParameters.Add(7);
                temp.beatsInfo[i].actions.Add(ai3);
            }
            if (i == 76 || i == 92)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 4;
                ai2.actionParameters.Add(5);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 4;
                ai3.actionParameters.Add(8);
                temp.beatsInfo[i].actions.Add(ai3);
            }

            //Laser type1
            if (i == 64 || i == 80)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(4);
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 66 || i == 82)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(3);
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 68 || i == 84)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 72 || i == 88)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 74 || i == 90)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 76 || i == 92)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 95)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(9);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 96)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(8);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 97)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(7);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 104 || i == 106 || i == 108 || i == 110)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(7);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 104 || i == 108 || i == 112 || i == 116 || i == 120 || i == 122 || i == 124)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 21;
                ai2.actionParameters.Add(4);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 118 || i == 120 || i == 122 || i == 124)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(7);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }

            //Hook
            if (i == 66 ||i == 82 || i == 98 ||i == 114)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 20;
                temp.beatsInfo[i].actions.Add(ai);
            }

            //Bullet Wall
            if (i == 98)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(9);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 99)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(8);
                temp.beatsInfo[i].actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 3;
                ai4.actionParameters.Add(9);
                temp.beatsInfo[i].actions.Add(ai4);
            }
            if (i >= 100 && i <= 124)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 3;
                ai4.actionParameters.Add(7);
                temp.beatsInfo[i].actions.Add(ai4);

                ActionInfo ai5 = new ActionInfo();
                ai5.actionType = 3;
                ai5.actionParameters.Add(8);
                temp.beatsInfo[i].actions.Add(ai5);

                ActionInfo ai6 = new ActionInfo();
                ai6.actionType = 3;
                ai6.actionParameters.Add(9);
                temp.beatsInfo[i].actions.Add(ai6);
            }

            //Bullet Horizontal
            if (i == 100 || i == 105 || i == 116)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 103 || i == 114)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 106 || i == 117)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 102 || i == 109 || i == 113)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai);
            }

            //Section4 Beats128-223
            //Pattern01(Beats128-159)
            //Laser type1
            if (i == 128)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(1);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(2);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai3);
            }
            if (i == 132)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(7);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(8);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(9);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai3);
            }
            if (i == 136)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(2);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(4);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai3);
            }
            if (i == 140)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(4);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(6);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(8);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai3);
            }
            if (i == 144)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(8);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 146)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(7);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 148)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 21;
                ai2.actionParameters.Add(3);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 21;
                ai3.actionParameters.Add(4);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai3);
            }
            if (i == 152)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(4);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(5);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 154)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(3);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(6);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }

            //Laser type2
            if (i == 128)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(5);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(6);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 132)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(3);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(4);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 136)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(5);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(7);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(9);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai3);
            }
            if (i == 140)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(3);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(5);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai3);
            }
            if (i == 148)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 21;
                ai2.actionParameters.Add(1);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 154)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(1);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(2);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 22;
                ai4.actionParameters.Add(7);
                ai4.actionParameters.Add(0);
                ai4.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai4);

                ActionInfo ai5 = new ActionInfo();
                ai5.actionType = 22;
                ai5.actionParameters.Add(8);
                ai5.actionParameters.Add(0);
                ai5.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai5);

                ActionInfo ai6 = new ActionInfo();
                ai6.actionType = 22;
                ai6.actionParameters.Add(9);
                ai6.actionParameters.Add(0);
                ai6.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai6);
            }
            if (i == 156)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 21;
                ai2.actionParameters.Add(4);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 158)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 21;
                ai2.actionParameters.Add(3);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);
            }

            //Pattern02(Beats160-223)
            //Laser type1
            if (i == 210)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(1);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(2);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 22;
                ai4.actionParameters.Add(3);
                ai4.actionParameters.Add(0);
                ai4.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai4);

                ActionInfo ai5 = new ActionInfo();
                ai5.actionType = 22;
                ai5.actionParameters.Add(4);
                ai5.actionParameters.Add(0);
                ai5.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai5);
            }
            if (i == 216)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(9);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 21;
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 21;
                ai4.actionParameters.Add(4);
                ai4.actionParameters.Add(0);
                ai4.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai4);
            }
            if (i == 219)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(3);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(6);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai3);
            }
            if (i == 220)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(4);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(7);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai3);
            }
            if (i == 221)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(5);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(8);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai3);
            }

            //Laser type2
            if (i == 160 || i == 168 || i == 192 || i == 200)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 21;
                ai2.actionParameters.Add(3);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 21;
                ai3.actionParameters.Add(4);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai3);
            }
            if (i == 162 || i == 170 || i == 198 || i == 206 || i == 210)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(5);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(6);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(7);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 22;
                ai4.actionParameters.Add(8);
                ai4.actionParameters.Add(0);
                ai4.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai4);

                ActionInfo ai5 = new ActionInfo();
                ai5.actionType = 22;
                ai5.actionParameters.Add(9);
                ai5.actionParameters.Add(0);
                ai5.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai5);
            }
            if (i == 164 || i == 172 || i == 196 || i == 204)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 21;
                ai2.actionParameters.Add(1);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 166 || i == 174 || i == 194 || i == 202)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(1);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(2);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 22;
                ai4.actionParameters.Add(3);
                ai4.actionParameters.Add(0);
                ai4.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai4);

                ActionInfo ai5 = new ActionInfo();
                ai5.actionType = 22;
                ai5.actionParameters.Add(4);
                ai5.actionParameters.Add(0);
                ai5.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai5);
            }
            if (i == 214)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(7);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 21;
                ai3.actionParameters.Add(2);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai3);
            }
            if (i == 216)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(8);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 21;
                ai3.actionParameters.Add(1);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 21;
                ai4.actionParameters.Add(3);
                ai4.actionParameters.Add(0);
                ai4.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai4);
            }

            //Bullet Wall
            if (i >= 170 && i <= 186)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 1;
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 187)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
            }

            //Bullet Horizontal
            if (i == 172 || i == 176 || i == 180 || i == 184)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 173 || i == 177 || i == 181 || i == 185)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(3);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 174 || i == 178 || i == 182 || i == 186)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(4);
                temp.beatsInfo[i].actions.Add(ai);
            }

            //Hook
            if (i == 176 || i == 192 || i == 208 || i == 224)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 20;
                temp.beatsInfo[i].actions.Add(ai);
            }

            //Section5 Beats224-259
            //Bullets Down
            if (i == 224 || i == 227 || i == 229 || i == 232 || i == 234 || i == 237 || i == 239 || i == 242)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(8);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 225 || i == 231 || i == 235 || i == 241)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(7);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 226 || i == 230 || i == 236 || i == 240)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(9);
                temp.beatsInfo[i].actions.Add(ai2);
            }

            //Bullets Up
            if (i == 224 || i == 228 || i == 232 || i == 236)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(6);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 225 || i == 229 || i == 233 || i == 237)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(5);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 226 || i == 230 || i == 234 || i == 238)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(3);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 227 || i == 231 || i == 235 || i == 239)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(4);
                temp.beatsInfo[i].actions.Add(ai);
            }

            //Laser type1
            if (i == 238)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(9);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 240 || i == 246)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(8);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 242 || i == 250)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(7);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 252)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(3);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(6);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 254)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(3);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
            }

            //Laser type2
            if (i == 224)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(5);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 228)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(4);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(8);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 232)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(3);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(7);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 236)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(6);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);
            }

        }
        SaveAFile(temp, "./Data/KnifeBoss3Phase1Hard.info");
    }

    void KnifeBoss3Phase1Easy()
    {
        SongInfo temp = new SongInfo();
        temp.length = 259;
        temp.interval = 0.46f;
        for (int i = 0; i < 259; i++)
        {
            BeatInfo bi = new BeatInfo();
            bi.index = i;
            //End Adding ActionInfo
            temp.beatsInfo.Add(bi);
        }
        for (int i = 0; i < 259; i++)
        {
            //Section1, Beat0-31
            //Laser type1
            if (i == 2 || i == 6 || i == 14 || i == 18 || i == 22)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 21;
                ai2.actionParameters.Add(4);
                ai2.actionParameters.Add(1);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(2);
                ai3.actionParameters.Add(1);
                ai3.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 22;
                ai4.actionParameters.Add(7);
                ai4.actionParameters.Add(1);
                ai4.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai4);
            }
            if (i == 10 || i == 26)
            {
                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 21;
                ai2.actionParameters.Add(2);
                ai2.actionParameters.Add(1);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(1);
                ai3.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 22;
                ai4.actionParameters.Add(9);
                ai4.actionParameters.Add(1);
                ai4.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai4);
            }

            //Laser type2
            if (i == 26)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(3);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 22;
                ai4.actionParameters.Add(6);
                ai4.actionParameters.Add(0);
                ai4.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai4);
            }
            if (i == 27)
            {
                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(4);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(5);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai3);
            }

            //Bullets
            if (i == 0 || i == 16)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 4 || i == 12 || i == 20)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(3);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 8 || i == 24)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(4);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai2);
            }

            //Section2, Beat32-63
            //Bullets Down
            if (i == 32 || i == 37 || i == 42 || i == 47 || i == 52 || i == 57)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(8);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 33 || i == 39 || i == 43 || i == 49 || i == 53 || i == 59)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(7);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 34 || i == 38 || i == 44 || i == 48 || i == 54 || i == 58)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(9);
                temp.beatsInfo[i].actions.Add(ai2);
            }

            //Bullets Up
            if (i == 32 || i == 38 || i == 44 || i == 50 || i == 56)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(6);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 33 || i == 39 || i == 45 || i == 51 || i == 57)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(4);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 34 || i == 40 ||i == 46 || i == 52 || i == 58)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(5);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 35 || i == 41 ||i == 47 || i == 53 || i == 59)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(3);
                temp.beatsInfo[i].actions.Add(ai);
            }

            //Laser type2
            if (i == 59)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 21;
                ai2.actionParameters.Add(4);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 22;
                ai4.actionParameters.Add(9);
                ai4.actionParameters.Add(0);
                ai4.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai4);
            }

            //Section3, Beat64-127
            //Bullets Down
            if (i == 64 || i == 80)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(6);
                temp.beatsInfo[i].actions.Add(ai3);
            }
            if (i == 66 || i == 82)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(7);
                temp.beatsInfo[i].actions.Add(ai3);
            }
            if (i == 68 || i == 84)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(8);
                temp.beatsInfo[i].actions.Add(ai3);
            }

            //Bullets Up
            if (i == 72 || i == 88)
            {
                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 4;
                ai2.actionParameters.Add(3);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 4;
                ai4.actionParameters.Add(9);
                temp.beatsInfo[i].actions.Add(ai4);
            }
            if (i == 74 || i == 90)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 4;
                ai2.actionParameters.Add(8);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 76 || i == 92)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 4;
                ai2.actionParameters.Add(7);
                temp.beatsInfo[i].actions.Add(ai2);
            }

            //Laser type1
            if (i == 64 || i == 80)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(4);
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 68 || i == 84)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(3);
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 72 || i == 88)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 76 || i == 92)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 95)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(9);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 96)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(8);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 97)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(7);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 104 || i == 106 || i == 108 || i == 110)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(7);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 104 || i == 108 || i == 112 || i == 116 || i == 120 || i == 122 || i == 124)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 21;
                ai2.actionParameters.Add(4);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 118 || i == 120 || i == 122 || i == 124)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(7);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }

            //Hook
            if (i == 66 || i == 82 || i == 98 || i == 114)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 20;
                temp.beatsInfo[i].actions.Add(ai);
            }

            //Bullet Wall
            if (i == 98)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(9);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 99)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(8);
                temp.beatsInfo[i].actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 3;
                ai4.actionParameters.Add(9);
                temp.beatsInfo[i].actions.Add(ai4);
            }
            if (i >= 100 && i <= 124)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 3;
                ai4.actionParameters.Add(7);
                temp.beatsInfo[i].actions.Add(ai4);

                ActionInfo ai5 = new ActionInfo();
                ai5.actionType = 3;
                ai5.actionParameters.Add(8);
                temp.beatsInfo[i].actions.Add(ai5);

                ActionInfo ai6 = new ActionInfo();
                ai6.actionType = 3;
                ai6.actionParameters.Add(9);
                temp.beatsInfo[i].actions.Add(ai6);
            }

            //Bullet Horizontal
            if (i == 100 || i == 108)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 104 || i == 112)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 106 || i == 114)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 102 || i == 110)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai);
            }

            //Section4 Beats128-223
            //Pattern01(Beats128-159)
            //Laser type1
            if (i == 128)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(2);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai3);
            }
            if (i == 132)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(7);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(9);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai3);
            }
            if (i == 136)
            {
                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(1);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(3);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai3);
            }
            if (i == 140)
            {
                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(5);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(7);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai3);
            }
            if (i == 144)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(8);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 146)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(7);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 152)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(3);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(9);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 154)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(6);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }

            //Laser type2
            if (i == 128)
            {
                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(7);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 132)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 136)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(6);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(8);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 140)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(4);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 148)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 21;
                ai2.actionParameters.Add(4);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 154)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(2);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 22;
                ai4.actionParameters.Add(7);
                ai4.actionParameters.Add(0);
                ai4.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai4);

                ActionInfo ai6 = new ActionInfo();
                ai6.actionType = 22;
                ai6.actionParameters.Add(9);
                ai6.actionParameters.Add(0);
                ai6.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai6);
            }
            if (i == 156)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);
            }

            //Pattern02(Beats160-223)
            //Laser type2
            if (i == 160 || i == 176 || i == 200 || i == 216)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 21;
                ai2.actionParameters.Add(3);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 21;
                ai3.actionParameters.Add(4);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai3);
            }
            if (i == 164 || i == 180 || i == 196 || i == 212)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(5);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(6);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(7);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 22;
                ai4.actionParameters.Add(8);
                ai4.actionParameters.Add(0);
                ai4.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai4);

                ActionInfo ai5 = new ActionInfo();
                ai5.actionType = 22;
                ai5.actionParameters.Add(9);
                ai5.actionParameters.Add(0);
                ai5.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai5);
            }
            if (i == 168 || i == 184 || i == 192 || i == 208)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 21;
                ai2.actionParameters.Add(1);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 172 || i == 188 || i == 204)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(1);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 22;
                ai3.actionParameters.Add(2);
                ai3.actionParameters.Add(0);
                ai3.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 22;
                ai4.actionParameters.Add(3);
                ai4.actionParameters.Add(0);
                ai4.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai4);

                ActionInfo ai5 = new ActionInfo();
                ai5.actionType = 22;
                ai5.actionParameters.Add(4);
                ai5.actionParameters.Add(0);
                ai5.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai5);
            }

            //Bullet Horizontal
            if (i == 160 || i == 168 || i == 176 || i == 184)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 161 || i == 169 || i == 177 || i == 185)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 162 || i == 170 || i == 178 || i == 186)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(4);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 188 || i == 196 || i == 204 || i == 212)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(3);
                temp.beatsInfo[i].actions.Add(ai2);
            }

            //Section5 Beats224-259
            //Bullets Down
            if (i == 224 || i == 229 || i == 234 || i == 239)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(1);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(8);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 225 || i == 231 || i == 235 || i == 241)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(2);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(7);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 226 || i == 230 || i == 236 || i == 240)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(9);
                temp.beatsInfo[i].actions.Add(ai2);
            }

            //Bullets Up
            if (i == 224 || i == 230 || i == 236)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(3);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 225 || i == 231 || i == 237)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(5);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 226 || i == 232 || i == 238)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(4);
                temp.beatsInfo[i].actions.Add(ai);
            }
            if (i == 227 || i == 233 || i == 239)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(6);
                temp.beatsInfo[i].actions.Add(ai);
            }

            //Laser type1
            if (i == 238)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(9);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 240 || i == 246)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(1);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(8);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 242 || i == 250)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(2);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(7);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 252)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 22;
                ai.actionParameters.Add(3);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 22;
                ai2.actionParameters.Add(6);
                ai2.actionParameters.Add(0);
                ai2.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai2);
            }
            if (i == 254)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 21;
                ai.actionParameters.Add(3);
                ai.actionParameters.Add(0);
                ai.actionParameters.Add(0);
                temp.beatsInfo[i].actions.Add(ai);
            }

            //Hook
            if (i == 226 || i == 242)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 20;
                temp.beatsInfo[i].actions.Add(ai);
            }

        }
        SaveAFile(temp, "./Data/KnifeBoss3Phase1Easy.info");
    }
    void SaveAFile(SongInfo info, string path)
    {
        string jsonstr = JsonMapper.ToJson(info);
        File.WriteAllText(path, jsonstr);
    }
}
