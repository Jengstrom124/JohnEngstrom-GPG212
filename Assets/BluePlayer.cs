using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayer : MonoBehaviour
{
	//this v3 is just so we can observe Input change in the editor
	public Vector3 inputPrint;
	Vector3 myInput;

	//these variables control the magnitude of our motion- tweak in editor to
	//find good values for your level scale (So far 50,2 seem fine for basic testing,
	//but you may have preferences for a more zippy/stable movement.

	public float speed;
	public float rotationSpeed;

	Rigidbody rb;

	public float jumpForce; //leave this as zero to disable jumping.
	public bool onFloor = false;

	//Vector3 originalPos;
	//GameRules gr;


	// Start is called before the first frame update
	void Start()
	{
		//we need a reference to our own rigidbody object
		//to run it's functions like rb.AddForce() etc.
		rb = this.GetComponent<Rigidbody>();

		//originalPos = this.transform.localPosition;
		//gr = FindObjectOfType<GameRules>();
	}

	// Update is called once per frame
	void Update()
	{
		//detect any player input- controller, keyboard, etc. that could
		//be interpreted as 'horizontal' or 'vertical' input
		//eg. WASD, arrow keys, joystick input.
		//get turning input
		Vector3 myInput = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

		//if we are on a floor, get forwards input
		if (onFloor)
		{
			myInput += new Vector3(0, 0, Input.GetAxis("Vertical"));
		}

		//if we are on a floor and the player has pressed jump
		//add to the y axis of input
		if (Input.GetAxis("Jump") > 0 && onFloor)
		{
			myInput += Vector3.up;

			//Vector3 has some default settings- Vector3.up

		}

		//what we're used to:
		//if(Input.GetKey("w"))
		//returns true if the 'w' key was pressed on the previous update

		//new hotness:
		//Input.GetAxis("Vertical")
		//returns a FLOAT value- positive for up/right, negative for down/left
		//(For no keyboard smoothing, use GetAxisRaw)


		//just to see in editor
		inputPrint = myInput;

		//call the movement function to perform on player input.
		RMove(myInput);

		//if(gr.newRound)
        //{
			//this.transform.localPosition = originalPos;
			//newRound = false;
        //}

	}

	//Movement with Rigidbody
	void RMove(Vector3 movement)
	{
		//Add force forwards to the amount of 'z' input by player
		rb.AddRelativeForce(new Vector3(0, movement.y * jumpForce, movement.z * speed));

		//Turn (non-physics) based on 'x' input by player
		this.transform.Rotate(new Vector3(0, movement.x, 0) * rotationSpeed, Space.Self);

		//For physics turning- might be handy?
		//rb.AddRelativeTorque(new Vector3(0,movement.x,0)*rotationSpeed);

	}


	//runs when we remain in any collision
	void OnCollisionStay(Collision c)
	{
		if (c.gameObject.tag == "Floor")
		{
			onFloor = true;
			//onFloor allows us to move and jump-
			//we decided that the player shouldn't
			//be allowed to jump from a position above
			//the ground! (eg. flying!)
		}

	}

	//runs when we exit a collision
	void OnCollisionExit(Collision c)
	{
		if (c.gameObject.tag == "Floor")
		{
			onFloor = false;
			//if there's no floor beneath us,
			//we shouldn't be able to jump or walk.
		}
	}
}
