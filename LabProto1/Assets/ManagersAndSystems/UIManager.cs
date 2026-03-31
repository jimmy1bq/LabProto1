using TMPro;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] GameObject timerText;
    [SerializeField] GameObject coinsText;
    GameObject loseText;
    private void Awake()
    {
      
        if (instance == null) { instance = this; } else { Destroy(gameObject); }
        timerText = GameObject.FindGameObjectWithTag("Timer");
        coinsText = GameObject.FindGameObjectWithTag("CoinsCounter");
        loseText = GameObject.FindGameObjectWithTag("loseText");
        coinsText.GetComponent<TextMeshProUGUI>().text = "Coins: " + PlayerInformationManager.playerStats[enums.playerStat.coins].ToString();
    }
    void Start()
    {
        TickSystem.frequenttickTime.AddListener(updateTimer);
    }

   
    void updateTimer(float totalTIme) 
    {
       
        float timeLeft = 5 - totalTIme;
        if (timeLeft < 0)
        {
            timerText.GetComponent<TextMeshProUGUI>().text = "Time Left: " + "0";
            GameManager.instance.gameOver(enums.loseMethod.time);
        }
        else
        {
            timerText.GetComponent<TextMeshProUGUI>().text = "Time Left: " + timeLeft.ToString();
        }

    }
    public void updateCoinsText() 
    {
        coinsText.GetComponent<TextMeshProUGUI>().text = "Coins: " + PlayerInformationManager.playerStats[enums.playerStat.coins].ToString();

    }
    public void gameOver(enums.loseMethod loseMethod) 
    {
       
        switch (loseMethod) 
        {
            case enums.loseMethod.time:
                loseText.GetComponent<TextMeshProUGUI>().text = "You Lose! Time Ran Out!";
                break;
            case enums.loseMethod.falling: loseText.GetComponent<TextMeshProUGUI>().text = "You Lose! You Fell Out Of The Map"; break;
        }
        
    }
}
