using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRespawn : MonoBehaviour
{
    private Transform monsterGroup;

    public GameObject[] monsterObjects;

    public Transform[] instantiatePositions;

    [SerializeField]
    public int monsterCount = 3;
    [SerializeField]
    public int remainingMonster = 3;

    public int xPos;
    public int zPos;
    private string[] monsters = { "Kiwi", "Chili", "Eggy" };
    // Start is called before the first frame update
    void Start()
    {
        monsterGroup = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingMonster == 0)
        {
            StartCoroutine(monsterRespawn());
        }
        //if (remainingMonster < monsterCount) {
        //    print("respawn");
        //    StartCoroutine(monsterRespawn());
        //}
    }
    IEnumerator monsterRespawn()
    {
        monsterCount++;
        //while (remainingMonster < monsterCount)
        //{
        //    xPos = Random.Range(-50,60);
        //    zPos = Random.Range(163,230);
        //    monster = GameObject.FindGameObjectWithTag(monsters[Random.Range(0, monsters.Length-1)]);
        //    Instantiate(monster, new Vector3(xPos, 0.625015f, zPos), Quaternion.identity);
        //    monster.SetActive(true);
        //    remainingMonster++;
        //    yield return new WaitForSeconds(0.1f);
        //}

        while (remainingMonster < monsterCount)
        {
            int respawnPosIndex = Random.Range(0, instantiatePositions.Length);
            int monsterIndex = Random.Range(0,monsterObjects.Length);

            GameObject newMonster = Instantiate(monsterObjects[monsterIndex], monsterGroup);
            newMonster.transform.position = instantiatePositions[respawnPosIndex].transform.position;
            newMonster.SetActive(true);
            //monster = GameObject.FindGameObjectWithTag(monsters[Random.Range(0, monsters.Length - 1)]);
            //Instantiate(monster, new Vector3(xPos, 0.625015f, zPos), Quaternion.identity);
            //monster.SetActive(true);
            remainingMonster++;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
