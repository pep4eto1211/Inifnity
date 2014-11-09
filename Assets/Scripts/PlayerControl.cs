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
	private bool isStoneAvailable = false;
	private GameObject stoneObject;
	private bool isArmed = false;

	private Animator anim = new Animator ();

	public static int value = 21;

	void Awake () 
	{
		groundCheck = transform.Find("GroundCheck");
		anim = GetComponent<Animator>();
	}

	void StoneAvailable(GameObject currentStone)
	{
		isStoneAvailable = true;
		stoneObject = currentStone;
	}

	void StoneUnavailable()
	{
		if (!isArmed) 
		{
			isStoneAvailable = false;
			stoneObject = null;
		}
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

		if (isGrounded && horizontalAxis != 0) 
		{
			transform.FindChild ("Trail").particleEmitter.emit = true;
		}
		else 
		{
			transform.FindChild ("Trail").particleEmitter.emit = false;
		}

		//If speed is lower than the maximum...
		if (horizontalAxis * rigidbody2D.velocity.x < maxSpeed) 
		{
			//Add force to the direction from the input
			rigidbody2D.AddForce (Vector2.right * horizontalAxis * moveForce);
		}

		if (Input.GetButtonDown ("Fire2")) 
		{
			if(!isArmed)
			{
				if(isStoneAvailable)
				{
					stoneObject.SetActive(false);
					isArmed = true;
				}
			}
			else
			{
				Vector2 mousePosition;
				if(Input.mousePosition.x  <  Screen.width/2)
				{
					mousePosition = new Vector2((Screen.width-Input.mousePosition.x) * -1, Input.mousePosition.y);
				}
				else
				{
					mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
				}
				stoneObject.transform.position = new Vector2(transform.position.x, transform.position.y+4);
				isArmed = false;
				isStoneAvailable = false;
				stoneObject.SetActive(true);
				stoneObject.rigidbody2D.AddForce(mousePosition, ForceMode2D.Force);
				stoneObject = null;
			}
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
		if (e.gameObject.tag == "Stones")
		{
			Debug.Log("Stone Enter");
		}
		//Debug.Log ("Collision");
	}

	public void receiveValue(int valueToReceive)
	{
		value += valueToReceive;
		GameObject.Find ("updatesText").SendMessage ("showUpdate", "+" + valueToReceive.ToString ());
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
		if (newValue > value) 
		{
			GameObject.Find ("updatesText").SendMessage ("showUpdate", "+" + (newValue - value).ToString ());
		}
		else 
		{
			GameObject.Find ("updatesText").SendMessage ("showUpdate", "-" + (value-newValue).ToString ());
		}
		value = newValue;	
	}

}







































