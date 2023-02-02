/**
*   @brief Déplacements de l'ennemi 
*/

using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;  // liste des points vers lesquels se dirige l'ennemi
    /* points réprésentant la limite de déplacement de l'ennemi */
    public Transform borderPoint1;
    public Transform borderPoint2;

    public Transform target;    // point vers lequel se dirige l'ennemi
    private int destPoint = 0;  // indice de waypoints
    
    public bool isPursue = false;
    public bool isReturnPatrol = false;
    public int isAttacking = 0;   // états de l'attaque (0 = n'attaque pas, 1 = prépare l'attaque, 2 = attaque, 3 = repos de fin d'attque)
   
    public EnemyHealth enemyHealth;
    public Transform transformEnemy;

    void Start()
    {
        target = waypoints[0];
    }

    void Update()
    {
        if (isAttacking == 0 && !enemyHealth.isInvisible)
        {
            Vector3 dir = Vector3.right * (target.position.x - transform.position.x);
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
            Flip(dir.x);
        }
    /* si proche du point vers lequel il se dirige et ne poursuit pas le joueur : se dirige vers le prochain point */
        if((Vector3.Distance(transform.position, target.position) < 0.3f) && !isPursue){
            destPoint = (destPoint+1) % waypoints.Length;
            target = waypoints[destPoint];
        }
        

    /* si proche de sa limite de déplacement quand il poursuit le joueur : ne peut pas aller plus loin */
        if ((Vector3.Distance(transform.position, borderPoint1.position) < 0.3f) && isPursue)
        {
            target = borderPoint1;
        }
        else if((Vector3.Distance(transform.position, borderPoint2.position) < 0.3f) && isPursue)
        {
            target = borderPoint2;
        }
    }

    /**
    *   @brief Change l'orientation du graphisme de l'ennemi en fonction de sa diraction de déplacement
    *   @param _dir : (float) Direction de déplacement de l'ennemi sur l'axe x
    */
    void Flip(float _dir)
    {
        if (_dir < -0.1f)
        {
            transformEnemy.localScale = new Vector3(1,1,1);
        }
        else if (_dir > 0.1f)
        {
            transformEnemy.localScale = new Vector3(-1,1,1);
        }
    }

    /**
    *   @brief Donne des dégâts au joueur si collision avec l'ennemi
    *   @param collision : (Collision2D) Objet qui est entré en collision avec l'ennemi
    *//*
    public void OnCollisionExit2D(Collision2D collision){
        if (collision.transform.CompareTag("Player")) {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }*/
}