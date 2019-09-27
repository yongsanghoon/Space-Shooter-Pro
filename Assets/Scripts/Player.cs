using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Speed var to change the player's speed
    //public float speed = 3.5f;

    // Private vars are prefixed with "_"
    // Set the 'SerializeField' attr to view and override it within the editor
    [SerializeField]
    private float _speed = 10.0f;

    [SerializeField]
    private GameObject _laserPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Take the current position and assign it to a new position (0, 0, 0)
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        // Space key entered = spawn
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_laserPrefab,transform.position, Quaternion.identity);
        }
    }

    void CalculateMovement()
    {
        // Vars for user inputs affecting x and y movements
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Instantiate a direction object with the x and y user input vars
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        
        // Vector3.right = (1,0,0) --> 1m per frame / 60m per second
        // Time.deltatime = converts frame time to real-time
        //transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        //transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        transform.Translate(direction * _speed * Time.deltaTime);

        // Restrict player's vertical axis
        // Clamp the min/max range to -3.8 <--> 0
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0));

        // Restrict player's horizontal axis
        // Can't clamp this since we're wrapping (once exceeding 11, start at -11)
        if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }
}
