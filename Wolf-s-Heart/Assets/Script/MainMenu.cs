using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
     public string levelToLoad;

     public GameObject settingWindow;

     public void StartGame() {
          SceneManager.LoadScene(levelToLoad);
     }

     public void Parametres() {
          settingWindow.SetActive(true);
     }

     public void FermerParametres() {
          settingWindow.SetActive(false);
     }

     public void LoadCreditsScene() {
          SceneManager.LoadScene("Credits");
     }

     public void QuitterJeu() {
          Application.Quit();
     }
}
