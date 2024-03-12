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

    public static float TotalTime
    {
        get { return totalTime; }
        set { totalTime = value; }
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
        PlayerPrefs.SetFloat("totalTime", totalTime);
    }

}

public class Leaderboard : MonoBehaviour
{
    public TextMeshProUGUI nameText1;
    public TextMeshProUGUI totalTimeText1;
    public TextMeshProUGUI fastestLapText1;

    public TextMeshProUGUI nameText2;
    public TextMeshProUGUI totalTimeText2;
    public TextMeshProUGUI fastestLapText2;

    public TextMeshProUGUI nameText3;
    public TextMeshProUGUI totalTimeText3;
    public TextMeshProUGUI fastestLapText3;

    public TextMeshProUGUI nameText4;
    public TextMeshProUGUI totalTimeText4;
    public TextMeshProUGUI fastestLapText4;

    public TextMeshProUGUI nameText5;
    public TextMeshProUGUI totalTimeText5;
    public TextMeshProUGUI fastestLapText5;

    public GameObject leaderboardScreen;

    private void Start()
    {
        
    }

    void Update()
    {
        if (leaderboardScreen.activeInHierarchy)
        {
            loadLeaderboard();
        }
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
