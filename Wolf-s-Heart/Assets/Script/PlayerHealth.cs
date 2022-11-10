using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public bool isInvisible = false;
    public float invicibilityFlashDelay = 0.2f;
    public float invicibilityTimeAfterHit = 3F;

    public SpriteRenderer graphics;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)){
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage){
        if (!isInvisible){
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            isInvisible = true;
            StartCoroutine(InvincibilityFlash());
        }
    }

    public IEnumerator InvincibilityFlash(){
        StartCoroutine(HandleInvisibilityDelay());
        while (isInvisible){
            graphics.color = new Color(1f,1f,1f,0f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
            graphics.color = new Color(1f,1f,1f,1f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvisibilityDelay(){
        yield return new WaitForSeconds(invicibilityTimeAfterHit);
        isInvisible = false;
    }
}
