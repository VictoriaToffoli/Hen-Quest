using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
     public bool gamePaused = false;

    
    void Start()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        gamePaused = false;
        Debug.Log("Start");
    }


    void Update()
    {
        Debug.Log("test");
        if (Input.GetKeyDown(KeyCode.Escape) && gamePaused == false)
        {
            Pause();
        }
        else if ((Input.GetKeyDown(KeyCode.Escape) && gamePaused == true))
        {
            Resume();
        }
    }

    public void Pause()
    {
        gamePaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
        
    public void Resume()
    {
        gamePaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
         Time.timeScale = 1;
         gamePaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
