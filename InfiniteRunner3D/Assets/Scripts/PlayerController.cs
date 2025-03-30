using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 2;
    public float horizontalSpeed = 3;
    float _move;
    public float limitLeft = 5.5f;
    public float limitRight = -5.5f;

    void Start()
    {
        
    }

   
    void Update()
    {
        
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World); //delta time is relative to game speed

        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
        {
           if(this.gameObject.transform.position.x <= limitLeft) 
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);

            }
           
        
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) 
        {
            if (this.gameObject.transform.position.x >= limitRight) 
            { 
            
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * -1);
            }

                

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
}
