using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : MonoBehaviour
{
    private float spinSpeed = 50f;
    private float healthKitRange = 15f;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, -spinSpeed * Time.deltaTime);
        //transform.Rotate(transform.up, -spinSpeed * Time.deltaTime);

        print(Vector3.Distance(player.position, gameObject.transform.position));
        if (Vector3.Distance(player.position, gameObject.transform.position) <= healthKitRange)
        {
            Health health = player.GetComponent<Health>();
            health.FillLife();
            Destroy(gameObject);
        }
    }
}
