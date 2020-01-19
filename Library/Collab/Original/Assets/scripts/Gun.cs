using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    [Range(0.5f, 1.5f)]
    private float fireRate = 1;

    [SerializeField]
    private ParticleSystem muzzleParticle;

    private float timer;

    private JoystickController joystickController;

    public GameObject bulletObject;
    public Transform bulletSpawn;
    public GameObject explosionPrefab;
    public AudioSource audioSource;
    public AudioClip shot_Audio = null;

    private int numberOfBullets = 1;

    public void DoubleBullets() {
        numberOfBullets = 2;
    }

    private void Start()
    {
        joystickController = gameObject.GetComponent<JoystickController>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            if (joystickController.joystickRightReleased)
            {
                timer = 0f;
                FireGun();
            }
        }
    }

    private void FireGun()
    {
        //Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 2f);
        muzzleParticle.Play();
        GenerateBullet();
        if(shot_Audio != null)
        {
            audioSource.PlayOneShot(shot_Audio);
        }


    }

    private void GenerateBullet() {
        for(int i=1; i<=numberOfBullets; i++)
        {
            GameObject bullet = Instantiate(bulletObject);
            bullet.transform.position = bulletSpawn.transform.position;
            bullet.transform.rotation = bulletSpawn.transform.rotation;
            bullet.GetComponent<BulletFly>().initForwardDir = bulletSpawn.transform.up * -1;
            bullet.GetComponent<BulletFly>().explosion = explosionPrefab;
        }
    }
}
