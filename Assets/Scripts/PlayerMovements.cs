using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class PlayerMovements : MonoBehaviour
{
	public float speed = 0.1f;
	public Animator anims;
	public SpriteRenderer spritix;
	Vector3 playerPos;
	Vector3 otherPos;
	int meditate;
	public MMFeedbacks cameraFeedstrong;
	public ParticleSystem meditateStrong;
	public AudioSource AS;
	public AudioClip AC;	
	
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
				transform.position += new Vector3(0, 0, PS.speed);
				anims.SetBool("isWalk", true);
			}

			if (Input.GetKey(KeyCode.DownArrow))
			{
				transform.position += new Vector3(0, 0, -PS.speed);
				anims.SetBool("isWalk", true);
			}

			if (Input.GetKey(KeyCode.LeftArrow))
			{
				transform.position += new Vector3(-PS.speed, 0, 0);
				anims.SetBool("isWalk", true);				
				spritix.flipX = true;	
			}

			if (Input.GetKey(KeyCode.RightArrow))
			{
				transform.position += new Vector3(PS.speed, 0, 0);
				anims.SetBool("isWalk", true);
				spritix.flipX = false;
			}
			
		if(otherPos != playerPos)
		{
			anims.SetBool("isWalk", true);
			anims.SetBool("isMeditate", false);
			anims.SetBool("isPrep", false);
			meditate = 0;
			meditateStrong.Stop();
			PS.isMeditate = false;
		}
		else
		{
			anims.SetBool("isWalk", false);
			meditate++;
		}
		
		if(meditate >= 240)
		{
			anims.SetBool("isPrep", true);
			meditate = 0;
		}
		
	}
	
	void LateUpdate()
	{
		otherPos = playerPos;
		anims.SetBool("isHurt", false);
	}
	
	void PrepMed()
	{
		anims.SetBool("isMeditate", true);
		cameraFeedstrong?.PlayFeedbacks();
		meditateStrong.Play();
		AS.PlayOneShot(AC, 1f);
		PS.isMeditate = true;
		spritix.flipX = false;
	}
		
}

