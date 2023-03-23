using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    private Transform player;
    private Vector3 playerSpawn;
    private Animator fadeSystem;

    public static DeathManager instance;

    private void Awake()
    {
        if (instance != null) {
            Debug.LogWarning("Il y a plus d'une instance DeathManager dans la scène.");
            return;
        }

        instance = this;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position;
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    
    }
    
    /**
    *   @brief Animation de mort et replacement du joueur
    */
    public void Die() {
        StartCoroutine(ReplacePlayer());
        PlayerMouvement.instance.enabled  = false;
        PlayerMouvement.instance.animator.SetTrigger("Die");
        PlayerMouvement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMouvement.instance.rb.velocity = Vector3.zero;
        PlayerMouvement.instance.playerCollider.enabled = false;
    }

    public void Respawn() {
        PlayerMouvement.instance.enabled  = true;
        PlayerMouvement.instance.animator.SetTrigger("Respawn");
        PlayerMouvement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        PlayerMouvement.instance.playerCollider.enabled = true;
        PlayerHealth.instance.currentHealth = PlayerHealth.instance.maxHealth;
        PlayerHealth.instance.healthBar.SetHealth(PlayerHealth.instance.currentHealth);
    }

    private IEnumerator ReplacePlayer() {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        Vector3 pos = playerSpawn;

        if (CurrentSceneManager.instance.isPlayerPresentByDefault) {
            DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Respawn();

        player.position = pos;
    }

}
