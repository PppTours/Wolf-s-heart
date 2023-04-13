using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public static bool isGamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingWindow;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isGamePaused) {
                Reprendre();
            }
            else {
                Pause();
            }
        }
    }

    private void Pause() {
        PlayerMouvement.instance.enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
    }

    public void Reprendre() {
        PlayerMouvement.instance.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
    }

    public void MenuPrincipal() {
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        Reprendre();
        SceneManager.LoadScene("MainMenu");
    }

    public void Parametres() {
          settingWindow.SetActive(true);
    }

    
    public void FermerParametres() {
        settingWindow.SetActive(false);
    }
}
