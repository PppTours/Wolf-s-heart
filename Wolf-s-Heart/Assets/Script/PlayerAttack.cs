/**
*   @bref Le joueur attaque le l'ennemi
*/

using UnityEngine;
using System.Collections;
using System;

public class PlayerAttack : MonoBehaviour
{
    private float attackTime = 0.5f;   //temps d'execution de l'attaque

    public int damageOnAttack = 20;
    
    private EnemyHealth enemyHealth;
    public PlayerHealth playerHealth;
    public PlayerMouvement playerMouvement;

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            enemyHealth = collision.GetComponent<EnemyHealth>();
            //si le joueur attaque
            if (playerMouvement.isAttacking) {
                //si l'ennemi n'est pas invisible
                if (!enemyHealth.isInvisible) {
                    enemyHealth.TakeDamage(damageOnAttack);
                }
            }
        }
    }

    /**
    *   @brief Le joueur attaque
    */
    public void Update()
    {
        if(Input.GetMouseButtonDown(0) && !playerHealth.isInvisible) {
            playerMouvement.isAttacking = true;
            StartCoroutine(WaitAttack());
        }
    }

    public IEnumerator WaitAttack()
    {  
        yield return new WaitForSeconds(attackTime);
        playerMouvement.isAttacking = false;
    }

}
