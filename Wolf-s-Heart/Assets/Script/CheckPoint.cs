/**
 * @brief Checkpoint du niveau/étage
*/

using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Transform playerSpwan;

    private void Awake() {
        playerSpwan = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            playerSpwan.position = transform.position;
        }
    }
}
