using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndMenu : MonoBehaviour
{

    public GameObject nextLevelButton;

    void Start()
    {
        if(StaticData.actualLevel == 3)
        {
            nextLevelButton.SetActive(false);
        }
    }

    public void OnMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void OnReplayButton()
    {
       
        if(StaticData.actualLevel == 1)
        {
           SceneManager.LoadScene(1);
        }
        if(StaticData.actualLevel == 2)
        {
            SceneManager.LoadScene(4);
        }
        if(StaticData.actualLevel == 3)
        {
            SceneManager.LoadScene(5);
        }
    }

    public void OnNextLevelButton()
    {
        if(StaticData.actualLevel == 1)
        {
            SceneManager.LoadScene(4);
        }
        if(StaticData.actualLevel == 2)
        {
            SceneManager.LoadScene(5);
        }
        if(StaticData.actualLevel == 3)
        {
            nextLevelButton.SetActive(false);
        }
    }


}
