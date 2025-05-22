using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickMenuAnimation : MonoBehaviour
{

   public float moveSpeed = 2f;
    public float runSpeed = 3.5f;

    private Vector3 startPosition;
    private Vector3 targetPosition;

    public Vector3 position1;
    public Vector3 position2;
    public Vector3 position3;
    public Vector3 position4;
    public Vector3 position5;
    public Vector3 position6;
    public Vector3 position7;
    public Vector3 position8;
    public Vector3 position9;
    public Vector3 position10;

    private Animator animator;

    private int positionIndex = 1;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        startPosition = transform.position;
        targetPosition = position1;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        
        if(positionIndex == 1)
        {

          //GO TO POSITION  1
          targetPosition = position1;
          transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
          animator.SetBool("isWalking", true);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                animator.SetBool("isWalking", false);
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                positionIndex = 2;
                
            }
        }
        else if(positionIndex == 2)
        {
             //WAIT
             timer += Time.deltaTime;

            if(timer >= 4)
            {
                animator.SetBool("isWalking", false);
                transform.localRotation = Quaternion.Euler(0, 90, 0);
                timer = 0;
                positionIndex = 3;
            
            }
            
        }
        else if(positionIndex == 3)
        {
         
         //GO TO POSITION 3
         targetPosition = position3;
          transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
          animator.SetBool("isWalking", true);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                animator.SetBool("isWalking", false);
                //transform.localRotation = Quaternion.Euler(0, 180, 0);
                positionIndex = 4;
                
            }

        }
        else if(positionIndex == 4)
        {
            //WAIT 
            timer += Time.deltaTime;

            if(timer >= 4)
            {
                animator.SetBool("isWalking", false);
                timer = 0;
                positionIndex = 5;
            
            }
            
            
        }
        else if(positionIndex == 5)
        {
            //TELEPORT TO POSITION 5
          
            transform.localPosition = position5;
            positionIndex = 6;
            

        }

        else if(positionIndex == 6)
        {
         
         //GO TO POSITION 6
         targetPosition = position6;
          transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
          animator.SetBool("isWalking", true);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                animator.SetBool("isWalking", false);
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                positionIndex = 7;
                
            }

        }
        else if(positionIndex == 7)
        {
            //WAIT 
            timer += Time.deltaTime;

            if(timer >= 4)
            {
                animator.SetBool("isWalking", false);
                 transform.localRotation = Quaternion.Euler(0, 90, 0);
                timer = 0;
                positionIndex = 8;
            
            }
            
            
        }
        else if(positionIndex == 8)
        {
            //GO TO POSITION 8
            targetPosition = position8;
          transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
          animator.SetBool("isWalking", true);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                animator.SetBool("isWalking", false);
                positionIndex = 9;
                
            }
            
        }
            else if(positionIndex == 9)
        {
            //TELEPORT TO POSITION 9 / 0
          
            transform.localPosition = position9;
            positionIndex = 10;
            

        }
        else if(positionIndex == 10)
        {
            //WAIT 
            timer += Time.deltaTime;

            if(timer >= 4)
            {
                animator.SetBool("isWalking", false);
                transform.localRotation = Quaternion.Euler(0, 270, 0);
                timer = 0;
                positionIndex = 1;
            
            }
            
            
        }
        
    }


}