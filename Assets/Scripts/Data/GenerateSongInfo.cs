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
        for (int i = 0; i < 256; i++)
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
        temp.interval = 0.5f;
        for (int i = 0; i < 256; i++)
        {
            BeatInfo bi = new BeatInfo();
            bi.index = i;
            //Add ActionInfo
            //Section1,Beat0-31
            if (i == 2)
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
            if (i == 4)
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
            if (i == 6)
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
            if (i == 8)
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
            if (i == 16)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(0);
                bi.actions.Add(ai2);
            }
            if (i == 18)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(1);
                bi.actions.Add(ai2);
            }
            if (i == 20)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);
            }
            if (i == 22)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(3);
                bi.actions.Add(ai2);
            }
            if (i == 24 || i == 25)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 4;
                ai2.actionParameters.Add(5);
                bi.actions.Add(ai2);
            }
            if (i == 26 || i == 27)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 4;
                ai2.actionParameters.Add(5);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 4;
                ai3.actionParameters.Add(3);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 4;
                ai4.actionParameters.Add(6);
                bi.actions.Add(ai4);
            }
            if (i == 28 || i == 29)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 4;
                ai2.actionParameters.Add(5);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 4;
                ai3.actionParameters.Add(3);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 4;
                ai4.actionParameters.Add(6);
                bi.actions.Add(ai4);

                ActionInfo ai5 = new ActionInfo();
                ai5.actionType = 4;
                ai5.actionParameters.Add(2);
                bi.actions.Add(ai5);

                ActionInfo ai6 = new ActionInfo();
                ai6.actionType = 4;
                ai6.actionParameters.Add(7);
                bi.actions.Add(ai6);
            }
            if (i == 30 || i == 31)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 4;
                ai2.actionParameters.Add(5);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 4;
                ai3.actionParameters.Add(3);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 4;
                ai4.actionParameters.Add(6);
                bi.actions.Add(ai4);

                ActionInfo ai5 = new ActionInfo();
                ai5.actionType = 4;
                ai5.actionParameters.Add(2);
                bi.actions.Add(ai5);

                ActionInfo ai6 = new ActionInfo();
                ai6.actionType = 4;
                ai6.actionParameters.Add(7);
                bi.actions.Add(ai6);

                ActionInfo ai7 = new ActionInfo();
                ai7.actionType = 4;
                ai7.actionParameters.Add(1);
                bi.actions.Add(ai7);

                ActionInfo ai8 = new ActionInfo();
                ai8.actionType = 4;
                ai8.actionParameters.Add(8);
                bi.actions.Add(ai8);
            }
            //Section2,Beat32-95
            if (i == 32 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 8;
                ai2.actionParameters.Add(5);
                bi.actions.Add(ai2);
            }
            if (i == 34 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 7;
                ai2.actionParameters.Add(6);
                bi.actions.Add(ai2);
            }
            if (i == 36 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 8;
                ai2.actionParameters.Add(7);
                bi.actions.Add(ai2);
            }
            if (i == 38 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 7;
                ai2.actionParameters.Add(8);
                bi.actions.Add(ai2);
            }
            if (i == 40 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 5;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 42 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 6;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);
            }
            if (i == 44 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 5;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 46 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 6;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);
            }
            if (i == 48)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(7);
                bi.actions.Add(ai2);
            }
            if (i == 50)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 4;
                ai2.actionParameters.Add(3);
                bi.actions.Add(ai2);
                ActionInfo ai3 = new ActionInfo();

                ai3.actionType = 3;
                ai3.actionParameters.Add(6);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 3;
                ai4.actionParameters.Add(8);
                bi.actions.Add(ai4);
            }
            if (i == 52)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 4;
                ai2.actionParameters.Add(4);
                bi.actions.Add(ai2);
                ActionInfo ai3 = new ActionInfo();

                ai3.actionType = 3;
                ai3.actionParameters.Add(5);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 3;
                ai4.actionParameters.Add(9);
                bi.actions.Add(ai4);
            }
            if (i == 54 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 6;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 54)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 55)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);
            }
            if (i == 56 || i == 57)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 58)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 1;
                ai2.actionParameters.Add(1);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 1;
                ai3.actionParameters.Add(0);
                bi.actions.Add(ai3);
            }
            if (i == 59 || i == 61)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 1;
                ai2.actionParameters.Add(3);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 1;
                ai3.actionParameters.Add(0);
                bi.actions.Add(ai3);
            }
            if (i == 60 || i == 62)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 1;
                ai2.actionParameters.Add(3);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 1;
                ai3.actionParameters.Add(2);
                bi.actions.Add(ai3);
            }
            if (i == 63 || i == 64 || i == 65 || i == 66 || i == 67 || i == 68 || i == 69)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 1;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 1;
                ai3.actionParameters.Add(1);
                bi.actions.Add(ai3);
            }
            if (i == 64 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(6);
                bi.actions.Add(ai);
            }
            if (i == 65 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
            }
            if (i == 66 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(8);
                bi.actions.Add(ai);
            }
            if (i == 69 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(5);
                bi.actions.Add(ai);
            }
            if (i == 70 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);
            }
            if (i == 71 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);
            }
            if (i == 72 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(9);
                bi.actions.Add(ai);
            }
            if (i == 73 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(8);
                bi.actions.Add(ai);
            }
            if (i == 74 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);
            }
            // Characters frame
            if (i == 76 - bossSolidDelay || i == 84 - bossSolidDelay || i == 92 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 7;
                ai2.actionParameters.Add(7);
                bi.actions.Add(ai2);
            }
            if (i == 80 - bossSolidDelay || i == 88 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 8;
                ai2.actionParameters.Add(7);
                bi.actions.Add(ai2);
            }
            // Character V
            if (i == 73 || i == 75)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);
            }
            if (i == 74)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);
            }
            if (i == 77)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(6);
                bi.actions.Add(ai2);
            }
            // Character I
            if (i == 77 || i == 79)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(0);
                bi.actions.Add(ai2);
            }
            if (i == 78)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(1);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 2;
                ai3.actionParameters.Add(0);
                bi.actions.Add(ai3);
            }
            if (i == 80)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(5);
                bi.actions.Add(ai);
            }
            // Character R
            if (i == 81)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(3);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 2;
                ai3.actionParameters.Add(1);
                bi.actions.Add(ai3);
            }
            if (i == 82)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);
            }
            if (i == 83)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(1);
                bi.actions.Add(ai2);
            }
            if (i == 84)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
            }
            // Character U
            if (i == 85)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 2;
                ai3.actionParameters.Add(0);
                bi.actions.Add(ai3);
            }
            if (i == 86)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 87)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(1);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 2;
                ai3.actionParameters.Add(0);
                bi.actions.Add(ai3);
            }
            if (i == 89)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(6);
                bi.actions.Add(ai);
            }
            if (i == 87)
            {
                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(4);
                bi.actions.Add(ai2);
            }
            // Character S
            if (i == 89)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(3);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 2;
                ai3.actionParameters.Add(0);
                bi.actions.Add(ai3);
            }
            if (i == 90)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 2;
                ai3.actionParameters.Add(0);
                bi.actions.Add(ai3);
            }
            if (i == 91)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(1);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 2;
                ai3.actionParameters.Add(0);
                bi.actions.Add(ai3);
            }
            //Section3,Beat96-159
            if (i == 96 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 8;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);
            }
            if (i == 97 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 8;
                ai2.actionParameters.Add(6);
                bi.actions.Add(ai2);
            }
            if (i == 100 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 8;
                ai2.actionParameters.Add(3);
                bi.actions.Add(ai2);
            }
            if (i == 101 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(5);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 8;
                ai2.actionParameters.Add(7);
                bi.actions.Add(ai2);
            }
            if (i == 103 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 6;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 6;
                ai3.actionParameters.Add(0);
                bi.actions.Add(ai3);
            }
            if (i == 105 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 6;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 6;
                ai2.actionParameters.Add(1);
                bi.actions.Add(ai2);
            }
            if (i == 107 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 7;
                ai3.actionParameters.Add(4);
                bi.actions.Add(ai3);

                ActionInfo ai5 = new ActionInfo();
                ai5.actionType = 7;
                ai5.actionParameters.Add(7);
                bi.actions.Add(ai5);
            }
            if (i == 109 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 7;
                ai2.actionParameters.Add(3);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 7;
                ai3.actionParameters.Add(6);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 7;
                ai4.actionParameters.Add(9);
                bi.actions.Add(ai4);
            }
            // Bullet spiral ABCBA
            // A
            if (i == 108 || i == 112 || i == 116 || i == 120 || i == 128 || i == 136)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(0);
                bi.actions.Add(ai2);
            }
            // B
            if (i == 109 || i == 111 || i == 113 || i == 115 || i == 117 || i == 119 || i == 122 || i == 126 || i == 130 || i == 134 || i == 138)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(1);
                bi.actions.Add(ai2);
            }
            // C
            if (i == 110 || i == 114 || i == 118 || i == 124 || i == 132 || i == 140)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 120 - bossSolidDelay || i == 130 - bossSolidDelay || i == 149 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 5;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
            }
            if (i == 122 - bossSolidDelay || i == 132 - bossSolidDelay || i == 141 - bossSolidDelay || i == 153 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 5;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 124 - bossSolidDelay || i == 134 - bossSolidDelay || i == 145 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 5;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 126 - bossSolidDelay || i == 136 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 5;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);
            }
            if (i == 128 - bossSolidDelay || i == 138 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 5;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);
            }
            if (i == 144 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 7;
                ai2.actionParameters.Add(3);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 7;
                ai3.actionParameters.Add(6);
                bi.actions.Add(ai3);
            }
            if (i == 146 - bossSolidDelay || i == 154 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 7;
                ai2.actionParameters.Add(4);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 7;
                ai3.actionParameters.Add(7);
                bi.actions.Add(ai3);
            }
            if (i == 148 - bossSolidDelay || i == 152 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 7;
                ai2.actionParameters.Add(5);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 7;
                ai3.actionParameters.Add(8);
                bi.actions.Add(ai3);
            }
            if (i == 150 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 7;
                ai2.actionParameters.Add(6);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 7;
                ai3.actionParameters.Add(9);
                bi.actions.Add(ai3);
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
