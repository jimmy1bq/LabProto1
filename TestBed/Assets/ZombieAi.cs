using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
//navmesh info:
//the agent 
public class ZombieAi : MonoBehaviour
{
    [SerializeField] entityStatSO stats;
    NavMeshAgent agent;
    Animation animationer;
    AnimationState[] animationStates = new AnimationState[8];
    GameObject player;
    Coroutine attackCoroutine;

    bool wasOnLink = false;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        animationer = GetComponent<Animation>();
        int i = 0;
        //get them into an array so we can access for later
        foreach (AnimationState states in animationer) 
        {
             Debug.Log(states);
             animationStates[i] = states;
             i++;
        }
        //we only need the zombie to jump the window once(play the animation once
        animationer[animationStates[5].name].wrapMode = WrapMode.Once;
        agent.destination = player.transform.position;
        agent.autoTraverseOffMeshLink = false;    
        TickSystem.frequenttickTime.AddListener(trackPlayerPoistion);
    }

    
    //tracks the player position; should be called on every frame;
    void trackPlayerPoistion(float time) 
    {
        agent.destination = player.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        //this should only happen when a board enters the zombies range AND only once so no need to check if theres an coroutine happening

        if (other.gameObject.CompareTag("PotentialBoard") && other.gameObject.GetComponent<IDamageAble>() != null && other.gameObject.GetComponent<IDamageAble>().returnHP() > 0)
        {
            StartCoroutine(attackboard(other.gameObject));
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            animationer.Play(animationStates[0].name);
        }
        
    }
    IEnumerator attackPlayer(GameObject player) 
    {
        animationer.Play(animationStates[0].name);
        yield return new WaitForSeconds(1);
    
    }
    IEnumerator attackboard(GameObject board) 
    {
        float hpLeft = attack(board);
        if (hpLeft <= 0) 
        {
            animationer.Play(animationStates[5].name);
           
            // agent.CompleteOffMeshLink();

        }
        yield return new WaitForSeconds(1);
        StartCoroutine(attackboard(board)); 
    }

    float attack(GameObject other) 
    {
        animationer.Play(animationStates[1].name);
        other.gameObject.GetComponent<IDamageAble>().takeDamage(stats.meleeDamage);
        return other.gameObject.GetComponent<IDamageAble>().returnHP();
    }
   

    


}
