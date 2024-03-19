using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using Realms;
using Realms.Sync;

public class StatTracker
{
    private static float fastestLap;

    private static float totalTime;

    public static TextMeshProUGUI totalTimeText;
    public static TextMeshProUGUI fastestTimeText;
    public static GameObject test;

    public static float TotalTime
    {
        get { return totalTime; }
    }

    public static float FastestLap
    {
        get { return fastestLap; }
    }

    public static void SetTotalTime(float time)
    {
        totalTime = time;
    }

    public static void SetLapTimes(float[] times)
    {
        fastestLap = times[0];

        for (int i = 0; i < times.Length; i++)
        {
            if (times[i] < fastestLap)
            {
                fastestLap = times[i];
            }
        }
    }



    public static void setPlayerInfo()
    {
        PlayerPrefs.SetFloat("fastestLap", fastestLap);
        PlayerPrefs.SetFloat("totalTime", TotalTime);
    }

}

public class Leaderboard : MonoBehaviour
{

    public GameObject gameOverScreen;
    public TextMeshProUGUI playerTotalTime;
    public TextMeshProUGUI playerFastestTime;

    private void Start()
    {
        
    }

    void Update()
    {
        //if (leaderboardScreen.activeInHierarchy)
        //{
        //    loadLeaderboard();
        //}

        if(gameOverScreen.activeInHierarchy)
        {
            setTimeText();
        }
    }

    public void setTimeText()
    {
        TimeSpan totalTime = TimeSpan.FromSeconds(StatTracker.TotalTime);
        TimeSpan fastestTime = TimeSpan.FromSeconds(StatTracker.FastestLap);

        playerTotalTime.text = totalTime.ToString("mm':'ss");
        playerFastestTime.text = fastestTime.ToString("mm':'ss");
    }

    [Serializable]
    public class PlayerInfo
    {
        public string Name { get; set; }
        public string RaceTime = PlayerPrefs.GetFloat("totalTime").ToString();
        public string FastestTime = PlayerPrefs.GetFloat("fastestTime").ToString();
    }

    private void sendPlayerInfo()
    {
        PlayerInfo player = new PlayerInfo();

        string json = JsonUtility.ToJson(player);
    }

    private void loadLeaderboard()
    {
        List<string[]> list = new List<string[]>();
        var playerList = new List<PlayerInfo>();
        PlayerInfo player = new PlayerInfo();

        PlayerInfo[] highestScorers = new PlayerInfo[5];

        string line;

        using(StreamReader reader = new StreamReader("..\\Racing Game Preproduction Project\\Assets\\Scripts\\Leaderboard\\leaderboard.txt"))
        {
            while((line = reader.ReadLine()) != null) 
            {
                list.Add(line.Split(','));
            }
        }

        foreach(var p in list)
        {
            foreach(var pi in p)
            {
                if (pi.StartsWith("Name"))
                {
                    string temp;
                    temp = pi.Remove(0, 6);
                    player.Name = temp;
                }
                else if(pi.StartsWith("Total"))
                {
                    string temp;
                    temp = pi.Remove(0, 12);
                    player.RaceTime = temp;
                }
                else if(pi.StartsWith("Fastest"))
                {
                    string temp;
                    temp = pi.Remove(0, 15);
                    player.FastestTime = temp;
                }
            }

            playerList.Add(player);
        }


        int highestScore = Int32.Parse(playerList[0].RaceTime);

        foreach (var p in playerList)
        {
            if(Int32.Parse(p.RaceTime) > highestScore)
            {
                highestScorers[0] = p;
            }
            else
            {
                for(int i = 0;  i < highestScorers.Length; i++)
                {
                    highestScorers[i + 1] = p;
                }
            }
        }
    }
}
