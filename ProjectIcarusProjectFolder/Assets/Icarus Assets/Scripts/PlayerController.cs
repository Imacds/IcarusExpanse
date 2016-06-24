using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Rigidbody player;

    public float health = 100.0f;
    public float oxygen = 100.0f;
    public float propellant = 100.0f;

    public float walkSpeed = 15.0f;
    public float boostMultiplier = 1.5f;
    public float jumpForce = 50.5f;
    public float aircontrolSpeed = 0.5f;
    public float gravityForce = 9.81f;

    float groundDistance;
	
	void Start()
    {
        groundDistance = player.GetComponent<Collider>().bounds.extents.y;
    }
	
	
	void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded() == true)
        {
            player.AddRelativeForce(0, jumpForce, 0, ForceMode.VelocityChange);
        }

        if (Input.GetButtonDown("Sprint"))
        {
            walkSpeed *= boostMultiplier;
        }
        if (Input.GetButtonUp("Sprint"))
        {
            walkSpeed /= boostMultiplier;
        }
    }

    //Used mainly for physics based movement.
    void FixedUpdate()
    {
        player.AddRelativeForce(0, -gravityForce, 0, ForceMode.Acceleration);

        //Grounded movement.
        if (isGrounded() == true)
        {
            player.drag = 10.0f;
            player.angularDrag = 10.0f;

            if (Input.GetButton("Walk Forward"))
            {
                player.AddRelativeForce(0, 0, walkSpeed, ForceMode.Force);
            }

            if (Input.GetButton("Walk Backwards"))
            {
                player.AddRelativeForce(0, 0, -walkSpeed, ForceMode.Force);
            }

            if (Input.GetButton("Walk Right"))
            {
                player.AddRelativeForce(walkSpeed, 0, 0, ForceMode.Force);
            }

            if (Input.GetButton("Walk Left"))
            {
                player.AddRelativeForce(-walkSpeed, 0, 0, ForceMode.Force);
            }
        }
        else if(isGrounded() == false)
        {
            player.drag = 0.0f;
            player.angularDrag = 0.0f;

            //Slight Air Controler for easier jumping.
            if (Input.GetButton("Walk Forward"))
            {
                player.AddRelativeForce(0, 0, aircontrolSpeed, ForceMode.Force);
            }

            if (Input.GetButton("Walk Backwards"))
            {
                player.AddRelativeForce(0, 0, -aircontrolSpeed, ForceMode.Force);
            }

            if (Input.GetButton("Walk Right"))
            {
                player.AddRelativeForce(aircontrolSpeed, 0, 0, ForceMode.Force);
            }

            if (Input.GetButton("Walk Left"))
            {
                player.AddRelativeForce(-aircontrolSpeed, 0, 0, ForceMode.Force);
            }
        }
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, groundDistance + 0.1f);
    }
}
