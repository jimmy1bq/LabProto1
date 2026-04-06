using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class woodenBoardHp : MonoBehaviour, IDamageAble
{
    [SerializeField] entityStatSO stats;
    float health;
    private void Start()
    {
        health = stats.hp;
    }
    public float takeDamage(float damageToTake) 
    {
        
        health -= damageToTake;
        if (health < 0) { health = 0; }

        return health;    
    }
    public float returnHP()
    {
        return health;
    }
}
