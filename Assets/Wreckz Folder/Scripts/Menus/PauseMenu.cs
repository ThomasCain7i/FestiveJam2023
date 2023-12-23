using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Gamemanager gamemanager;
    public GameObject pauseMenuUI;

    private void Start()
    {
        gamemanager = FindAnyObjectByType<Gamemanager>();
        gamemanager.isPaused = false;
    }
    // Update is called once per frame
    void Update()
    {
        //If start button or escape pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamemanager.isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        //Take away UI and set time back to normal
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamemanager.isPaused = false;
    }

    public void Pause()
    {
        //Add UI and set time to stopped
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamemanager.isPaused = true;
    }

    public void LoadMenu()
    {
        //When you return to menu reset paused time
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        Resume();
    }

    public void Quit()
    {
        //Quit
        Application.Quit();
    }
}