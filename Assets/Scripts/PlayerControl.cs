using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	private Transform groundCheck;				// A position marking where to check if the player is grounded.
	private bool isGrounded = false;			//Bool checking if the playr is on the ground
	private bool isJumping = false; 			//If the player is jumping 
	private bool isUnderGrounded = false; 		//if the player is hitting underground
	public float maxSpeed = 3f;
	public float moveForce = 365f;
	public float jumpForce;
	[HideInInspector]
	public bool facingRight = true;	

	private Animator anim = new Animator ();

	public int value;

	void Awake () 
	{
		groundCheck = transform.Find("GroundCheck");
		anim = GetComponent<Animator>();
	}

	void Update () 
	{
		//Check if the player is on the ground
		isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		if (Input.GetButtonDown ("Jump") && isGrounded) {
			//Jump if possible
			isJumping = true;
		}

		isUnderGrounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("UnderGround"));
	}

	void FixedUpdate()
	{
		//Reading the user input on the Horizontal axis
		float horizontalAxis = Input.GetAxis("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (horizontalAxis));

		if (isUnderGrounded) 
		{
			Application.LoadLevel(Application.loadedLevelName);
		}
		//If speed is lower than the maximum...
		if (horizontalAxis * rigidbody2D.velocity.x < maxSpeed) 
		{
			//Add force to the direction from the input
			rigidbody2D.AddForce (Vector2.right * horizontalAxis * moveForce);
		}

		//If the speed is bigger...
		if (Mathf.Abs (rigidbody2D.velocity.x) > maxSpeed) 
		{
			//Set the speed to be tha maximum speed
			rigidbody2D.velocity = new Vector2 (Mathf.Sign (rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
		}

		//If the horizontal input is to the right and we are looking left
		if (horizontalAxis > 0 && !facingRight) 
		{
			Flip ();
		} 
		//The same but for the other direction
		else if (horizontalAxis < 0 && facingRight) 
		{
			Flip ();
		}

		//If the player wants to jump and is allowed to
		if(isJumping)
		{
			//Add force to  the hero to fire him up
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			isJumping = false;
		}
	}

	void OnCollisionEnter2D(Collision2D e)
	{
		if(e.gameObject.tag == "Function")
		{
			e.gameObject.SendMessage("ActionFunction", value);
		}
		//Debug.Log ("Collision");
	}

	public void receiveValue(int valueToReceive)
	{
		value += valueToReceive;
	}

	public void killAnimation()
	{
		GameObject.Find ("TheGoodHero").GetComponent<Animator> ().SetBool ("isAttacking", false);
	}

	void Flip ()
	{
		//Flip the hero the other way around
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void Functionaized(int newValue)
	{
		value = newValue;	
	}

}







































