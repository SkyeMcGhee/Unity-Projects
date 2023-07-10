using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        movePlayer(speed);
        
    }

    private void movePlayer(float speedIn)
    {

        //get horizontal input
        var horizontalInput = Input.GetAxis("Horizontal");

        //get vertical input
        var verticalInput = Input.GetAxis("Vertical");

        //build the input vector
        Vector3 directionInput = new Vector3(horizontalInput, 0, verticalInput);

        //move the player based on input vector and speed
        transform.Translate(directionInput * Time.deltaTime * speedIn);
    }
}
