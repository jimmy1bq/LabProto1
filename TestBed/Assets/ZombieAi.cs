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
    AnimationState[] animationStates;
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
            animationStates[i] = states;
             i++;
        }
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
        else 
        {
            agent.CompleteOffMeshLink();
        }
    }
    IEnumerator attackPlayer(GameObject player) 
    {
        yield return null;
    
    }
    IEnumerator attackboard(GameObject board) 
    {
        float hpLeft = attack(board);
        if (hpLeft < 0) 
        {
            agent.CompleteOffMeshLink();
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(attackboard(board)); 
    }

    float attack(GameObject other) 
    {
        AnimationClip clip = animationer.GetClip()
        animationer.Play()
        other.gameObject.GetComponent<IDamageAble>().takeDamage(stats.meleeDamage);
        return other.gameObject.GetComponent<IDamageAble>().returnHP();
    }
   

    


}
