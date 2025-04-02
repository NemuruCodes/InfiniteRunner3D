using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 2;
    public  int JumpEffect { get; set; }
    //public float horizontalSpeed = 3;
    float _move;
    //public float limitLeft = 5.5f;
    //public float limitRight = -5.5f;
    private bool laneChange = false;

    private bool canJump = true;

    private bool isAlive = true;

   // public int JumpEffect = 1;

    

    void Start()
    {
        GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, 5);

    }

   
    void Update()
    {
        /*
        if (isAlive)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World); //delta time is relative to game speed
        }
        */

        
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (laneChange == false) && (transform.position.x > -2))
        {
            //if(this.gameObject.transform.position.x <= limitLeft) 
            // {
            //transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);

            GetComponent<Rigidbody>().linearVelocity = new Vector3(-3, 0, 5);
            laneChange = true;
            //}
            StartCoroutine(stopLaneChange());
        
        }
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && (laneChange == false) && (transform.position.x < 2))
        {// temp canJump to stop glitch
            // if (this.gameObject.transform.position.x >= limitRight) 
            //{ 

            // transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * -1);
            // }

            GetComponent<Rigidbody>().linearVelocity = new Vector3(3, 0, 5);
            laneChange = true;
            StartCoroutine(stopLaneChange());
        }

        Jump();
        /*

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {


            //transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);

            //transform.Translate()position.x = -5;


        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x > limitRight)
            {

                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * -1);
            }



        }
        */
    }

    IEnumerator stopLaneChange() 
    {
        yield return new WaitForSeconds(1);

        GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, 5);

        laneChange = false;

    }
    IEnumerator stopJump() 
    {
        yield return new WaitForSeconds(0.75f);
        GetComponent<Rigidbody>().linearVelocity = new Vector3(0, -4 * JumpEffect, 5);
        yield return new WaitForSeconds(0.75f);
        GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, 5);
        canJump = true;
        //PickUpManager.canJump = false;

    }

    void Jump() 
    { 
        if (isAlive == true && canJump == true && Input.GetKey(KeyCode.Space) && (laneChange == false)) //temp lanChange will swap vector numbers with variables
        {

            //PickUpManager.canJump = true;
            GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 4 * JumpEffect, 5);
                //Debug.Log("No Jump");
                canJump = false;
                
                StartCoroutine(stopJump());

        }
    
    
    }
    public void OnCollisionEnter(Collision collision)
    {
        /*
        if(collision.gameObject.tag == "Ground")
        {
            Debug.Log("Jumpie");
            canJump = true;
        }
        */
        if (collision.gameObject.tag == "Obstacle") 
        {
            Debug.Log("Hit");
            isAlive = false;
        
        }
    }
}
