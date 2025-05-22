using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveableObject : MonoBehaviour
{
    public float threeshold;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if( transform.localPosition.y < threeshold) 
        {
            transform.localPosition = new Vector3(transform.localPosition.x, threeshold, transform.localPosition.z) ;
        }
    }
}
