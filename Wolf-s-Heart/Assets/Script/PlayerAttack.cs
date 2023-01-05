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

    private Transform enemy;
    private GameObject player;
    private BoxCollider2D zoneAttaque;
    
    public EnemyHealth enemyHealth;
    public PlayerHealth playerHealth;
    public PlayerMouvement playerMouvement;
    
    public void Start()
    {
        player = GameObject.Find("PlayerAttack");
        enemy = GameObject.Find("Enemy/Graphics").transform;
        zoneAttaque = player.GetComponent(typeof(BoxCollider2D)) as BoxCollider2D;
    }
    /**
    *   @brief Le joueur attaque
    */
    public void Update()
    {
        if(Input.GetMouseButtonDown(0) && !playerHealth.isInvisible) {
            playerMouvement.isAttacking = true;
            if (Math.Sqrt(Math.Pow(enemy.position.x-(player.transform.position.x+zoneAttaque.offset.x),2)+Math.Pow(enemy.position.y-(player.transform.position.y+zoneAttaque.offset.y),2)) <= zoneAttaque.size.x) {  
                enemyHealth.TakeDamage(damageOnAttack);
            }
            StartCoroutine(WaitAttack());
        }
/*
        if (playerMouvement.isAttacking) {
            
        }*/
    }

    /**
    *   @brief Le joueur donne des dégâts à l'enemi si le joueur est en train d'attaquer
    *   @param collision : (Collision2D) Objet qui est entré dans la zone d'attaqe du joueur
    *//*
    public void OnTriggerStay2D(Collider2D collision)
    {
        
       
    }*/

    public IEnumerator WaitAttack()
    {  
        yield return new WaitForSeconds(attackTime);
        playerMouvement.isAttacking = false;
    }

}
