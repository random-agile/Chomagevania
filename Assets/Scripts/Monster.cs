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
			transform.position = Vector3.MoveTowards(transform.position, playerPos.transform.position, speed*-4);
			stunCooldown++;
			if(stunCooldown >= 10)
			{
				isStun = false;
				stunCooldown = 0;
				spriteRenderer.color = Color.white;
			}
		}
			else
			{
				transform.position = Vector3.MoveTowards(transform.position, playerPos.transform.position, speed);
			}
		
		spriteRenderer.flipX = playerPos.transform.position.x < this.transform.position.x;	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Weapon")
		{
			hitFx.Play();
			isStun = true;
			GameObject go = Instantiate(damagePops,transform.position, Quaternion.identity);
			go.GetComponentInChildren<TextMesh>().text = (PS.power-defense + PS.meditateDamage).ToString();
			hp -= (PS.power-defense) + PS.meditateDamage;
			
			if(hp <= 0)
			{
				gameObject.GetComponent<SphereCollider>().enabled = false;
				if(Random.Range(1,3) == 2)
				{
					Instantiate(experience,transform.position, Quaternion.identity);
				}
				PS.kills++;
				killText.text = PS.kills.ToString();
				anims.SetBool("isDead", true);
			}
		}
	}
	
	void EndGhost()
	{
		Destroy(this.gameObject);
	}

}
