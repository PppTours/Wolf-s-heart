/**
*   @bref L'ennemi attaque le joueur
*/

using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float beforeAttackTime;   // temps de préparation de l'attaque
    public float afterAttackTime; // temps de repos après l'attaque

    private bool onCollider = false;
    
    public PlayerHealth playerHealth;
    public EnemyPatrol enemyPatrol;
    public ChampsVision champsVision;

    public void Start()
    {
        beforeAttackTime = 1f;
        afterAttackTime = 1f;
    }

    /**
    *   @brief L'ennemi commence le processus d'attaque et attaque le joueur si celui-ci est dans la zone d'attaque
    *   @param collision : (Collision2D) Objet qui est entré dans la zone d'attaqe de l'ennemi
    */
    public void Update()
    {
        if (onCollider && enemyPatrol.isAttacking == 0) {
            enemyPatrol.isAttacking = 1;
            champsVision.Poursuivre();
            StartCoroutine(WaitBeforeAttack());
        }

        if(enemyPatrol.isAttacking == 2) {
            if (onCollider) {
                Debug.Log("Attack!");
                playerHealth.TakeDamage(enemyPatrol.damageOnAttack);
            }
            enemyPatrol.isAttacking = 3;
            StartCoroutine(WaitAfterAttack());
        }
    }

        public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player")) {
            onCollider = true;
        }
    }

     public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player")) {
            onCollider = false;
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
        enemyPatrol.graphics.color = new Color(1f,1f,1f,1f);
    }
}
