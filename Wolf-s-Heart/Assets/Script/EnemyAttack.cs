/**
*   @bref L'ennemi attaque le joueur
*/

using UnityEngine;
using System.Collections;
using System;

public class EnemyAttack : MonoBehaviour
{
    private float beforeAttackTime;   // temps de préparation de l'attaque
    private float afterAttackTime; // temps de repos après l'attaque

    private bool isPlayerIn = false;

    public int damageOnAttack = 20;

    private Transform player;
    
    private PlayerHealth playerHealth;
    public EnemyHealth enemyHealth;
    public EnemyPatrol enemyPatrol;

    public void Awake()
    {
        beforeAttackTime = 1f;
        afterAttackTime = 1f;
    
        player = GameObject.Find("Vinru").transform;
    }

    private void Update() {
        if (enemyPatrol.isAttacking == 2) {
            //si le joueur est à porté et n'est pas invisible
            if (!enemyHealth.isInvisible && isPlayerIn) {
                playerHealth.TakeDamage(damageOnAttack);
            }
            enemyPatrol.isAttacking = 3;
            StartCoroutine(WaitAfterAttack());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            isPlayerIn = true;
        }
    }

    private void OnTriggerExit2D (Collider2D collision) {
        if (collision.CompareTag("Player")) {
            isPlayerIn = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            playerHealth = collision.GetComponent<PlayerHealth>();
            //si l'ennemi n'est pas en train d'attaquer
            if (enemyPatrol.isAttacking == 0 && !playerHealth.isInvisible && !enemyHealth.isInvisible) {
                enemyPatrol.isAttacking = 1;
                StartCoroutine(WaitBeforeAttack());
            }        
        }
    }

    public IEnumerator WaitBeforeAttack()
    {  
        yield return new WaitForSeconds(beforeAttackTime);
        enemyPatrol.isAttacking = 2;
    }

    public IEnumerator WaitAfterAttack()
    {
        yield return new WaitForSeconds(afterAttackTime);
        enemyPatrol.isAttacking = 0;
    }
}
