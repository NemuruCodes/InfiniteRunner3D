using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;


public class PlayerController : MonoBehaviour
{
    [Header("Lane Settings")]
    public float laneDistance = 3.0f;
    public float laneSwitchSpeed = 10.0f;
    
    private int currLaneIndex = 1;

    private float[] lanePosition = new float[] { -3f, 0f, 3f };

    private Vector3 targetPos;


    public float playerSpeed = 2f;

    public float laneSwapSpeed = 2f;
    [Header ("Jump Settings")]
    public  int JumpEffect { get; set; }
    
    public float jumpForce = 8f;

    public float gravityMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public Collider groundCheck;
    public LayerMask groundLayer;
    //public float groundCheckRadius = 0.2f;

    public float vertVelocity = 0f;
    private bool isJumping = false;

    public float jumpSpeed = 2;
    

    public static bool isAlive = true;

    

    private Rigidbody rb;

    public FreezeGame freezeGame;

    [SerializeField] private GameObject PauseMenu;

    public PlayerMetrics playerMetrics;
    public int valueFinal { get; set; }
    public int BossFinal { get; set; }
    PointManager pointManager;

    void Start()
    {

        rb = GetComponent<Rigidbody>();

        targetPos = new Vector3(lanePosition[currLaneIndex], transform.position.y, transform.position.z);

        SoundManager.PlaySoundLoop(SoundType.FACTORY);

    }

   
    void Update()
    {
        /*
        if (isAlive)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World); //delta time is relative to game speed
        }
        */
        HandleInput();

       
    }
    private void FixedUpdate()
    {
        Vector3 velocity = rb.linearVelocity;
        velocity.z = playerSpeed;
        rb.linearVelocity = velocity;

        
        if (rb.linearVelocity.y < 0 && isAlive)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (gravityMultiplier - 1) * Time.fixedDeltaTime;
        }
        // Optional: Apply extra gravity when player lets go of jump early
        else if (rb.linearVelocity.y > 0 && !Input.GetKey(KeyCode.Space) && isAlive)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
        }

        MoveToLane();
    }
    /*
    IEnumerator stopLaneChange() 
    {
        yield return new WaitForSeconds(1);

        GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, 5);

        laneChange = false;

    }
    */
   
    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currLaneIndex > 0)
            {
                currLaneIndex--;
                UpdateTargetPos();
                Debug.Log("Left");
            }
            

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {

            if (currLaneIndex < lanePosition.Length-1)
            {
                currLaneIndex++;
                UpdateTargetPos();
                Debug.Log("Right");
            }
            



        }
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {

            vertVelocity = jumpForce;
            Jump();
            isJumping =true;
            
            
        }


    }
    void UpdateTargetPos()
    {
        targetPos = new Vector3(lanePosition[currLaneIndex], transform.position.y, transform.position.z);
    }
  
    void MoveToLane() 
    {
        float targetX = lanePosition[currLaneIndex];
        targetPos = new Vector3 (targetX, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, laneSwapSpeed * Time.deltaTime);
    }
   
    void Jump() 
    {
        /*
        if( isGrounded() && vertVelocity < 0 )
        {
            vertVelocity = -2f;
            isJumping = false;
        }
        else
        {
            vertVelocity += Gravity * Time.deltaTime;
        }
        /*
        //PickUpManager.canJump = true;
        GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 5 * JumpEffect, 5);
            //Debug.Log("No Jump");
            canJump = false;

            StartCoroutine(stopJump());
        */
        /*
        transform.position += new Vector3(0, vertVelocity, 0) * Time.deltaTime;
        */
        
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("StartGround"))
        {
           
            isJumping = false;
            
        }
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Rocket")
        {
            Debug.Log("Hit");
            isAlive = false;
            playerSpeed = 0;
            StartCoroutine(deathRoutine());
        }
    }

    private IEnumerator deathRoutine()
    {

        yield return new WaitForSeconds(1);

        freezeGame.PlayerDeath();
    }

    /*public void PlayerDeath()
    {
        PauseMenu.SetActive(true);
        playerMetrics.LogIn();
        playerMetrics.Add(valueFinal, valueFinal, BossFinal);
        playerMetrics.LogIn();

        Time.timeScale = 0;
        SoundManager.StopLoopingSound(SoundType.FACTORY);
    }*/
}
