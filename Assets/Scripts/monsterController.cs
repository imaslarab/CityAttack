using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class monsterController : MonoBehaviour
{
    public float minDistance;
    public float monsterAttackRange;

    private Transform player;

    private Animator animator;

    private NavMeshAgent nav;
    private float originalSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        nav = GetComponent<NavMeshAgent>();
        if (nav == null)
        {
            Debug.Log("error!");
        }
        animator = GetComponentInChildren<Animator>();

        if (Vector3.Distance(player.position, gameObject.transform.position) <= monsterAttackRange)
        {
            nav.stoppingDistance = minDistance;
            nav.SetDestination(player.position);
        }
    }

    // Update is called once per frame
    void Update()
    {

        //nav.SetDestination(player.transform.position);
        animator.SetFloat("monstor_speed", nav.velocity.magnitude);
        float distance = Vector3.Distance(player.position, gameObject.transform.position);

        if (distance <= monsterAttackRange)
        {
            if (distance <= minDistance)
            {
                nav.velocity = Vector3.zero;
                nav.isStopped = true;
                animator.SetFloat("monstor_speed", nav.velocity.magnitude);

                animator.SetTrigger("attack");
            }
            else
            {
                nav.SetDestination(player.transform.position);
                nav.velocity = (player.position - nav.transform.position).normalized * originalSpeed;
            }
        }
    }

    private void attackevent()
    {
        float random = Random.Range(0.0f, 1.0f);
        bool Hit = random > 0.5f;

        Health health = player.GetComponent<Health>();
        health.TakeDamage(1);

    }
}