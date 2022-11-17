/**
*   @brief Détruit l'ennemi
*/


using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;

    /**
    *   @brief Détruit l'ennemi si le joueur entre en collision avec le point faible de l'ennemi
    *   @param collision : (Collision2D) Objet qui est entré en collision avec le point faible de l'ennemi
    */
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            Destroy(objectToDestroy);
        }
    }
}
