using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStatus : MonoBehaviour
{
    public int health = 100;
    public float speed = 5f;
    public bool hard = false;
    private Animator animator;

    private float nextActionTime = 0.0f;
    private float period = 1f;
    private GameObject monster;

    public SimpleHealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        monster = GameObject.FindGameObjectWithTag("monsterGroup");
        if (hard)
        {
            StartCoroutine("DoCheck");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            animator.SetTrigger("death");
        }
    }

    IEnumerator DoCheck()
    {
        for (; ; )
        {
            // execute block of code here
            yield return new WaitForSeconds(1);
            health++;
            healthBar.UpdateBar(health, 100);
        }
    }

    private void deathEvent()
    {
        gameObject.SetActive(false);
        MonsterRespawn respawn = monster.GetComponent<MonsterRespawn>();
        respawn.remainingMonster--;
    }
}
