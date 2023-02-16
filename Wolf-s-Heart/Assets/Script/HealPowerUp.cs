/**
 * Ramasser de la vie
*/

using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public int healPoints = 20;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            if (PlayerHealth.instance.currentHealth != PlayerHealth.instance.maxHealth) {
                PlayerHealth.instance.HealPlayer(healPoints);
                Destroy(gameObject);
            }
        }
    }
}
