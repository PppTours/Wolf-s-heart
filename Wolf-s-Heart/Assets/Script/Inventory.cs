/*
* @brief Inventaire du jeu
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public float showCoinsTime;
    public Text CoinsCountText;
    public GameObject coinsCountObject;

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null) {
            Debug.LogWarning("Il y a plus d'une instance inventaire dans la scène.");
            return;
        }

        instance = this;
        coinsCountObject.SetActive(false);
    }

    public void AddCoins(int count) {
        coinsCount += count;
        CoinsCountText.text = coinsCount.ToString();
        StartCoroutine(ShowCoins());
    }

    public IEnumerator ShowCoins()
    {
        coinsCountObject.SetActive(true);
        yield return new WaitForSeconds(showCoinsTime);
        coinsCountObject.SetActive(false);
    }
}
