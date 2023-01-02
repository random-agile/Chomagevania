using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class PlayerMovements : MonoBehaviour
{
	public Animator anims;
	public SpriteRenderer spritix;
	Vector3 playerPos;
	Vector3 otherPos;
	int meditate;
	public MMFeedbacks cameraFeedstrong;
	public ParticleSystem meditateStrong;
	public AudioSource AS;
	public AudioClip AC;
	public GameObject flame;
	
	PlayerStats PS;
	
	void Start()
	{
		PS = gameObject.GetComponent<PlayerStats>();
		spritix = this.gameObject.GetComponent<SpriteRenderer>();
		playerPos = transform.position;
		otherPos = transform.position;
	}

		void Update()
	{	
		playerPos = transform.position;
		
		if (Input.GetKey(KeyCode.UpArrow) && !PS.isStop)
			{
				transform.position += new Vector3(0, 0, PS.moveSpeed);
				anims.SetBool("isWalk", true);
			}

			if (Input.GetKey(KeyCode.DownArrow) && !PS.isStop)
			{
				transform.position += new Vector3(0, 0, -PS.moveSpeed);
				anims.SetBool("isWalk", true);
			}

			if (Input.GetKey(KeyCode.LeftArrow) && !PS.isStop)
			{
				transform.position += new Vector3(-PS.moveSpeed, 0, 0);
				anims.SetBool("isWalk", true);				
				spritix.flipX = true;
			}

			if (Input.GetKey(KeyCode.RightArrow) && !PS.isStop)
			{
				transform.position += new Vector3(PS.moveSpeed, 0, 0);
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
		else if(!PS.isStop)
		{
			anims.SetBool("isWalk", false);
			meditate++;
		}
		
		if(meditate >= PS.meditateCooldown)
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

