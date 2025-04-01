using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 2;
    //public float horizontalSpeed = 3;
    float _move;
    //public float limitLeft = 5.5f;
    //public float limitRight = -5.5f;
    private bool laneChange = false;

    void Start()
    {
        GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, 5);

    }

   
    void Update()
    {
        
        //transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World); //delta time is relative to game speed

        
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
        {
            // if (this.gameObject.transform.position.x >= limitRight) 
            //{ 

            // transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * -1);
            // }

            GetComponent<Rigidbody>().linearVelocity = new Vector3(3, 0, 5);
            laneChange = true;
            StartCoroutine(stopLaneChange());
        }
        if (Input.GetKey(KeyCode.Space)) 
        { 
        
        
        }
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
}
