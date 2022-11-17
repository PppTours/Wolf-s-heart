/**
*   Déplacements de l'ennemi :
*     - fait sa pratouille (suit un patern prédéfini)
*     - poursuit le joueur si celui-ci rentre dans son champs de vision
*     - arrête la poursuite si le joueur sort de son champs de vision ou s'il atteind sa limite de déplacement, il retourne à sa pratrouille
*/


using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    public Transform borderPoint1;
    public Transform borderPoint2;

    public int damageOnCollision = 20;

    public SpriteRenderer graphics;
    public Transform target;
    private int destPoint = 0;

    public bool isPursue = false;
    public bool isReturnPatrol = false;

    void Start()
    {
        target = waypoints[0];
    }


    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if((Vector3.Distance(transform.position, target.position) < 0.3f) && !isPursue){
            destPoint = (destPoint+1) % waypoints.Length;
            target = waypoints[destPoint];
            Flip(dir);
        }

        if ((Vector3.Distance(transform.position, borderPoint1.position) < 0.3f) || (Vector3.Distance(transform.position, borderPoint2.position) < 0.3f))
        {
            isPursue = false;
            isReturnPatrol = true;
            target = waypoints[destPoint];
        }
    }

    void Flip(int _dir)
    {
        if (_dir < -0.1f)
        {
            graphics.flipX = false;
        }
        else if (_dir > 0.1f)
        {
            graphics.flipX = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision){
        if (collision.transform.CompareTag("Player")) {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }
}
