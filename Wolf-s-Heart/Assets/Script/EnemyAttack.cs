/**
*   @bref L'ennemi attaque le joueur
*/

using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float beforeAttackTime = 1f;   // temps de préparation de l'attaque
    public float attackTime = 1f; // temps de l'attaque
    public float afterAttackTime = 1f; // temps de repos après l'attaque
    
    public PlayerHealth playerHealth;
    public EnemyPatrol enemyPatrol;

    /**
    *   @brief L'ennemi commence le processus d'attaque et attaque le joueur si celui-ci est dans la zone d'attaque
    *   @param collision : (Collision2D) Objet qui est entré dans la zone d'attaqe de l'ennemi
    */
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && enemyPatrol.isAttacking == 0) {
            StartCoroutine(WaitBeforeAttack());
        }

        if(collision.transform.CompareTag("Player")/* && enemyPatrol.isAttacking == 2*/) {
            Debug.Log("Attack!");
            playerHealth.TakeDamage(enemyPatrol.damageOnAttack);
        }
    }

    

    /**
    *   @brief L'ennemi attaque le joueur si celui-ci est toujours dans la zone d'attaque
    *   @param collision : (Collision2D) Objet qui est entré dans la zone d'attaqe de l'ennemi
    *//*
    public void OnTriggerStay2D(Collider2D collision) {
        
    }*/
    /*
    void Attacking()
    {
        enemyPatrol.isAttacking = 2;

        if (TryGetComponent(out Transform collision)) {
            if (collision.CompareTag("Player")) {
                Debug.Log("Attack!");
                playerHealth.TakeDamage(20);
            }
        }
        
        StartCoroutine(WaitAfterAttack());
    }*/

    public IEnumerator WaitBeforeAttack()
    {  
        enemyPatrol.isAttacking = 1;
        Debug.Log("PrepAttack");

        yield return new WaitForSeconds(beforeAttackTime);
        //Attacking();
        StartCoroutine(WaitAttack());
    }

    public IEnumerator WaitAttack()
    {
        enemyPatrol.isAttacking = 2;
        Debug.Log("Hello");
        yield return new WaitForSeconds(attackTime);
        StartCoroutine(WaitAfterAttack());
    }

    public IEnumerator WaitAfterAttack()
    {
        enemyPatrol.isAttacking = 3;
        Debug.Log("Sleep");
        yield return new WaitForSeconds(afterAttackTime);
        enemyPatrol.isAttacking = 0;
    }
}
