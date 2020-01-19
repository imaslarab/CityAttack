using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    public int startingHealth;
    [SerializeField]
    public double currentHealth;
    public double rateOfDeath = 3f;

    public bool invincible = false;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public AudioSource audioSource;

    public float invincibleTimeLeft = 4f;
    public float invincibleTime = 4f;
    public AudioClip die_Audio = null;
    public AudioClip heal_Audio = null;

    void Start()
    {
        currentHealth = startingHealth;
        audioSource = GetComponent<AudioSource>();

    }

    public void TakeDamage(int damageAmount)
    {
        if (!invincible)
        {
            invincibleTimeLeft = 0f;
        }
        if (invincibleTimeLeft > 0f) {
            return;
        }
        if (invincible) {
            return;
        }
        //print("take damage: " + damageAmount + ", cur health: " + currentHealth);
        currentHealth -= (double)(damageAmount/rateOfDeath);

        if (currentHealth <= 0)
        {
            audioSource.PlayOneShot(die_Audio);
            Die();
           
        }
        else {
            invincibleTimeLeft = invincibleTime;
        }
    }

    private void Die()
    {
        hearts[0].sprite = emptyHeart;
        gameObject.SetActive(false);


        StartCoroutine(endScene());
    }

    IEnumerator endScene()
    {
        yield return new WaitForSeconds(2f);
        SceneLoader.Instance.LoadScene("Scene_PlayerSelection_2");
    }

    public void FillLife() {
        audioSource.PlayOneShot(heal_Audio);
        currentHealth = currentHealth <= startingHealth ? currentHealth + 1 : currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                if (hearts[i].sprite == fullHeart)
                {
                    audioSource.PlayOneShot(die_Audio);
                }
                hearts[i].sprite = emptyHeart;
            }
        }
        if (invincibleTimeLeft > 0f)
        {
            invincibleTimeLeft -= Time.deltaTime;
        }
    }
}
