/** 
 * @brief Donner des dégats si le joueur entre en contact avec l'ennemi
 */

using UnityEngine;

public class EnemyContact : MonoBehaviour
{
    private int damageOnCollision = 10;
    
    /**
    *   @brief Donne des dégâts au joueur si collision avec l'ennemi
    *   @param collision : (Collision2D) Objet qui est entré en collision avec l'ennemi
    */
    public void OnCollisionEnter2D(Collision2D collision){
        if (collision.transform.CompareTag("Player")) {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }
}
