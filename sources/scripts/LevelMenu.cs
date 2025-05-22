using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void OnMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void OnLevel1Button()
    {
       SceneManager.LoadScene(1);
    }

    public void OnLevel2Button()
    {
       SceneManager.LoadScene(4);
    }

    public void OnLevel3Button()
    {
       SceneManager.LoadScene(5);
    }

    
}
