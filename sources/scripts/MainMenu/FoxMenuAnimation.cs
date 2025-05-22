using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxMenuAnimation : MonoBehaviour
{

    public float moveSpeed = 2f;
    public float runSpeed = 3.5f;

    public Vector3 startPosition;
    public Vector3 targetPosition;

    public bool chasing = false;

    private float timer = 0;


    void Update()
    {
        if(chasing)
        {
            timer += Time.deltaTime;
        }
        if(chasing && timer > 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                Reset();
            }
        }
        
    }


    public void Chase()
    {
       chasing = true;
       timer = 0;
       Debug.Log("In fox chasing function");

    }




    public void Reset()
    {
        chasing = false;
       transform.localPosition = startPosition;

    }


}
