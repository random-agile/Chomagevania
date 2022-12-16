using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpBehaviour : MonoBehaviour
{
	float distance;
	Transform playerPos;
	int dropdown;
	PlayerStats PS;
	
	void Start()
	{
		playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
		PS = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
	}

	void Update()
	{		
		distance = Vector3.Distance(playerPos.position, transform.position);
		
		if(distance < PS.attractionPower)
		{
			transform.position = Vector3.MoveTowards(transform.position, playerPos.transform.position, 0.1f);
		}
	}
    
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Player")
		{
			PS.GetExp();
			Destroy(gameObject);			
		}
	}
}
