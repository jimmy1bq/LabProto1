using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class JSONManager : MonoBehaviour
{
    [System.Serializable]
    public class PlayerData
    {
        // public Weapon playerWeapon = new Pistol(); 
        public Dictionary<enums.powerUps, float> playerPowerUpData = new Dictionary<enums.powerUps, float>
        {
            { enums.powerUps.extraTime, 0f },
            { enums.powerUps.speed, 0f },
            { enums.powerUps.extraMoneyEarned, 0f }
        };
        public Dictionary<enums.playerStat, float> playerStatsData = new Dictionary<enums.playerStat, float> 
        {
            {enums.playerStat.coins,0},
            {enums.playerStat.bestCompletionTime,999999999999999f}
        
        };
    }

    [System.Serializable]
    public class AllData
    {
        public PlayerData playerData;
    }

    public static JSONManager instance;
    private string filePath = Application.dataPath + "/JSONData.json";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SaveData()
    {
        string JSONOutput = JsonUtility.ToJson(GetData());
        File.WriteAllText(filePath, JSONOutput);
    }

    public AllData LoadData()
    {
        string readJSON;
        if (!File.Exists(filePath))
        {
            DefaultJSON();
        }
        readJSON = File.ReadAllText(filePath);
        AllData data = JsonUtility.FromJson<AllData>(readJSON);
        return data;
    }

    public AllData GetData()
    {
        AllData data = new AllData();

        data.playerData = PlayerInformationManager.instance.getPlayerData();
        

        return data;
    }

    void DefaultJSON()
    {
        AllData data = new AllData();

        data.playerData = new PlayerData();

        string outputJSON = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, outputJSON);
    }
}
