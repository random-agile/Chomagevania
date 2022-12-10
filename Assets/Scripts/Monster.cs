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
	public int exp;
	public int gold;
	
	[Header("Miscs")]
	Transform playerPos;
	public GameObject experience;
	public GameObject damagePops;
	TextMeshProUGUI killText;
	PlayerStats PS;
	Animator anims;
	bool isHit;
	
	void Start()
	{
		playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
		PS = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
		killText = GameObject.FindWithTag("Score").GetComponent<TextMeshProUGUI>();
		anims = gameObject.GetComponent<Animator>();
		
	}
    void Update()
	{
		if(!isHit)
		{
			transform.position = Vector3.MoveTowards(transform.position, playerPos.transform.position, speed);
		}
	}
    
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Weapon")
		{
			isHit = true;
			GameObject go = Instantiate(damagePops,transform.position, Quaternion.identity);
			go.GetComponentInChildren<TextMesh>().text = 5.ToString();
			
			if(Random.Range(1,4) == 2)
			{
				Instantiate(experience,transform.position, Quaternion.identity);
			}
			PS.kills++;
			killText.text = PS.kills.ToString();
			anims.SetBool("isDead", true);
		}
	}
	
	void EndGhost()
	{
		Destroy(this.gameObject);
	}
}
