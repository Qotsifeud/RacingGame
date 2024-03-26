using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using Realms;
using Realms.Sync;
using Newtonsoft.Json;


public class DatabaseHandler
{
    public static IEnumerator Download()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:3000/Users"))
        {

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
                Debug.Log("NOT WORKING");
            }
            else
            {
                Debug.Log(request.downloadHandler.text);

                Leaderboard.playerData = JsonConvert.DeserializeObject<List<PlayerInfo>>(request.downloadHandler.text);

                Leaderboard.showLeaderboard();
            }
        }
    }

    public static IEnumerator Upload(string profile, System.Action<bool> callback = null)
    {
        using (UnityWebRequest request = new UnityWebRequest("http://localhost:3000/Users", "POST"))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(profile);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
                if (callback != null)
                {
                    callback.Invoke(false);
                }
            }
            else
            {
                if (callback != null)
                {
                    callback.Invoke(request.downloadHandler.text != "{}");
                }
            }
        }
    }
}
public class StatTracker
{
    private static float fastestLap;

    private static float totalTime;

    public static TextMeshProUGUI totalTimeText;
    public static TextMeshProUGUI fastestTimeText;
    public static GameObject test;
    public static PlayerInfo player;

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

    public static void setPlayerInfo(string json)
    {
        //PlayerPrefs.SetFloat("fastestLap", fastestLap);
        //PlayerPrefs.SetFloat("totalTime", TotalTime);

        //player.bestTime = (decimal)totalTime;
    }

}

public class Leaderboard : MonoBehaviour
{

    public GameObject leaderboardScreen;
    public TextMeshProUGUI playerTotalTime;
    public TextMeshProUGUI playerFastestTime;
    public static List<PlayerInfo> playerData = new List<PlayerInfo>();


    private void Start()
    {
        if (leaderboardScreen.activeInHierarchy)
        {
            loadLeaderboard();
        }
    }

    void Update()
    {
        

        //if(gameOverScreen.activeInHierarchy)
        //{
        //    setTimeText();
        //}
    }

    public void setTimeText()
    {
        TimeSpan totalTime = TimeSpan.FromSeconds(StatTracker.TotalTime);
        TimeSpan fastestTime = TimeSpan.FromSeconds(StatTracker.FastestLap);

        playerTotalTime.text = totalTime.ToString("mm':'ss");
        playerFastestTime.text = fastestTime.ToString("mm':'ss");
    }

    private void sendPlayerInfo()
    {
        PlayerInfo player = new PlayerInfo();

        string json = JsonUtility.ToJson(player);
    }

    private void loadLeaderboard()
    {

        StartCoroutine(DatabaseHandler.Download());

        Debug.Log("IT REACHED HERE");
    }

    public static void showLeaderboard()
    {
        for(int i = 0; i < playerData.Count; i++)
        {
            Debug.Log("Name: " + playerData[i].playerName + " | Score: " + playerData[i].playerScore + " | School: " + playerData[i].playerSchool);
        }
    }
}
