// Thomas

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu, creditsMenu, controlsMenu;

    public void StartMenu()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
        controlsMenu.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenMenu()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }

    public void OpenCredits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
        controlsMenu.SetActive(false);
    }

    public void OpenControls()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}