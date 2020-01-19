using UnityEngine;

public class HealthKit : MonoBehaviour
{
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

        print(Vector3.Distance(player.position, gameObject.transform.position));
        if (Vector3.Distance(player.position, gameObject.transform.position) <= healthKitRange)
        {
            Health health = player.GetComponent<Health>();
            health.FillLife();
            Destroy(gameObject);
        }
    }
}
