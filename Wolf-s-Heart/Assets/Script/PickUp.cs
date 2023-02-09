/*
* @brief Récupérer un objet
*/

using UnityEngine;

public class PickUp : MonoBehaviour
{
    /*
    * @brief Détruire l'objet si le joueur rentre en collision avec l'objet
    */
    public void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.CompareTag("Player")) {
            Inventory.instance.AddCoins(1);
            
            Destroy(gameObject);
        }
    }
}
