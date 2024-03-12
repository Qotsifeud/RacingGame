using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public static class StatTracker
{
    private static float totalTime;

    public static float TotalTime
    {
        get { return totalTime; }
        set { totalTime = value; }
    }

    public static void SetLapTimes(float[] times)
    {
        float fastestLap = times[0];

        for (int i = 0; i < times.Length; i++)
        {
            if (times[i] < fastestLap)
            {
                fastestLap = times[i];
            }
        }

        using (StreamWriter writer = new StreamWriter("..\\Racing Game Preproduction Project\\Assets\\Scripts\\Leaderboard\\leaderboard.txt"))
        {
            writer.WriteLine("Name: Test Player,Total Time: " + totalTime.ToString() + ",Fastest Lap: " + fastestLap.ToString("0.0") + Environment.NewLine);
        }
    }
}
