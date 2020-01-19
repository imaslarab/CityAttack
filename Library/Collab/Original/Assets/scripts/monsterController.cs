using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class monsterController : MonoBehaviour
{
    public Transform player;

    private Animator animator;

    private NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        if(nav == null)
        {
            Debug.Log("error!");
        }
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(player.transform.position);
        animator.SetFloat("monstor_speed", nav.velocity.magnitude);
    }
}
