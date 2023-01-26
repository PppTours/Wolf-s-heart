/**
*   @brief Passe l'ennemi en mode poursuite ou en mode retour à la patrouille si le joueur entre ou sort du champs de vision de l'ennemi
*/

using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public EnemyPatrol enemyPatrol;

    private Transform player;

    public void Start()
    {
        player = GameObject.Find("Vinru").transform;
    }

    /**
    *   @brief Passe l'ennemi en mode poursuite si le joueur entre dans le champ de vision de l'ennemi
    *   @param collision : (Collision2D) Objet qui est entré dans le champ de vision de l'ennemi
    */
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && enemyPatrol.isPursue == false) {
            Poursuivre();
        }
    }

    public void Poursuivre()
    {
        enemyPatrol.target = player;
        enemyPatrol.isPursue = true;
    }

    /**
    *   @brief Passe l'ennemi en mode retour à la patrouille si le joueur sort du champ de vision de l'ennemi
    *   @param collision : (Collision2D) Objet qui est sortie du champ de vision de l'ennemi
    */
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            ArreterPoursuite();
        }
    }

    public void ArreterPoursuite()
    {
        enemyPatrol.target = enemyPatrol.waypoints[0];
        enemyPatrol.isPursue = false;
    }
}
