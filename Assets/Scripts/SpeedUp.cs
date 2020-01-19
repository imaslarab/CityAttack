using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    private float range = 10f;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, gameObject.transform.position) <= range)
        {
            JoystickController jc = player.GetComponent<JoystickController>();
            jc.DoubleSpeed();
            Destroy(gameObject);
        }
    }
}
