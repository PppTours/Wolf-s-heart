/**
 * @brief Objets à ne pas détruire lors du chargement d'une scène
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] objects;

    public static DontDestroyOnLoadScene instance;

    void Awake() {
        if (instance != null) {
            Debug.LogWarning("Il y a plus d'une instance DontDestroyOnLoadScene dans la scène.");
            return;
        }

        instance = this;
        foreach (var element in objects) {
            DontDestroyOnLoad(element);
        }
    }

    public void RemoveFromDontDestroyOnLoad() {
        foreach (var element in objects) {
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
        }
    }
}
