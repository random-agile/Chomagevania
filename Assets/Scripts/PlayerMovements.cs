using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
	public float speed = 0.1f;
	public Animator anims;
	SpriteRenderer spritix;
	bool isWalking;
	Vector3 playerPos;
	Vector3 otherPos;
	
	PlayerStats PS;
	
	void Start()
	{
		PS = gameObject.GetComponent<PlayerStats>();
		spritix = this.gameObject.GetComponent<SpriteRenderer>();
		playerPos = transform.position;
		otherPos = transform.position;
	}

		void FixedUpdate()
	{	
		playerPos = transform.position;
		
			if (Input.GetKey(KeyCode.UpArrow))
			{
				transform.position += new Vector3(0, 0, -PS.speed);
				anims.SetBool("isWalk", true);
			}

			if (Input.GetKey(KeyCode.DownArrow))
			{
				transform.position += new Vector3(0, 0, PS.speed);
				anims.SetBool("isWalk", true);
			}

			if (Input.GetKey(KeyCode.LeftArrow))
			{
				transform.position += new Vector3(PS.speed, 0, 0);
				anims.SetBool("isWalk", true);				
				spritix.flipX = false;				
			}

			if (Input.GetKey(KeyCode.RightArrow))
			{
				transform.position += new Vector3(-PS.speed, 0, 0);
				anims.SetBool("isWalk", true);
				spritix.flipX = true;
			}
			
		if(otherPos != playerPos)
		{
			anims.SetBool("isWalk", true);
		}
		else
		{
			anims.SetBool("isWalk", false);
		}
		
	}
	void LateUpdate()
	{
		otherPos = playerPos;
	}
		
}

