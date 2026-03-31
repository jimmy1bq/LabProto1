using TMPro;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
//hmm can I generalize this? If I set this to don't destroy on load and allow this script to contain methods that could operate on UI then I could reuse it?

//Like maybe a method that takes the gameObejct(textmeshpro) and operates on the text like "string : " + value; 
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
            case enums.loseMethod.win: 
                loseText.GetComponent<TextMeshProUGUI>().text = "You Win!"; 
                GameObject.FindGameObjectWithTag("BestTime").GetComponent<TextMeshProUGUI>().text = PlayerInformationManager.playerStats[enums.playerStat.bestCompletionTime].ToString();
                PlayerInformationManager.instance.resetAndRecord(PlayerInformationManager.playerStats[enums.playerStat.timer]);
             
                break;
        }
        
    }
}
