/**
*   @brief Actions en rapport à la vie de l'ennemi
*/


using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public bool isInvisible = false;
    public float invicibilityFlashDelay = 0.2f;  // temps du clignotement lors de l'invicibilité
    public float invicibilityTimeAfterHit = 3f;  // temps d'invicibilité après avoir reçu des dégâts

    public SpriteRenderer graphics;

    void Start()
    {
        currentHealth = maxHealth;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
    }

    /**
    *   @brief Recevoir des dégâts et passer en mode invisible
    *   @param damage : (int) quantité des dégâts reçus
    */
    public void TakeDamage(int damage)
    {
        if (!isInvisible)
        {
            currentHealth -= damage;
            isInvisible = true;
            StartCoroutine(InvincibilityFlash());
        }
    }

    /**
    *   @brief Animmation de l'invicibilité (alternance entre les graphismes du joueur visible et invisible)
    *   @param damage : (int) quantité des dégâts reçus
    */
    public IEnumerator InvincibilityFlash()
    {
        StartCoroutine(HandleInvisibilityDelay());
        while (isInvisible)
        {
            graphics.color = new Color(1f,1f,1f,0f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
            graphics.color = new Color(1f,1f,1f,1f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
        }
    }

    /**
    *   @brief Attend la fin de l'invisibilité
    */
    public IEnumerator HandleInvisibilityDelay()
    {
        yield return new WaitForSeconds(invicibilityTimeAfterHit);
        isInvisible = false;
    }
}
