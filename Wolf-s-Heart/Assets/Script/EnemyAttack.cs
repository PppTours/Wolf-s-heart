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

    public int damageOnAttack = 20;

    private Transform player;
    private GameObject enemy;
    private BoxCollider2D zoneAttaque;
    
    private PlayerHealth playerHealth;
    public EnemyHealth enemyHealth;
    public EnemyPatrol enemyPatrol;

    public void Awake()
    {
        beforeAttackTime = 1f;
        afterAttackTime = 1f;
        
        enemy= GameObject.Find("EnemyAttack");
        player = GameObject.Find("Vinru").transform;
        zoneAttaque = enemy.GetComponent(typeof(BoxCollider2D)) as BoxCollider2D;
        playerHealth = GameObject.Find("Vinru").GetComponent<PlayerHealth>();
    }

    /**
    *   @brief L'ennemi attaque le joueur si celui-ci est à proté
    */
    public void Update()
    {
        if(enemyPatrol.isAttacking == 2) {
            if (!enemyHealth.isInvisible) {
            //si le joueur est à porté
            if (Math.Sqrt(Math.Pow(player.position.x-(enemy.transform.position.x+zoneAttaque.offset.x),2)+Math.Pow(player.position.y-(enemy.transform.position.y+zoneAttaque.offset.y),2)) <= zoneAttaque.size.x) {
                playerHealth.TakeDamage(damageOnAttack);
            }
            enemyPatrol.isAttacking = 3;
            StartCoroutine(WaitAfterAttack());
            }
            else {
                enemyPatrol.isAttacking = 0;
            }
        }
    }

    /**
    *   @brief L'ennemi commence le processus d'attaque
    *   @param collision : (Collision2D) Objet qui est entré dans la zone d'attaqe de l'ennemi
    */
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemyPatrol.isAttacking == 0) {
            enemyPatrol.isAttacking = 1;
            StartCoroutine(WaitBeforeAttack());
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
