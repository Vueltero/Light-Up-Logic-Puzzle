using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] ClassicPackTimes, Mania7x7Times, Mania10x10Times, Mania12x12Times, Mania14x14Times,
                   Mania25x25Times, Mania30x30Times, Mania35x35Times, Mania40x40Times, Mania45x45Times,
                   Mania50x50Times, ExtremeJumboPackTimes, IntervalPackTimes, IntervalPack2Times, ExtremeIntervalTimes,
                   TowerPackTimes, RectanglePackTimes, ExtremePackTimes, JumboPackTimes, JumboRectangleTimes,
                   JumboRectangle2Times, MirrorPack4wayTimes, RotationalPack4wayTimes, ExtremeNoSymmetryPackTimes, KidsPackTimes;
    public int[] TimeTrial7x7Solved, TimeTrial10x10Solved, TimeTrial12x12Solved, TimeTrial14x14Solved;
    public bool[] packsUnlocked;
    public int hints;
    public bool boughtHints;
    public int themeUnlocked0, themeUnlocked1, themeUnlocked2, themeUnlocked3, themeUnlocked4; //0 = false, 1 = true
    public int themeSelected; //0, 1, 2, .., 9
    public bool achievementsChecked;
    public bool rookieAchiUnlocked;

    public PlayerData(LightUp lightUpScript)
    {
        ClassicPackTimes = new float[150];
        Mania7x7Times = new float[150];
        Mania10x10Times = new float[150];
        Mania12x12Times = new float[150];
        Mania14x14Times = new float[150];
        Mania25x25Times = new float[150];
        Mania30x30Times = new float[150];
        Mania35x35Times = new float[150];
        Mania40x40Times = new float[150];
        Mania45x45Times = new float[150];
        Mania50x50Times = new float[150];
        ExtremeJumboPackTimes = new float[150];
        IntervalPackTimes = new float[150];
        IntervalPack2Times = new float[150];
        ExtremeIntervalTimes = new float[150];
        TowerPackTimes = new float[150];
        RectanglePackTimes = new float[150];
        ExtremePackTimes = new float[150];
        JumboPackTimes = new float[150];
        JumboRectangleTimes = new float[150];
        JumboRectangle2Times = new float[150];
        MirrorPack4wayTimes = new float[150];
        RotationalPack4wayTimes = new float[150];
        ExtremeNoSymmetryPackTimes = new float[150];
        KidsPackTimes = new float[120];
        TimeTrial7x7Solved = new int[4];
        TimeTrial10x10Solved = new int[4];
        TimeTrial12x12Solved = new int[4];
        TimeTrial14x14Solved = new int[4];
        packsUnlocked = new bool[25];
        for (int i=0; i<150; i++)
        {
            ClassicPackTimes[i] = lightUpScript.ClassicPackTimes[i];
            Mania7x7Times[i] = lightUpScript.Mania7x7Times[i];
            Mania10x10Times[i] = lightUpScript.Mania10x10Times[i];
            Mania12x12Times[i] = lightUpScript.Mania12x12Times[i];
            Mania14x14Times[i] = lightUpScript.Mania14x14Times[i];
            Mania25x25Times[i] = lightUpScript.Mania25x25Times[i];
            Mania30x30Times[i] = lightUpScript.Mania30x30Times[i];
            Mania35x35Times[i] = lightUpScript.Mania35x35Times[i];
            Mania40x40Times[i] = lightUpScript.Mania40x40Times[i];
            Mania45x45Times[i] = lightUpScript.Mania45x45Times[i];
            Mania50x50Times[i] = lightUpScript.Mania50x50Times[i];
            ExtremeJumboPackTimes[i] = lightUpScript.ExtremeJumboPackTimes[i];
            IntervalPackTimes[i] = lightUpScript.IntervalPackTimes[i];
            IntervalPack2Times[i] = lightUpScript.IntervalPack2Times[i];
            ExtremeIntervalTimes[i] = lightUpScript.ExtremeIntervalTimes[i];
            TowerPackTimes[i] = lightUpScript.TowerPackTimes[i];
            RectanglePackTimes[i] = lightUpScript.RectanglePackTimes[i];
            ExtremePackTimes[i] = lightUpScript.ExtremePackTimes[i];
            JumboPackTimes[i] = lightUpScript.JumboPackTimes[i];
            JumboRectangleTimes[i] = lightUpScript.JumboRectangleTimes[i];
            JumboRectangle2Times[i] = lightUpScript.JumboRectangle2Times[i];
            MirrorPack4wayTimes[i] = lightUpScript.MirrorPack4wayTimes[i];
            RotationalPack4wayTimes[i] = lightUpScript.RotationalPack4wayTimes[i];
            ExtremeNoSymmetryPackTimes[i] = lightUpScript.ExtremeNoSymmetryPackTimes[i];
        }
        for (int i = 0; i < 120; i++)
            KidsPackTimes[i] = lightUpScript.KidsPackTimes[i];
        for (int i = 0; i < 4; i++)
        {
            TimeTrial7x7Solved[i] = lightUpScript.TimeTrial7x7Solved[i];
            TimeTrial10x10Solved[i] = lightUpScript.TimeTrial10x10Solved[i];
            TimeTrial12x12Solved[i] = lightUpScript.TimeTrial12x12Solved[i];
            TimeTrial14x14Solved[i] = lightUpScript.TimeTrial14x14Solved[i];
        }
        for (int i = 0; i < 25; i++)
            packsUnlocked[i] = lightUpScript.packsUnlocked[i];
        hints = lightUpScript.hints;
        boughtHints = lightUpScript.boughtHints;
        themeUnlocked0 = lightUpScript.themeUnlocked0;
        themeUnlocked1 = lightUpScript.themeUnlocked1;
        themeUnlocked2 = lightUpScript.themeUnlocked2;
        themeUnlocked3 = lightUpScript.themeUnlocked3;
        themeUnlocked4 = lightUpScript.themeUnlocked4;
        themeSelected = lightUpScript.themeSelected;
        achievementsChecked = lightUpScript.achievementsChecked;
        rookieAchiUnlocked = lightUpScript.rookieAchiUnlocked;
    }
}

/*
 * -1 = locked
 *  0 = available
 * >0 = completed
 * 
 * false = locked
 * true  = unlocked
 */