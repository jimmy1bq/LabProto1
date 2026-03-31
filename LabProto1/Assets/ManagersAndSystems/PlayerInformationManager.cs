using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerInformationManager : MonoBehaviour
{
    public static PlayerInformationManager instance;
    public static Dictionary<enums.powerUps, float> playerPowerUP = new Dictionary<enums.powerUps, float>();
    public static Dictionary<enums.playerStat, float> playerStats = new Dictionary<enums.playerStat, float>();

    private void Awake()
    {
        if (instance == null) 
        { 
            instance = this;
            DontDestroyOnLoad(gameObject);
            JSONManager.AllData dataLoaded = JSONManager.instance.LoadData();
            playerPowerUP = dataLoaded.playerData.playerPowerUpData;
            playerStats = dataLoaded.playerData.playerStatsData;

        } else { Destroy(gameObject);}
       
    }

    public JSONManager.PlayerData getPlayerData() 
    {
        JSONManager.PlayerData playerData = new JSONManager.PlayerData();
        playerData.playerPowerUpData = playerPowerUP;
        playerData.playerStatsData = playerStats;
        return playerData;
    }

   


}
