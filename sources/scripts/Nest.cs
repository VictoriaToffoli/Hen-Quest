using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nest : MonoBehaviour
{
    
    private int chicksInTheNest;
    public Vector3 offset;


    //level info
    public int chicksToFind;
    public int level = 1;
    public int watermelonToFind = 1;


    
    void Start()
    {
        StaticData.playingLevel = level;
    }

    private void OnTriggerEnter(Collider other)
    {

        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            //If we have a chick on the back
            if(playerInventory.isChickOnBack)
            {
                chicksInTheNest += 1;
                playerInventory.ChickSaved();

                //Move chicks in nest
                GameObject chick = playerInventory.chickOnBack;

                chick.transform.localScale += new Vector3(+0.5f, +0.5f, +0.5f);
                chick.transform.position = transform.position + offset;

                playerInventory.chickOnBack = null;
                playerInventory.isChickOnBack = false;

                Chick chickScript = chick.GetComponent<Chick>();

                chickScript.inNest = true;


                if(chicksInTheNest == chicksToFind)
                {
                   //Level finished --> updating information
                   StaticData.actualLevel = level;
                   StaticData.watermelonTotal = watermelonToFind;
                   StaticData.chickTotal = chicksToFind;

                   StaticData.chickCollected = playerInventory.NumberOfChicks;
                   StaticData.watermelonCollected = playerInventory.NumberOfWatermelons;
                   StaticData.death = playerInventory.NumberOfDeath;
                   StaticData.time = Time.timeSinceLevelLoad;

                    StaticData.updateMaxLevelCompleted();

                   SceneManager.LoadScene(2);
                }

            }
            
            
        }
    }
}
