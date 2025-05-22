using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChickenMenuAnimation : MonoBehaviour
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

    private int positionIndex = 2;

    private bool wait = false;
    private float timer = 0;
    private int durrationTimer = 0;
    private int durrationTimer1 = 3;
    private int durrationTimer2 = 5;

    public GameObject fox;


    public UnityEvent OnChase;
    public UnityEvent OnChaseReset;

    // Start is called before the first frame update
    void Start()
    {
        
        startPosition = transform.position;
        targetPosition = position2;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(wait == true)
        {
            timer += Time.deltaTime;

            if(timer >= durrationTimer)
            {
                wait = false;
                timer = 0;
            }
        }
        else if(positionIndex == 2)
        {
          targetPosition = position2;
          transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
          animator.SetBool("isMoving", true);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                animator.SetBool("isMoving", false);
                positionIndex = 3;
            }

        }
        else if(positionIndex == 3)
        {
          targetPosition = position3;
          transform.position = Vector3.MoveTowards(transform.position, targetPosition, runSpeed * Time.deltaTime);
          animator.SetBool("isMoving", true);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                animator.SetBool("isMoving", false);
                transform.Rotate(0, 180, 0);
                positionIndex = 4;
            }

        }
        else if(positionIndex == 4)
        {
          targetPosition = position4;
          transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
          animator.SetBool("isMoving", true);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                animator.SetBool("isMoving", false);
                positionIndex = 5;
            }

        }
        else if(positionIndex == 5)
        {
          targetPosition = position5;
          transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
          animator.SetBool("isMoving", true);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                animator.SetBool("isMoving", false);
                transform.Rotate(0, -60, 0);
                positionIndex = 6;
            }

        }
        else if(positionIndex == 6)
        {
          targetPosition = position6;
          transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
          animator.SetBool("isMoving", true);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                animator.SetBool("isMoving", false);
                transform.localRotation = Quaternion.Euler(0, 90, 0);
                positionIndex = 7;
                wait = false;
                OnChase.Invoke();
            }

        }
        else if(positionIndex == 7)
        {
          targetPosition = position7;
          transform.position = Vector3.MoveTowards(transform.position, targetPosition, runSpeed * Time.deltaTime);
          animator.SetBool("isRunning", true);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                
                animator.SetBool("isRunning", false);
                positionIndex = 8;

                durrationTimer = durrationTimer2;
                wait = true;
            }

        }
        else if(positionIndex == 8)
        {

           positionIndex = 9;
           transform.localRotation = Quaternion.Euler(0, 0, 0);
           transform.localPosition = position8;

        }
        
        else if(positionIndex == 9)
        {

         targetPosition = position1;
          transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
          animator.SetBool("isMoving", true);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                animator.SetBool("isMoving", false);
                transform.localRotation = Quaternion.Euler(0, 90, 0);
                positionIndex = 2;

                durrationTimer = durrationTimer1;
                wait = true;
            }
           

        }

        
    }



}
