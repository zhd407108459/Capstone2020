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
        //KnifeBoss1Phase1Easy();
        //KnifeBoss1Phase2Easy();
        //KnifeBoss1Phase1Normal();
        //KnifeBoss1Phase2Normal();
        //KnifeBoss1Phase1Hard();
        KnifeBoss1Phase2Hard();
        Boss2ExampleFile();
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
        int animationSolidDelay = 1;
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
            if (i == 32 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 34) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
            }
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
            if (i == 36) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
            }
            if (i == 36 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 38) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
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
            if (i == 40) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
            }
            if (i == 40 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(0);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 42 || i == 44 || i == 46 || i == 48) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
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
            if (i == 54 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(2);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 56) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
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
            if (i == 64 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(0);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 66 || i == 67 || i == 68) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
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
            if (i == 69 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(0);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 71 || i == 72 || i == 73) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
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
            if (i == 72 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(1);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 74 || i == 75 || i == 76) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
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
            if (i == 76 - animationSolidDelay || i == 84 - animationSolidDelay || i == 92 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 78 || i == 86 || i == 94) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
            }
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
            if (i == 80 - animationSolidDelay || i == 88 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 82 || i == 90) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
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
            if (i == 96 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 98 || i == 99) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
            }
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
            if (i == 100 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 102 || i == 103) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
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
            if (i == 103 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(2);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 105 || i == 107) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
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
            if (i == 107 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 109 || i == 111) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
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
            if (i == 120 - animationSolidDelay || i == 124 - animationSolidDelay || i == 128 - animationSolidDelay || i == 132 - animationSolidDelay || i == 136 - animationSolidDelay || i == 140 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(2);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 122 || i == 126 || i == 130 || i == 134 || i == 138 || i == 142) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
            }
            if (i == 120 - bossSolidDelay || i == 140 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 6;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
            }
            if (i == 124 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 6;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);
            }
            if (i == 128 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 6;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);
            }
            if (i == 132 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 6;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 136 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 6;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 144 - animationSolidDelay || i == 148 - animationSolidDelay || i == 152 - animationSolidDelay || i == 156 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 146 || i == 148 || i == 150 || i == 152 || i == 154 || i == 156 || i == 158) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
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
                ai4.actionType = 8;
                ai4.actionParameters.Add(7);
                bi.actions.Add(ai4);

                ActionInfo ai5 = new ActionInfo();
                ai5.actionType = 8;
                ai5.actionParameters.Add(9);
                bi.actions.Add(ai5);
            }
            //Section3,Beat160-223
            //Interfere vertical jellyfish
            if (i == 160 || i == 168 || i == 176 || i == 184 || i == 204 || i == 220)
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
            }
            if (i == 162 || i == 170 || i == 178 || i == 186 || i == 200 || i == 216)
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
            }
            if (i == 164 || i == 172 || i == 180 || i == 188 || i == 196 || i == 212)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(4);
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
            if (i == 166 || i == 174 || i == 182 || i == 190 || i == 192 || i == 208)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(5);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(7);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 3;
                ai4.actionParameters.Add(9);
                bi.actions.Add(ai4);
            }
            //Eye
            if (i == 171 || i == 203)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 12;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(8);
                bi.actions.Add(ai13);
            }
            if (i >= 176 && i <= 191) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(9);
                bi.actions.Add(ai13);
            }
            if (i >= 208 && i <= 223) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(9);
                bi.actions.Add(ai13);
            }
            if (i == 176 || i == 184 || i == 208 || i == 216)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 177 || i == 185 || i == 209 || i == 217)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);
            }
            if (i == 178 || i == 186 || i == 210 || i == 218)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 179 || i == 187 || i == 211 || i == 219)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);
            }
            if (i == 180 || i == 188 || i == 212 || i == 220)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
            }
            if (i == 181 || i == 189 || i == 213 || i == 221)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(5);
                bi.actions.Add(ai);
            }
            if (i == 182 || i == 190 || i == 214 || i == 222)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(6);
                bi.actions.Add(ai);
            }
            if (i == 183 || i == 191 || i == 215 || i == 223)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 11;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);
            }
            if (i == 192 || i == 224)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 12;
                ai.actionParameters.Add(5);
                bi.actions.Add(ai);
            }
            //Blade rain
            if (i == 191 - animationSolidDelay || i == 199 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(2);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 193 || i == 201 || i == 194 || i == 195) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
            }
            if (i == 191 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 192 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 193 - bossSolidDelay)
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
            if (i == 195 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(1);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 197 || i == 198 || i == 199) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
            }
            if (i == 195 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(9);
                bi.actions.Add(ai);
            }
            if (i == 196 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);
            }
            if (i == 197 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(5);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 8;
                ai2.actionParameters.Add(3);
                bi.actions.Add(ai2);
            }
            if (i == 201 || i == 202 || i == 203) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
            }
            if (i == 199 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);
            }
            if (i == 200 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);
            }
            if (i == 201 - bossSolidDelay)
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
            if (i == 205 || i == 206 || i == 207) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
            }
            if (i == 203 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(8);
                bi.actions.Add(ai);
            }
            if (i == 204 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(6);
                bi.actions.Add(ai);
            }
            if (i == 205 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 8;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);
            }
            if (i == 207 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(2);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 209 || i == 210 || i == 211) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
            }
            if (i == 207 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 208 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(5);
                bi.actions.Add(ai);
            }
            if (i == 209 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 213 || i == 214 || i == 215) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
            }
            if (i == 211 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(9);
                bi.actions.Add(ai);
            }
            if (i == 212 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
            }
            if (i == 213 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);
            }
            if (i == 217 || i == 218 || i == 219) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
            }
            if (i == 215 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);
            }
            if (i == 216 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(8);
                bi.actions.Add(ai);
            }
            if (i == 217 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 8;
                ai2.actionParameters.Add(6);
                bi.actions.Add(ai2);
            }
            if (i == 221 || i == 222 || i == 223) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
            }
            if (i == 219 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);
            }
            if (i == 220 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 221 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 8;
                ai2.actionParameters.Add(9);
                bi.actions.Add(ai2);
            }
            //Section4,Beat224-255
            //Circle A
            if (i == 224 || i == 225 || i == 226)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(3);
                bi.actions.Add(ai2);
            }
            if (i == 225)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 4;
                ai2.actionParameters.Add(5);
                bi.actions.Add(ai2);
            }
            if (i == 228 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 230) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
            }
            if (i == 228 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 5;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 8;
                ai2.actionParameters.Add(5);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 6;
                ai3.actionParameters.Add(3);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 7;
                ai4.actionParameters.Add(1);
                bi.actions.Add(ai4);
            }
            //Circle B
            if (i == 232 || i == 233 || i == 234)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(1);
                bi.actions.Add(ai2);
            }
            if (i == 233)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(8);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 4;
                ai3.actionParameters.Add(3);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 4;
                ai4.actionParameters.Add(4);
                bi.actions.Add(ai4);
            }
            if (i == 236 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 238) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
            }
            if (i == 236 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 5;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 7;
                ai2.actionParameters.Add(7);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 7;
                ai3.actionParameters.Add(8);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 6;
                ai4.actionParameters.Add(1);
                bi.actions.Add(ai4);

                ActionInfo ai5 = new ActionInfo();
                ai5.actionType = 8;
                ai5.actionParameters.Add(3);
                bi.actions.Add(ai5);

                ActionInfo ai6 = new ActionInfo();
                ai6.actionType = 8;
                ai6.actionParameters.Add(4);
                bi.actions.Add(ai6);
            }
            //Circle C
            if (i == 240 || i == 241 || i == 242)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 1;
                ai2.actionParameters.Add(1);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 2;
                ai3.actionParameters.Add(3);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 2;
                ai4.actionParameters.Add(4);
                bi.actions.Add(ai4);
            }
            if (i == 241)
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
                ai3.actionParameters.Add(2);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 3;
                ai4.actionParameters.Add(4);
                bi.actions.Add(ai4);

                ActionInfo ai5 = new ActionInfo();
                ai5.actionType = 4;
                ai5.actionParameters.Add(5);
                bi.actions.Add(ai5);

                ActionInfo ai6 = new ActionInfo();
                ai6.actionType = 4;
                ai6.actionParameters.Add(7);
                bi.actions.Add(ai6);

                ActionInfo ai7 = new ActionInfo();
                ai7.actionType = 4;
                ai7.actionParameters.Add(8);
                bi.actions.Add(ai7);

                ActionInfo ai8 = new ActionInfo();
                ai8.actionType = 4;
                ai8.actionParameters.Add(9);
                bi.actions.Add(ai8);
            }
            if (i == 244 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 246) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
            }
            if (i == 244 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 5;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 5;
                ai2.actionParameters.Add(1);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 8;
                ai3.actionParameters.Add(5);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 8;
                ai4.actionParameters.Add(7);
                bi.actions.Add(ai4);

                ActionInfo ai5 = new ActionInfo();
                ai5.actionType = 8;
                ai5.actionParameters.Add(8);
                bi.actions.Add(ai5);

                ActionInfo ai6 = new ActionInfo();
                ai6.actionType = 8;
                ai6.actionParameters.Add(9);
                bi.actions.Add(ai6);

                ActionInfo ci = new ActionInfo();
                ci.actionType = 6;
                ci.actionParameters.Add(3);
                bi.actions.Add(ci);

                ActionInfo ci2 = new ActionInfo();
                ci2.actionType = 6;
                ci2.actionParameters.Add(4);
                bi.actions.Add(ci2);

                ActionInfo ci3 = new ActionInfo();
                ci3.actionType = 7;
                ci3.actionParameters.Add(0);
                bi.actions.Add(ci3);

                ActionInfo ci4 = new ActionInfo();
                ci4.actionType = 7;
                ci4.actionParameters.Add(1);
                bi.actions.Add(ci4);

                ActionInfo ci5 = new ActionInfo();
                ci5.actionType = 7;
                ci5.actionParameters.Add(2);
                bi.actions.Add(ci5);

                ActionInfo ci6 = new ActionInfo();
                ci6.actionType = 7;
                ci6.actionParameters.Add(4);
                bi.actions.Add(ci6);
            }
            //Final
            if (i == 248)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(3);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(6);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 3;
                ai4.actionParameters.Add(9);
                bi.actions.Add(ai4);
            }
            if (i == 250)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 4;
                ai2.actionParameters.Add(4);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 4;
                ai3.actionParameters.Add(5);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 4;
                ai4.actionParameters.Add(8);
                bi.actions.Add(ai4);
            }
            if (i == 252)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(4);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(7);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 4;
                ai4.actionParameters.Add(2);
                bi.actions.Add(ai4);

                ActionInfo ai5 = new ActionInfo();
                ai5.actionType = 4;
                ai5.actionParameters.Add(5);
                bi.actions.Add(ai5);

                ActionInfo ai6 = new ActionInfo();
                ai6.actionType = 4;
                ai6.actionParameters.Add(9);
                bi.actions.Add(ai6);
            }
            //End Adding ActionInfo
            temp.beatsInfo.Add(bi);
        }            
        SaveAFile(temp, "./Data/KnifeBoss1Phase1Hard.info");
    }

    void KnifeBoss1Phase2Hard()
    {
        int bossSolidDelay = 0;
        int animationSolidDelay = 1;
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
                ai.actionParameters.Add(8);
                bi.actions.Add(ai);
            }
            if (i == 3)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);
            }
            if (i == 4)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(6);
                bi.actions.Add(ai);
            }
            if (i == 4 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(1);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 6 || i == 7 || i == 8) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
            }
            if (i == 4 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(8);
                bi.actions.Add(ai);
            }
            if (i == 5 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);
            }
            if (i == 6 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(6);
                bi.actions.Add(ai);
            }
            if (i == 6)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);
            }
            if (i == 7)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 8)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);
            }
            if (i == 8 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(2);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 10 || i == 11 || i == 12) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
            }
            if (i == 8 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);
            }
            if (i == 9 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 10 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);
            }
            if (i == 10)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(4);
                bi.actions.Add(ai2);
            }
            if (i == 12 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(0);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 14) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
            }
            if (i == 12 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 5;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 6;
                ai2.actionParameters.Add(4);
                bi.actions.Add(ai2);
            }
            //Show Bomb & Bullets
            if (i == 16 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(0);
                bi.actions.Add(ai12);
            }
            if (i == 16 || i == 20) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(9);
                bi.actions.Add(ai13);
            }
            if (i == 16)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 10;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 20)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 10;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);
            }
            if (i == 15 || i == 19)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
            }
            if (i == 16 || i == 18)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 17)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            //Converted
            if (i == 24 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(0);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 24 || i == 28) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(9);
                bi.actions.Add(ai13);
            }
            if (i == 24)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 10;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 28)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 10;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);
            }
            if (i == 25)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
            }
            if (i == 24 || i == 26)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 23 || i == 27)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            //Section2,Beat32-63
            if (i == 32)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(4);
                bi.actions.Add(ai2);
            }
            if (i == 33)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);
            }
            if (i == 34)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 2;
                ai2.actionParameters.Add(0);
                bi.actions.Add(ai2);
            }
            if (i == 35 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 37 || i == 38 || i == 39) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
            }
            if (i == 35 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 6;
                ai2.actionParameters.Add(4);
                bi.actions.Add(ai2);
            }
            if (i == 36 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 6;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);
            }
            if (i == 37 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 6;
                ai2.actionParameters.Add(0);
                bi.actions.Add(ai2);
            }
            if (i == 40)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(9);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 1;
                ai2.actionParameters.Add(4);
                bi.actions.Add(ai2);
            }
            if (i == 41)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 1;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);
            }
            if (i == 42)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(5);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 1;
                ai2.actionParameters.Add(0);
                bi.actions.Add(ai2);
            }
            if (i == 43 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 45 || i == 46 || i == 47) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
            }
            if (i == 43 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(9);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 5;
                ai2.actionParameters.Add(4);
                bi.actions.Add(ai2);
            }
            if (i == 44 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 5;
                ai2.actionParameters.Add(2);
                bi.actions.Add(ai2);
            }
            if (i == 45 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(5);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 5;
                ai2.actionParameters.Add(0);
                bi.actions.Add(ai2);
            }
            //Eye
            if (i == 47)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 12;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(8);
                bi.actions.Add(ai13);
            }
            if (i >= 52 && i <= 63 )
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(9);
                bi.actions.Add(ai13);
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
            if (i == 64)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 12;
                ai.actionParameters.Add(5);
                bi.actions.Add(ai);
            }
            //Rising jellyfish
            if (i == 48)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 4;
                ai2.actionParameters.Add(9);
                bi.actions.Add(ai2);
            }
            if (i == 50 || i == 62)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 4;
                ai2.actionParameters.Add(8);
                bi.actions.Add(ai2);
            }
            if (i == 52 || i == 60)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 4;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 4;
                ai2.actionParameters.Add(7);
                bi.actions.Add(ai2);
            }
            if (i == 54 || i == 58)
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
            if (i == 56)
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
            //Section3,Beat64-95
            if (i == 64)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(7);
                bi.actions.Add(ai2);
            }
            if (i == 65)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(8);
                bi.actions.Add(ai2);
            }
            if (i == 66 - animationSolidDelay || i == 70 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 68 || i == 72 || i == 69 || i == 73) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
            }
            if (i == 66 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 7;
                ai2.actionParameters.Add(7);
                bi.actions.Add(ai2);
            }
            if (i == 67 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(2);
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
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(9);
                bi.actions.Add(ai2);
            }
            if (i == 69)
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
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 7;
                ai2.actionParameters.Add(9);
                bi.actions.Add(ai2);
            }
            if (i == 71 - bossSolidDelay)
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
            if (i == 74 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 76) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
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
            if (i == 78 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 80) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
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
            //Show Bomb & Bullets
            if (i == 80 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(0);
                bi.actions.Add(ai12);
            }
            if (i == 80 || i == 84) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(9);
                bi.actions.Add(ai13);
            }
            if (i == 80)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 10;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 84)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 10;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);
            }
            if (i == 81)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 80 || i == 82)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 79 || i == 83)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 2;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
            }
            //Converted
            if (i == 88 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(0);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 88 || i == 92)
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(9);
                bi.actions.Add(ai13);
            }
            if (i == 88)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 10;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 92)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 10;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);
            }
            if (i == 87 || i == 91)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 88 || i == 90)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 89)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 1;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
            }
            //Section3,Beat96-127
            //Eye
            if (i == 95)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 12;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(8);
                bi.actions.Add(ai13);
            }
            if (i >= 100 && i <= 111) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(9);
                bi.actions.Add(ai13);
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
            if (i == 112)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 12;
                ai.actionParameters.Add(5);
                bi.actions.Add(ai);
            }
            //Fallilng Jellyfish
            if (i == 96 || i == 104)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(6);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(9);
                bi.actions.Add(ai3);
            }
            if (i == 98 || i == 106)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(5);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(8);
                bi.actions.Add(ai3);
            }
            if (i == 100 || i == 108)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 3;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 3;
                ai2.actionParameters.Add(4);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 3;
                ai3.actionParameters.Add(7);
                bi.actions.Add(ai3);
            }
            if (i == 102 || i == 110)
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
                ai3.actionParameters.Add(5);
                bi.actions.Add(ai3);
            }
            //Rest
            if (i == 112)
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
                ai3.actionParameters.Add(9);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 4;
                ai4.actionParameters.Add(0);
                bi.actions.Add(ai4);
            }
            if (i == 114 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 116) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
            }
            if (i == 114 - bossSolidDelay)
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
            if (i == 116)
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
            if (i == 118 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);

                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(6);
                bi.actions.Add(ai13);
            }
            if (i == 120) //sfx
            {
                ActionInfo ai13 = new ActionInfo();
                ai13.actionType = 12;
                ai13.actionParameters.Add(7);
                bi.actions.Add(ai13);
            }
            if (i == 118 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 5;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);

                ActionInfo ai2 = new ActionInfo();
                ai2.actionType = 6;
                ai2.actionParameters.Add(3);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 7;
                ai3.actionParameters.Add(1);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 8;
                ai4.actionParameters.Add(8);
                bi.actions.Add(ai4);
            }
            if (i == 120 || i == 124)
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
            if (i == 122 || i == 126)
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
            //End Adding ActionInfo
            temp.beatsInfo.Add(bi);
        }
        SaveAFile(temp, "./Data/KnifeBoss1Phase2Hard.info");
    }

    void KnifeBoss1Phase1Normal()
    {
        int bossSolidDelay = 0;
        int animationSolidDelay = 1;
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
            if (i == 32 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(0);
                bi.actions.Add(ai12);
            }
            if (i == 32 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 5;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
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
            if (i == 32 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(2);
                bi.actions.Add(ai12);
            }
            if (i == 36 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 6;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
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
            if (i == 40 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(2);
                bi.actions.Add(ai12);
            }
            if (i == 40 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);
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
            if (i == 44 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(1);
                bi.actions.Add(ai12);
            }
            if (i == 44 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(6);
                bi.actions.Add(ai);
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
            if (i == 48 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(0);
                bi.actions.Add(ai12);
            }
            if (i == 48 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 5;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
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
            if (i == 52 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(0);
                bi.actions.Add(ai12);
            }
            if (i == 52 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 6;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
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
            if (i == 56 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(2);
                bi.actions.Add(ai12);
            }
            if (i == 56 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
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
            if (i == 60 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(1);
                bi.actions.Add(ai12);
            }
            if (i == 60 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);
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
            if (i == 64 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);
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
            }
            if (i == 68 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);
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
            }
            if (i == 72 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);
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
            }
            if (i == 76 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);
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
            if (i == 78 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(0);
                bi.actions.Add(ai12);
            }
            if (i == 78 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(7);
                bi.actions.Add(ai);
            }
            if (i == 80 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(0);
                bi.actions.Add(ai12);
            }
            if (i == 80 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);
            }
            if (i == 82 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(0);
                bi.actions.Add(ai12);
            }
            if (i == 82 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(6);
                bi.actions.Add(ai);
            }
            if (i == 84 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(0);
                bi.actions.Add(ai12);
            }
            if (i == 84 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(3);
                bi.actions.Add(ai);
            }
            if (i == 86 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(0);
                bi.actions.Add(ai12);
            }
            if (i == 86 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(9);
                bi.actions.Add(ai);
            }
            if (i == 88 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(0);
                bi.actions.Add(ai12);
            }
            if (i == 88 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(2);
                bi.actions.Add(ai);
            }
            if (i == 90 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(0);
                bi.actions.Add(ai12);
            }
            if (i == 90 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(8);
                bi.actions.Add(ai);
            }
            if (i == 92 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
            }
            if (i == 94 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 8;
                ai.actionParameters.Add(6);
                bi.actions.Add(ai);
            }
            if (i == 91)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 12;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
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
            if (i == 112)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 12;
                ai.actionParameters.Add(5);
                bi.actions.Add(ai);
            }
            if (i == 112 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);
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
            if (i == 120 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);
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
            if (i == 131 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(2);
                bi.actions.Add(ai12);
            }
            if (i == 131 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 6;
                ai.actionParameters.Add(4);
                bi.actions.Add(ai);
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
            if (i == 139 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(1);
                bi.actions.Add(ai12);
            }
            if (i == 139 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 5;
                ai.actionParameters.Add(0);
                bi.actions.Add(ai);
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
            if (i == 147 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(0);
                bi.actions.Add(ai12);
            }
            if (i == 147 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(8);
                bi.actions.Add(ai);
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
            if (i == 156 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);
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
            if (i == 164 - animationSolidDelay || i == 180 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);
            }
            if (i == 164 - bossSolidDelay || i == 180 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(8);
                bi.actions.Add(ai);
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
            if (i == 172 - animationSolidDelay || i == 188 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);
            }
            if (i == 172 - bossSolidDelay || i == 188 - bossSolidDelay)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 7;
                ai.actionParameters.Add(1);
                bi.actions.Add(ai);
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
            if (i == 187)
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
            if (i == 216)
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
                ai3.actionParameters.Add(9);
                bi.actions.Add(ai3);

                ActionInfo ai4 = new ActionInfo();
                ai4.actionType = 4;
                ai4.actionParameters.Add(0);
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
                ai2.actionParameters.Add(8);
                bi.actions.Add(ai2);

                ActionInfo ai3 = new ActionInfo();
                ai3.actionType = 4;
                ai3.actionParameters.Add(1);
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
        SaveAFile(temp, "./Data/KnifeBoss1Phase1Normal.info");
    }

    void KnifeBoss1Phase2Normal()
    {
        int bossSolidDelay = 0;
        int animationSolidDelay = 1;
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
            if (i == 4 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(1);
                bi.actions.Add(ai12);
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
            if (i == 8 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(2);
                bi.actions.Add(ai12);
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
            if (i == 12 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);
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
            if (i == 16 - animationSolidDelay || i == 24 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(0);
                bi.actions.Add(ai12);
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
            if (i == 35 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);
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
            if (i == 43 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);
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
            if (i == 47)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 12;
                ai.actionParameters.Add(4);
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
            if (i == 64)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 12;
                ai.actionParameters.Add(5);
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
            if (i == 66 - animationSolidDelay || i == 70 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);
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
            if (i == 74 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);
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
            if (i == 78 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);
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
            if (i == 80 - animationSolidDelay || i == 88 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(0);
                bi.actions.Add(ai12);
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
            if (i == 95)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 12;
                ai.actionParameters.Add(4);
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
            if (i == 112)
            {
                ActionInfo ai = new ActionInfo();
                ai.actionType = 12;
                ai.actionParameters.Add(5);
                bi.actions.Add(ai);
            }
            if (i == 112 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);
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
            if (i == 120 - animationSolidDelay)
            {
                ActionInfo ai12 = new ActionInfo();
                ai12.actionType = 12;
                ai12.actionParameters.Add(3);
                bi.actions.Add(ai12);
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
        SaveAFile(temp, "./Data/KnifeBoss1Phase2Normal.info");
    }

    void Boss2ExampleFile()
    {
        SongInfo temp = new SongInfo();
        temp.length = 256;
        temp.interval = 0.5f;
        for (int i = 0; i < 256; i++)
        {
            BeatInfo bi = new BeatInfo();
            bi.index = i;
            temp.beatsInfo.Add(bi);
        }
        for (int i = 8; i < 256; i += 8)
        {
            ActionInfo ai = new ActionInfo();
            ai.actionType = 13;
            temp.beatsInfo[i].actions.Add(ai);
        }
        for (int i = 4; i < 256; i += 16)
        {
            ActionInfo ai = new ActionInfo();
            ai.actionType = 15;
            ai.actionParameters.Add(13);
            ai.actionParameters.Add(2);
            ai.actionParameters.Add(2);
            temp.beatsInfo[i].actions.Add(ai);

            ActionInfo ai1 = new ActionInfo();
            ai1.actionType = 14;
            ai1.actionParameters.Add(0);
            ai1.actionParameters.Add(2);
            ai1.actionParameters.Add(2);
            temp.beatsInfo[i+2].actions.Add(ai1);


            ActionInfo ai2 = new ActionInfo();
            ai2.actionType = 14;
            ai2.actionParameters.Add(1);
            ai2.actionParameters.Add(2);
            ai2.actionParameters.Add(2);
            temp.beatsInfo[i + 3].actions.Add(ai2);


            ActionInfo ai3 = new ActionInfo();
            ai3.actionType = 14;
            ai3.actionParameters.Add(2);
            ai3.actionParameters.Add(2);
            ai3.actionParameters.Add(2);
            temp.beatsInfo[i + 4].actions.Add(ai3);


            ActionInfo ai4 = new ActionInfo();
            ai4.actionType = 14;
            ai4.actionParameters.Add(3);
            ai4.actionParameters.Add(2);
            ai4.actionParameters.Add(2);
            temp.beatsInfo[i + 5].actions.Add(ai4);


            ActionInfo ai5 = new ActionInfo();
            ai5.actionType = 14;
            ai5.actionParameters.Add(4);
            ai5.actionParameters.Add(2);
            ai5.actionParameters.Add(2);
            temp.beatsInfo[i + 6].actions.Add(ai5);


            ActionInfo ai6 = new ActionInfo();
            ai6.actionType = 14;
            ai6.actionParameters.Add(5);
            ai6.actionParameters.Add(2);
            ai6.actionParameters.Add(2);
            temp.beatsInfo[i + 7].actions.Add(ai6);


            ActionInfo ai7 = new ActionInfo();
            ai7.actionType = 14;
            ai7.actionParameters.Add(6);
            ai7.actionParameters.Add(2);
            ai7.actionParameters.Add(2);
            temp.beatsInfo[i + 8].actions.Add(ai7);


            ActionInfo ai8 = new ActionInfo();
            ai8.actionType = 14;
            ai8.actionParameters.Add(7);
            ai8.actionParameters.Add(2);
            ai8.actionParameters.Add(2);
            temp.beatsInfo[i + 9].actions.Add(ai8);

        }
        SaveAFile(temp, "./Data/Boss2Example.info");
    }

    void SaveAFile(SongInfo info, string path)
    {
        string jsonstr = JsonMapper.ToJson(info);
        File.WriteAllText(path, jsonstr);
    }
}
