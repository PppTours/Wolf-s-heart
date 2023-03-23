/**
 * @brief Changement de scène
*/


using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSpecifScene : MonoBehaviour
{
    public string sceneName;
    public bool isPlayerPresentByDefaultInSceneName;
    private Animator fadeSystem;
    private bool isInRange = false;

    private void Awake() {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void Update() {
        if (isInRange && Input.GetKeyDown(KeyCode.E)) {
            StartCoroutine(loadNextScene());
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
        }
    }

    public IEnumerator loadNextScene() {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);

        if (isPlayerPresentByDefaultInSceneName) {
            DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        }
        SceneManager.LoadScene(sceneName);
    }
}
