using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    GameObject coinsText;
    private void Awake()
    {
        coinsText = GameObject.FindGameObjectWithTag("CoinsCounter");
    }
    void Start()
    {
      
        coinsText.GetComponent<TextMeshProUGUI>().text = "Coins: " + PlayerInformationManager.playerStats[enums.playerStat.coins].ToString();
    }
    public void startGame() 
    {
        SceneManager.LoadScene(1);
    }

}
