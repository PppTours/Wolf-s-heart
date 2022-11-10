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
            graphics.flipX = !graphics.flipX;
        }

        if ((Vector3.Distance(transform.position, borderPoint1.position) < 0.3f) || (Vector3.Distance(transform.position, borderPoint2.position) < 0.3f))
        {
            isPursue = false;
            isReturnPatrol = true;
            target = waypoints[destPoint];
        }
    }

    public void OnCollisionEnter2D(Collision2D collision){
        if (collision.transform.CompareTag("Player")) {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }
}
