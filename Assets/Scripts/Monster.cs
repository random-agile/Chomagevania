using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Monster : MonoBehaviour
{
	[Header("Stats")]
	public int hp;
	public float speed;
	public int power;
	public int defense;
	public int exp;
	public int gold;
	public int stunResistance;
	public int stayResistance;
	
	[Header("Miscs")]
	Transform playerPos;
	public GameObject experience;
	public GameObject damagePops;
	TextMeshProUGUI killText;
	PlayerStats PS; 
	Animator anims;
	SpriteRenderer spriteRenderer;
	bool isStun;
	int stunCooldown;
	ParticleSystem hitFx;
	float distance;
	
	
	void Start()
	{
		playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
		PS = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
		killText = GameObject.FindWithTag("Score").GetComponent<TextMeshProUGUI>();
		anims = gameObject.GetComponent<Animator>();	
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		hitFx = gameObject.GetComponentInChildren<ParticleSystem>();
	}
	
    void Update()
	{
		if(isStun)
		{
			spriteRenderer.color = Color.red;
			transform.position = Vector3.MoveTowards(transform.position, playerPos.transform.position, speed*-PS.stunResistance);
			stunCooldown++;
			if(stunCooldown >= 10)
			{
				isStun = false;
				stunCooldown = 0;
				spriteRenderer.color = Color.white;
			}
		}
		else if(!PS.isStop)
			{
				transform.position = Vector3.MoveTowards(transform.position, playerPos.transform.position, speed);
			}
		
		spriteRenderer.flipX = playerPos.transform.position.x < this.transform.position.x;
		
		distance = Vector3.Distance(playerPos.position, transform.position);
		
		if(distance > 20f)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Weapon")
		{
			switch(other.transform.name)
			{
			case "Magic Ball":
				PS.stunResistance = 4;
				Hit();
				break;
			case "Magic Ball (1)":
				PS.stunResistance = 4;
				Hit();
				break;	
			case "Katana":
				PS.stunResistance = 8;
				Hit();
				break;
			}
		}
		
		else if(other.transform.tag == "Player")
		{
			PS.GetHit();
		}
	}
	
	void OnTriggerStay(Collider other)
	{
		if(other.transform.tag == "Weapon")
		{
			switch(other.transform.name)
			{
			case "Tornado":
				if(stayResistance >= PS.weaponStayCooldown && hp > 0)
				{
					stayResistance = 0;
					PS.stunResistance = 0;
					Hit();
				}
				else
				{
					stayResistance++;
				}
				break;
				
			case "FlameThrow":
				if(stayResistance >= PS.weaponStayCooldown && hp > 0)
				{
					stayResistance = 0;
					PS.stunResistance = 1;
					Hit();
				}
				else
				{
					stayResistance++;
				}
				break;
			}
		}
	}
	
	void EndGhost()
	{
		Destroy(gameObject);
		if(Random.Range(1,3) == 2)
		{
			Instantiate(experience,transform.position, Quaternion.identity);
		}
	}
	
	void Hit()
	{
		hitFx.Play();
		isStun = true;
		GameObject go = Instantiate(damagePops,transform.position, Quaternion.identity);
		go.GetComponentInChildren<TextMesh>().text = (PS.power-defense + PS.meditateDamage).ToString();
		hp -= (PS.power-defense) + PS.meditateDamage;
			
		if(hp <= 0)
		{
			PS.kills++;
			killText.text = PS.kills.ToString();
			anims.SetBool("isDead", true);
		}
	}

}
