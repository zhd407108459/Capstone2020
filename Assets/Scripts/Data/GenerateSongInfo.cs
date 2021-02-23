using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;

public class GenerateSongInfo : MonoBehaviour
{
    private void Start()
    {
        //GenerateTestFileFor10And11();
        //GenerateDefaultBoss1SongInfo();
        //GenerateDefaultBoss2SongInfo();
        KnifeBoss1Phase1Easy();
        //KnifeBoss1Phase2Easy();
    }

    void GenerateTestFileFor10And11()
    {
        SongInfo temp = new SongInfo();
        temp.length = 256;
        temp.interval = 0.5f;
        int at = 10;
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
                if(at == 10)
                {
                    if(ap > 3)
                    {
                        at++;
                        ap = 0;
                    }
                }
                if(at == 11)
                {
                    if (ap > 7)
                    {
                        at = 10;
                        ap = 0;
                    }
                }
                bi.actions.Add(ai);
            }
            temp.beatsInfo.Add(bi);
        }
        SaveAFile(temp, "./Data/TestNewFunctions.info");
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

    void KnifeBoss1Phase1Hard()
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
        SaveAFile(temp, "./Data/KnifeBoss1Phase1Hard.info");
    }

    void KnifeBoss1Phase1Easy()
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

            if (i == 4)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
            }
            if (i == 8)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(6);
                bi.actions.Add(ai2);
            }
            if (i == 12)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 16)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(8);
                bi.actions.Add(ai2);
            }
            if (i == 20)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 4;
                ai2.actionParameters.Add(6);
                bi.actions.Add(ai2);
            }
            if (i == 24)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 25)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(7);
                bi.actions.Add(ai2);
            }
            if (i == 26)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 27)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);
            }
            if (i == 28)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 29)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);
            }
            if (i == 30)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 31)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);
            }
            //Section2,Beat32-95
            if (i == 32 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 5;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(0);
                bi.actions.Add(ai2);
            }
            if (i == 33)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(9);
                bi.actions.Add(ai);
            }
            if (i == 34)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);
            }
            if (i == 36 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 6;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);
            }
            if (i == 37)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 38)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 40 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);
            }
            if (i == 41)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
            }
            if (i == 42)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 43)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 44 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(6);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(1);
                bi.actions.Add(ai2);
            }
            if (i == 45)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);
            }
            if (i == 46)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);
            }
            if (i == 48 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 5;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(0);
                bi.actions.Add(ai2);
            }
            if (i == 49)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
            }
            if (i == 50)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(6);
                bi.actions.Add(ai);
            }
            if (i == 51)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(8);
                bi.actions.Add(ai);
            }
            if (i == 52 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 6;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(0);
                bi.actions.Add(ai2);
            }
            if (i == 53)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(5);
                bi.actions.Add(ai);
            }
            if (i == 54)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);
            }
            if (i == 55)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);
            }
            if (i == 56 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);
            }
            if (i == 58)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 4;
                ai2.actionParameters.Add(3);
                bi.actions.Add(ai2);
            }
            if (i == 60 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(1);
                bi.actions.Add(ai2);
            }
            if (i == 62)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(6);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 4;
                ai2.actionParameters.Add(8);
                bi.actions.Add(ai2);
            }
            if (i >= 63 && i <= 76)
            {
                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 1;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);
            }
            if (i == 64 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 7;
                ai2.actionParameters.Add(6);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 12;
                ai3.actionParameters.Add(3);
                bi.actions.Add(ai3);
            }
            if (i == 68 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 7;
                ai2.actionParameters.Add(9);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 12;
                ai3.actionParameters.Add(3);
                bi.actions.Add(ai3);
            }
            if (i == 72 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 7;
                ai2.actionParameters.Add(5);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 12;
                ai3.actionParameters.Add(3);
                bi.actions.Add(ai3);
            }
            if (i == 76 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 7;
                ai2.actionParameters.Add(8);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 12;
                ai3.actionParameters.Add(3);
                bi.actions.Add(ai3);
            }
            if (i >= 77 && i <= 92)
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
            if (i == 78 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(0);
                bi.actions.Add(ai2);
            }
            if (i == 80 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(0);
                bi.actions.Add(ai2);
            }
            if (i == 82 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(6);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(0);
                bi.actions.Add(ai2);
            }
            if (i == 84 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(0);
                bi.actions.Add(ai2);
            }
            if (i == 86 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(9);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(0);
                bi.actions.Add(ai2);
            }
            if (i == 88 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(0);
                bi.actions.Add(ai2);
            }
            if (i == 90 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(8);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(0);
                bi.actions.Add(ai2);
            }
            if (i == 92 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(4);
                bi.actions.Add(ai2);
            }
            if (i == 94 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(6);
                bi.actions.Add(ai);

                //ActionInfo ai2 = new ActionInfo();
                //ai2.actionType = 12;
                //ai2.actionParameters.Add(0);
                //bi.actions.Add(ai2);

                //ActionInfo ai3 = new ActionInfo();
                //ai3.actionType = 12;
                //ai3.actionParameters.Add(4);
                //bi.actions.Add(ai3);
            }
            //Section3,Beat96-159
            if (i == 96 || i == 104)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 97 || i == 105)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);
            }
            if (i == 98 || i == 106)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 99 || i == 107)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);
            }
            if (i == 100 || i == 108)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
            }
            if (i == 101 || i == 109)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(5);
                bi.actions.Add(ai);
            }
            if (i == 102 || i == 110)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(6);
                bi.actions.Add(ai);
            }
            if (i == 103 || i == 111)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);
            }
            if (i == 111)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 12;
                ai.actionParameters.Add(5);
                bi.actions.Add(ai);
            }
            if (i == 112 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 5;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 6;
                ai2.actionParameters.Add(0);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 7;
                ai3.actionParameters.Add(9);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 8;
                ai4.actionParameters.Add(0);
                bi.actions.Add(ai4);

                ActionInfo ai5 = new ActionInfo();
                ai5.actionType = 12;
                ai5.actionParameters.Add(3);
                bi.actions.Add(ai5);
            }
            if (i == 112)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(1);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(8);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 4;
                ai4.actionParameters.Add(1);
                bi.actions.Add(ai4);
            }
            if (i == 120 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 5;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 6;
                ai2.actionParameters.Add(4);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 7;
                ai3.actionParameters.Add(0);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 8;
                ai4.actionParameters.Add(9);
                bi.actions.Add(ai4);

                ActionInfo ai5 = new ActionInfo();
                ai5.actionType = 12;
                ai5.actionParameters.Add(3);
                bi.actions.Add(ai5);
            }
            if (i == 120)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(6);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 4;
                ai3.actionParameters.Add(3);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 4;
                ai4.actionParameters.Add(7);
                bi.actions.Add(ai4);
            }
            if (i == 124)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(8);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 4;
                ai3.actionParameters.Add(2);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 4;
                ai4.actionParameters.Add(7);
                bi.actions.Add(ai4);
            }
            if (i == 128)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
            }
            if (i == 129)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);
            }
            if (i == 130)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 131 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 6;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);
            }
            if (i == 132 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 6;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);
            }
            if (i == 133 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 6;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 136)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 137)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);
            }
            if (i == 138)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 139 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 5;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(1);
                bi.actions.Add(ai2);
            }
            if (i == 140 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 5;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);
            }
            if (i == 141 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 5;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 144)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(8);
                bi.actions.Add(ai);
            }
            if (i == 145)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(6);
                bi.actions.Add(ai);
            }
            if (i == 146)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
            }
            if (i == 147 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(8);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(0);
                bi.actions.Add(ai2);
            }
            if (i == 148 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(6);
                bi.actions.Add(ai);
            }
            if (i == 149 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
            }
            if (i == 152)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);
            }
            if (i == 153)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);
            }
            if (i == 154)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(5);
                bi.actions.Add(ai);
            }
            if (i == 156 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 8;
                ai2.actionParameters.Add(3);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 8;
                ai3.actionParameters.Add(5);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 12;
                ai4.actionParameters.Add(3);
                bi.actions.Add(ai4);
            }
            //Section4,Beat160-223
            if (i == 160 || i == 176)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(9);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(5);
                bi.actions.Add(ai2);
            }
            if (i == 161 || i == 177)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(8);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(4);
                bi.actions.Add(ai2);
            }
            if (i == 162 || i == 178)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(3);
                bi.actions.Add(ai2);
            }
            if (i == 163 || i == 179)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(6);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);
            }
            if (i == 164 - bossSolidDelay || i == 180 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(8);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(3);
                bi.actions.Add(ai2);
            }
            if (i == 165 - bossSolidDelay || i == 181 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(6);
                bi.actions.Add(ai);
            }
            if (i == 166 - bossSolidDelay || i == 182 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
            }
            if (i == 167 - bossSolidDelay || i == 183 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 168 || i == 184)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(4);
                bi.actions.Add(ai2);
            }
            if (i == 169 || i == 185)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(5);
                bi.actions.Add(ai2);
            }
            if (i == 170 || i == 186)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(6);
                bi.actions.Add(ai2);
            }
            if (i == 171 || i == 187)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(7);
                bi.actions.Add(ai2);
            }
            if (i == 172 - bossSolidDelay || i == 188 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 12;
                ai2.actionParameters.Add(3);
                bi.actions.Add(ai2);
            }
            if (i == 173 - bossSolidDelay || i == 189 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);
            }
            if (i == 174 - bossSolidDelay || i == 190 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(5);
                bi.actions.Add(ai);
            }
            if (i == 175 - bossSolidDelay || i == 191 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);
            }
            if (i == 188)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 12;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
            }
            if (i == 192 || i == 200 || i == 208)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 193 || i == 201 || i == 209)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);
            }
            if (i == 194 || i == 202 || i == 210)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 195 || i == 203 || i == 211)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);
            }
            if (i == 196 || i == 204 || i == 212)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
            }
            if (i == 197 || i == 205 || i == 213)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(5);
                bi.actions.Add(ai);
            }
            if (i == 198 || i == 206 || i == 214)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(6);
                bi.actions.Add(ai);
            }
            if (i == 199 || i == 207 || i == 215)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);
            }
            if (i == 215)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 12;
                ai.actionParameters.Add(5);
                bi.actions.Add(ai);
            }
            if (i >= 190 && i <= 220)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(0);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(8);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 4;
                ai4.actionParameters.Add(1);
                bi.actions.Add(ai4);
            }
            if (i >= 208 && i <= 220)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(9);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 4;
                ai3.actionParameters.Add(0);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 4;
                ai4.actionParameters.Add(2);
                bi.actions.Add(ai4);
            }
            if (i >= 216 && i <= 220)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(1);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(6);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 4;
                ai4.actionParameters.Add(3);
                bi.actions.Add(ai4);
            }
            if (i == 222 || i == 224 || i == 226)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 1;
                ai2.actionParameters.Add(4);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 2;
                ai3.actionParameters.Add(1);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 2;
                ai4.actionParameters.Add(0);
                bi.actions.Add(ai4);
            }
            if (i == 232)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(1);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(4);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 3;
                ai4.actionParameters.Add(5);
                bi.actions.Add(ai4);

                ActionInfo ai5 = new ActionInfo();
                ai5.actionType = 3;
                ai5.actionParameters.Add(8);
                bi.actions.Add(ai5);

                ActionInfo ai6 = new ActionInfo();
                ai6.actionType = 3;
                ai6.actionParameters.Add(9);
                bi.actions.Add(ai6);
            }
            if (i == 236)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(3);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 3;
                ai4.actionParameters.Add(6);
                bi.actions.Add(ai4);

                ActionInfo ai5 = new ActionInfo();
                ai5.actionType = 3;
                ai5.actionParameters.Add(7);
                bi.actions.Add(ai5);

                ActionInfo ai6 = new ActionInfo();
                ai6.actionType = 3;
                ai6.actionParameters.Add(8);
                bi.actions.Add(ai6);
            }
            if (i == 240)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(4);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 3;
                ai4.actionParameters.Add(5);
                bi.actions.Add(ai4);

                ActionInfo ai6 = new ActionInfo();
                ai6.actionType = 3;
                ai6.actionParameters.Add(7);
                bi.actions.Add(ai6);
            }
            if (i == 244)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(4);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 3;
                ai4.actionParameters.Add(6);
                bi.actions.Add(ai4);

                ActionInfo ai5 = new ActionInfo();
                ai5.actionType = 3;
                ai5.actionParameters.Add(8);
                bi.actions.Add(ai5);
            }
            if (i == 246)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(3);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(5);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 3;
                ai4.actionParameters.Add(7);
                bi.actions.Add(ai4);

                ActionInfo ai5 = new ActionInfo();
                ai5.actionType = 3;
                ai5.actionParameters.Add(9);
                bi.actions.Add(ai5);
            }
            if (i == 248)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(2);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 3;
                ai4.actionParameters.Add(7);
                bi.actions.Add(ai4);

                ActionInfo ai6 = new ActionInfo();
                ai6.actionType = 3;
                ai6.actionParameters.Add(9);
                bi.actions.Add(ai6);
            }
            //End Adding ActionInfo
            temp.beatsInfo.Add(bi);
        }
        SaveAFile(temp, "./Data/KnifeBoss1Phase1Easy.info");
    }

    void KnifeBoss1Phase2Easy()
    {
        int bossSolidDelay = 0;
        SongInfo temp = new SongInfo();
        temp.length = 256;
        temp.interval = 0.5f;
        for (int i = 0; i < 128; i++)
        {
            BeatInfo bi = new BeatInfo();
            bi.index = i;
            //Add ActionInfo
            //Section1,Beat0-31
            if (i == 2)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);
            }
            if (i == 4 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);
            }
            if (i == 6)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 8 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 10)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(7);
                bi.actions.Add(ai2);
            }
            if (i == 12 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 7;
                ai2.actionParameters.Add(7);
                bi.actions.Add(ai2);
            }
            if (i == 16)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 10;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 10;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);
            }
            if (i == 24)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 10;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 10;
                ai2.actionParameters.Add(3);
                bi.actions.Add(ai2);
            }
            //Section2,Beat32-63
            if (i == 32)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 33)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 34)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
            }
            if (i == 35 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 36 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 37 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
            }
            if (i == 40)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(9);
                bi.actions.Add(ai);
            }
            if (i == 41)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);
            }
            if (i == 42)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(5);
                bi.actions.Add(ai);
            }
            if (i == 43 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(9);
                bi.actions.Add(ai);
            }
            if (i == 44 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);
            }
            if (i == 45 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(5);
                bi.actions.Add(ai);
            }
            if (i >= 48 && i <= 51)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 9;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 52 || i == 60)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 53 || i == 61)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);
            }
            if (i == 54 || i == 62)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 55 || i == 63)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);
            }
            if (i == 56)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
            }
            if (i == 57)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(5);
                bi.actions.Add(ai);
            }
            if (i == 58)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(6);
                bi.actions.Add(ai);
            }
            if (i == 59)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);
            }
            //Section3,Beat64-95
            if (i == 64)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(8);
                bi.actions.Add(ai2);
            }
            if (i == 66 - bossSolidDelay)
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
            if (i == 68)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(6);
                bi.actions.Add(ai2);
            }
            if (i == 70 - bossSolidDelay)
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
            if (i == 72)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(4);
                bi.actions.Add(ai3);
            }
            if (i == 74 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 7;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 7;
                ai3.actionParameters.Add(4);
                bi.actions.Add(ai3);
            }
            if (i == 76)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(9);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(5);
                bi.actions.Add(ai3);
            }
            if (i == 78 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 7;
                ai2.actionParameters.Add(9);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 7;
                ai3.actionParameters.Add(5);
                bi.actions.Add(ai3);
            }
            if (i == 80)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 10;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 10;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);
            }
            if (i == 88)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 10;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 10;
                ai2.actionParameters.Add(3);
                bi.actions.Add(ai2);
            }
            //Section3,Beat96-127
            if (i >= 96 && i <= 99)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 9;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 100 || i == 108)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 101 || i == 109)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);
            }
            if (i == 102 || i == 110)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 103 || i == 111)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);
            }
            if (i == 104)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
            }
            if (i == 105)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(5);
                bi.actions.Add(ai);
            }
            if (i == 106)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(6);
                bi.actions.Add(ai);
            }
            if (i == 107)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);
            }
            if (i == 112 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 5;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 6;
                ai2.actionParameters.Add(0);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 7;
                ai3.actionParameters.Add(9);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 8;
                ai4.actionParameters.Add(0);
                bi.actions.Add(ai4);
            }
            if (i == 112)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(1);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(8);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 4;
                ai4.actionParameters.Add(1);
                bi.actions.Add(ai4);
            }
            if (i == 120 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 5;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 6;
                ai2.actionParameters.Add(4);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 7;
                ai3.actionParameters.Add(0);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 8;
                ai4.actionParameters.Add(9);
                bi.actions.Add(ai4);
            }
            if (i == 120)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(6);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 4;
                ai3.actionParameters.Add(3);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 4;
                ai4.actionParameters.Add(7);
                bi.actions.Add(ai4);
            }
            if (i == 124)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(8);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 4;
                ai3.actionParameters.Add(2);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 4;
                ai4.actionParameters.Add(7);
                bi.actions.Add(ai4);
            }
            //End Adding ActionInfo
            temp.beatsInfo.Add(bi);
        }
        SaveAFile(temp, "./Data/KnifeBoss1Phase2Easy.info");
    }
    void SaveAFile(SongInfo info, string path)
    {
        string jsonstr = JsonMapper.ToJson(info);
        File.WriteAllText(path, jsonstr);
    }
}
