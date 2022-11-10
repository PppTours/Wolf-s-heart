using UnityEngine;

public class ChampsVision : MonoBehaviour
{
    public Transform player;
    public Transform enemy;
    public EnemyPatrol enemyPatrol;

    private void OnTriggerEnter2D(Collider2D collision){

        if (collision.CompareTag("Player") && (!enemyPatrol.isReturnPatrol)) {
            enemyPatrol.target = player;
            enemyPatrol.isPursue = true;
        }
    }
}
