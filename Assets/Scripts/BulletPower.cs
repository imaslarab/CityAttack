using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPower : MonoBehaviour
{
    private float bulletRange = 15f;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        print(Vector3.Distance(player.position, gameObject.transform.position));
        if (Vector3.Distance(player.position, gameObject.transform.position) <= bulletRange)
        {
            Gun gun = player.GetComponent<Gun>();
            gun.DoubleBullets();
            Destroy(gameObject);
        }
    }
}
