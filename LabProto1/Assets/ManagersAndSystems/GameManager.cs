using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Coins;
    public static GameManager instance; 
    float coins = 100f;
    void Start()
    {
        if (instance == null) { instance = this; } else { Destroy(gameObject); }
        setUpGame();
    }

    // Update is called once per frame
    
    void setUpGame() 
    {
        for (int i = 0; i < coins * (PlayerInformationManager.playerStats[enums.playerStat.coins]/2+1); i++) 
        {
            float randomX = Random.Range(-14.21f, 53.12f);
            float randomZ = Random.Range(-235f, 256f);
            Instantiate(Coins, new Vector3(randomX, 13.5f, randomZ), Quaternion.Euler(90,0,0));
        }
    }
   
    public void gameOver(enums.loseMethod loseMethod) 
    {
       
        Time.timeScale = 0;
        JSONManager.instance.SaveData();       
        UIManager.instance.gameOver(loseMethod);
        StartCoroutine(instance.loadMenu(loseMethod));
        
    }
    IEnumerator loadMenu(enums.loseMethod losemethod) 
    {
        yield return new WaitForSecondsRealtime(3);
        if (losemethod == enums.loseMethod.win) { PlayerInformationManager.playerStats[enums.playerStat.timer] = 0; }
        SceneManager.LoadScene(0);
    }
}
