using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public static Timer instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null) { instance = this; DontDestroyOnLoad(gameObject); } else { Destroy(gameObject); }
      
        gameObject.transform.Find("BestTIme").GetComponent<TextMeshProUGUI>().text = "time: " + PlayerInformationManager.playerStats[enums.playerStat.bestCompletionTime].ToString();
    }

    // Update is called once per frames
    void Update()
    {
        
        PlayerInformationManager.playerStats[enums.playerStat.timer] += Time.deltaTime;
        gameObject.transform.Find("TImer").GetComponent<TextMeshProUGUI>().text ="time: "+PlayerInformationManager.playerStats[enums.playerStat.timer].ToString();
       
        JSONManager.instance.SaveData();

    }
}
