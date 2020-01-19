using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform bulletSpawnTransform;
    public float bulletSpeed = 100.0f;
    public int bulletPower = 30;
    public float lifeTime = 3.0f;
    public Vector3 initForwardDir = Vector3.forward;
    public GameObject explosion;
    private Score score;

    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        //gameObject.transform.position = bulletSpawnTransform.position;
        //gameObject.transform.rotation = bulletSpawnTransform.rotation;


    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.position += gameObject.transform.up * Time.deltaTime * bulletSpeed * -1;
        //gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.up * -1 * bulletSpeed, ForceMode.Acceleration);

        gameObject.GetComponent<Rigidbody>().velocity = initForwardDir * bulletSpeed;

        if (lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("collision.gameObject.layer=" + collision.gameObject.layer);
        if (collision.gameObject.layer == 8)
        {
            print("hit the building");
            gameObject.SetActive(false);

        }
        else if (collision.gameObject.layer == 9) {
            MonsterStatus status = collision.gameObject.GetComponent<MonsterHit>().monsterStatus;
            status.health -= bulletPower;

            SimpleHealthBar healthBar = collision.gameObject.GetComponent<MonsterHit>().healthBar;
            healthBar.UpdateBar(status.health, 100);
            print("current health of the monster=" + status.health);

            score.AddPoints(5);
        }
        GameObject explosionObj = Instantiate(explosion);
        explosionObj.transform.position = gameObject.transform.position;

        Destroy(gameObject);
        Destroy(explosionObj, 3);
    }
}
