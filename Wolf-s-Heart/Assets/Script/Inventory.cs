/*
* @brief Inventaire du jeu
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public Text CoinsCountText;
    public GameObject coinsCountObject;

    public static Inventory instance;

    private float showCoinsTime;
    private int nbCoroutines;

    private void Awake()
    {
        if (instance != null) {
            Debug.LogWarning("Il y a plus d'une instance inventaire dans la scène.");
            return;
        }

        instance = this;
        showCoinsTime = 5f;
        nbCoroutines = 0;
        coinsCountObject.SetActive(false);
    }

    public void AddCoins(int count) {
        coinsCount += count;
        CoinsCountText.text = coinsCount.ToString();
        StartCoroutine(ShowCoins());
    }

    public IEnumerator ShowCoins()
    {
        nbCoroutines++;
        coinsCountObject.SetActive(true);
        yield return new WaitForSeconds(showCoinsTime);
        nbCoroutines--;
        //éviter que l'affichage disparaisse showCoinsTime apres avoir récupéré une pièce mais le joueur en à récupéré d'autres entre temps
        if (nbCoroutines == 0) {
            coinsCountObject.SetActive(false);
        }
    }
}
