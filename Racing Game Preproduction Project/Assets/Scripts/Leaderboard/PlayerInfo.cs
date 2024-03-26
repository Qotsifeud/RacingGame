using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    [JsonProperty("_id")]
    public string playerID { get; set; }
    [JsonProperty("playerName")]
    public string playerName { get; set; }
    [JsonProperty("playerScore")]
    public string playerScore { get; set; }
    [JsonProperty("playerSchool")]
    public string playerSchool { get; set; }
}
