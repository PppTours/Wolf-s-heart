using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lader : MonoBehaviour
{
    public bool isInRange;

    private PlayerMouvement playerMouvement;
    public BoxCollider2D colliderLader;

    void Awake()
    {
        playerMouvement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMouvement>();
    }

    void Update()
    {
        if (isInRange && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))) {
            playerMouvement.isClimbing = true;
            colliderLader.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            isInRange = false;
            playerMouvement.isClimbing = false;
            colliderLader.isTrigger = false;
        }
    }
}
