using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chick : MonoBehaviour
{

    private bool found = false;
    public bool inNest = false;

    private Vector3 spawnPoint;


    void Start()
    {

        spawnPoint = transform.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if( !(found || inNest))
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

            if (playerInventory != null)
            {
                if(!playerInventory.hasChickOnBack())
                {
                playerInventory.ChickCollected(gameObject);
                found = true;

                gameObject.transform.localScale += new Vector3(-0.5f, -0.5f, -0.5f);
                }

                
            }
        }
        
    }

    public Transform player;
    public Vector3 offset;

    void LateUpdate()
    {
        if(found && !inNest)
        {
            transform.position = player.position + offset;
            transform.rotation =  player.rotation;
        }
        
    }

    public void returnToSpawnPoint()
    {
        transform.localPosition = spawnPoint;
        gameObject.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        found = false;
    }
}
