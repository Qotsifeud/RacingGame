using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Realms;
using Realms.Sync;

public class PlayerInfo : RealmObject
{
    [PrimaryKey]
    [MapTo("name")]
    public string Name { get; set; }

    [MapTo("fastestTime")]
    public double FastestTime { get; set; }

    [MapTo("totalTime")]
    public double TotalTime { get; set; }

    public PlayerInfo() { }

    public PlayerInfo(string name)
    {
        this.Name = name;
        this.FastestTime = 0;
        this.TotalTime = 0;
    }
}
