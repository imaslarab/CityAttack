using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    private float spinSpeed = 50f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, -spinSpeed * Time.deltaTime);
    }
}
