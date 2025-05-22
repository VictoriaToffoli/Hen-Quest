using UnityEngine;
using System.Collections;

public class ChickenController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;
    public float jumpButtonGracePeriod;

    //Speed boost
    public float speedBoost;
    public bool speedBoostActived = false;
    private float speedBoostTimer = 0;

    //Speed reduction
    public float speedReduction = 2;
    public bool speedReductionActived = false;
    private float speedReductionTimer = 0;
    private float speedReductionDuration = 5;


    private Animator animator;
    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;

    private Vector3 spawnPoint;

    private float soundTimer = 0;
    private int maxTimeSound = 8;
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip soundFast;



    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;

        spawnPoint = transform.localPosition;
    }

    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float currentSpeed = speed;


        //sound -- no speed boost
        soundTimer += Time.deltaTime;
        if(soundTimer >= maxTimeSound && !speedBoostActived)
        {
            AudioSource audioData;
            audioData = GetComponent<AudioSource>();

            if (Random.Range(0, 2) == 1)
            {
                audioData.clip = sound1;
                
            }
            else
            {
                audioData.clip = sound2;
            }
            
            audioData.Play(0);
            soundTimer = 0;
            maxTimeSound = Random.Range(4, 8);
        }


        //Speed boost
        if(speedBoostActived)
        {
            speedBoostTimer += Time.deltaTime;
            currentSpeed = speedBoost;
            //animator.SetBool("isRunning", true);

            //Sound
            if(soundTimer >= maxTimeSound)
            {
                AudioSource audioData;
                audioData = GetComponent<AudioSource>();
                audioData.clip = soundFast;
                audioData.Play(0);
                soundTimer = 0;
                maxTimeSound = Random.Range(2, 5);
            }

            //Speed boost have reach time limit
            if(speedBoostTimer >= 10)
            {
                speedBoostTimer = 0;
                speedBoostActived = false;
                currentSpeed = speed;
                //animator.SetBool("isRunning", false);
            }
            
        }


        //Check for speed reduction. 
        if (speedReductionActived)
        {
            speedReductionTimer += Time.deltaTime;
            currentSpeed = currentSpeed / speedReduction;

            //Speed reduction is over
            if(speedReductionTimer >= speedReductionDuration)
            {
                speedReductionTimer = 0;
                speedReductionActived = false;
            }
        }
      

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * currentSpeed;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            lastGroundedTime = Time.time;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpButtonPressedTime = Time.time;
        }

        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;

            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
            {
                ySpeed = jumpSpeed;
                jumpButtonPressedTime = null;
                lastGroundedTime = null;
                
            }
        }
        else
        {
            characterController.stepOffset = 0;
        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

       

        if (movementDirection != Vector3.zero)
        {
            if(speedBoostActived)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isMoving", true);
            }
            

            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("isRunning", false);
        }

    }

    public void goToSpawnPoint()
    {
        transform.localPosition = spawnPoint;

        //Debug.Log("Text: " + Time.timeSinceLevelLoad);

    }

    public void activeSpeedReduction()
    {
        speedReductionActived = true;
        speedReductionTimer = 0;
    
    }
}