using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    GameObject coinsText;
    GameObject speedUpgradeText;
    GameObject coinsUpgradeText;
   [SerializeField] GameObject timeText;
    //updates Menu UI on load and their functoinailty
    //Yeah a lot of the UI changes follows: TextMeshProUI.text = "string : " + value like I mentioned in the UI manager.
    private void Awake()
    {
        coinsText = GameObject.FindGameObjectWithTag("CoinsCounter");
        coinsUpgradeText = GameObject.FindGameObjectWithTag("upgradeCoins");
        speedUpgradeText = GameObject.FindGameObjectWithTag("upgradeSpeed");
       
    }
    void Start()
    {

        updateGUI();
    }

    //I could make a functoin to make this cleaner by calculating the cost instead of throwing the whole dictionary in there;
    public void upgradeCost(int upgradButton)
    {
        switch (upgradButton)
        {
            case 1:
                if (PlayerInformationManager.playerStats[enums.playerStat.coins] >= (10 + Mathf.Pow(1.3f, PlayerInformationManager.playerPowerUP[enums.powerUps.extraMoneyEarned])))
                {
                    Debug.Log("HI");
                    PlayerInformationManager.playerStats[enums.playerStat.coins] -= (int)(10 + Mathf.Pow(1.3f, PlayerInformationManager.playerPowerUP[enums.powerUps.extraMoneyEarned]));
                    PlayerInformationManager.playerPowerUP[enums.powerUps.extraMoneyEarned]++;
                    updateGUI();
                   
                }
                break;
            case 2:
                if (PlayerInformationManager.playerStats[enums.playerStat.coins] >= Mathf.Pow(10+1.3f, PlayerInformationManager.playerPowerUP[enums.powerUps.speed]))
                {
                    PlayerInformationManager.playerStats[enums.playerStat.coins] -= (int)(10 + Mathf.Pow(1.3f, PlayerInformationManager.playerPowerUP[enums.powerUps.speed]));
                    PlayerInformationManager.playerPowerUP[enums.powerUps.speed]++;
                    updateGUI();
                    
                }
                break;
        }
    }
    //Derefernces my UI elements when the buttons are called?
    void updateGUI()
    {
        coinsText = GameObject.FindGameObjectWithTag("CoinsCounter");
        coinsUpgradeText = GameObject.FindGameObjectWithTag("upgradeCoins");
        speedUpgradeText = GameObject.FindGameObjectWithTag("upgradeSpeed");
        coinsText.GetComponent<TextMeshProUGUI>().text = "Coins: " + PlayerInformationManager.playerStats[enums.playerStat.coins].ToString();
        coinsUpgradeText.GetComponent<TextMeshProUGUI>().text = "Cost: " + (10 + Mathf.Pow(1.3f, PlayerInformationManager.playerPowerUP[enums.powerUps.extraMoneyEarned])).ToString();
        speedUpgradeText.GetComponent<TextMeshProUGUI>().text = "Cost: " + (10 + (Mathf.Pow(1.3f, PlayerInformationManager.playerPowerUP[enums.powerUps.speed]))).ToString();
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

}
