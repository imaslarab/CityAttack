using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInit : MonoBehaviour
{
    public Material[] soldierMaterials;

    private Health health;
    private JoystickController joystick;
    private Gun gun;

    private int playerSelectionNumber;// 0: normal; 1: speed++,but 2 lifes;  2: fire 2 bullets at once, speed--; 3: 4 lifes. speed--
    // Start is called before the first frame update
    void Start()
    {
        playerSelectionNumber = PlayerPrefs.GetInt("PLYAER_SELECTION_NUMBER",0);
        
        GameObject meshObj = GameObject.FindGameObjectWithTag("soldierModel");
        meshObj.GetComponent<SkinnedMeshRenderer>().material = soldierMaterials[playerSelectionNumber];

        health = gameObject.GetComponent<Health>();
        joystick = gameObject.GetComponent<JoystickController>();
        gun = gameObject.GetComponent<Gun>();

        if (playerSelectionNumber == 3)
        {
            health.startingHealth = 4;
            health.currentHealth = 4;
            joystick.speed = 5;
        } else
        {
            health.startingHealth = 3;
            health.currentHealth = 3;
            health.hearts[3].enabled = false;
            if (playerSelectionNumber == 2)
            {
                joystick.speed = 4;
                gun.gunRate = 2;
            } else if (playerSelectionNumber == 1)
            {
                health.startingHealth = 2;
                health.currentHealth = 2;
                joystick.speed = 10;
                health.hearts[2].enabled = false;
            } 
        }
    }
}
