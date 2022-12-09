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

	void Start()
	{
		playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
	}
    void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, playerPos.transform.position, speed);
	}
    
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Player")
		{
			if(hp <= 0)
			{
				Destroy(this.gameObject);
			}
		}
	}
}
