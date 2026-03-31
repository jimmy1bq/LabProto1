using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;

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
            
                playerPowerUP.Add(enums.powerUps.extraMoneyEarned, dataLoaded.playerData.powerUpData[0]);
                playerPowerUP.Add(enums.powerUps.speed, dataLoaded.playerData.powerUpData[1]);
                playerStats.Add(enums.playerStat.coins, dataLoaded.playerData.playerStatsData[0]);
                playerStats.Add(enums.playerStat.bestCompletionTime, dataLoaded.playerData.playerStatsData[1]);
                Debug.Log(playerStats[enums.playerStat.bestCompletionTime]);
                    //in the future use Linq ElementaAtorDefulat because 
                playerStats.Add(enums.playerStat.timer, dataLoaded.playerData.playerStatsData.ElementAtOrDefault(2));
                

        } else { Destroy(gameObject);}
       
    }
    public void resetAndRecord(float time) 
    {
        playerPowerUP[enums.powerUps.extraMoneyEarned]= 0;
        playerPowerUP[enums.powerUps.speed] = 0;
        playerStats[enums.playerStat.coins] = 0;
        //in the future use Linq ElementaAtorDefulat because 
       
        if (playerStats[enums.playerStat.bestCompletionTime] > time) 
        {
            playerStats[enums.playerStat.bestCompletionTime] = time;
        }

    }

    public JSONManager.PlayerData getPlayerData() 
    {
        JSONManager.PlayerData playerData = new JSONManager.PlayerData();
        playerData.playerStatsData = new List<float>() { playerStats[enums.playerStat.coins], playerStats[enums.playerStat.bestCompletionTime], playerStats[enums.playerStat.timer]};
        playerData.powerUpData = new List<float>() { playerPowerUP[enums.powerUps.extraMoneyEarned], playerPowerUP[enums.powerUps.speed]};
        return playerData;
    }
  

   


}
