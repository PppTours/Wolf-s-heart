using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
public string levelToLoad;

   public void CommencerJeu() {
        SceneManager.LoadScene(levelToLoad);
   }

   public void Parametres() {

   }

   public void QuitterJeu() {
        Application.Quit();
   }
}
