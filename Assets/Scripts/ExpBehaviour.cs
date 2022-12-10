using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpBehaviour : MonoBehaviour
{
	bool isAttracted;
	float distance;
	Transform playerPos;
	
	void Start()
	{
		playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
	}

	void FixedUpdate()
	{
		distance = Vector3.Distance(playerPos.position, transform.position);
		
		if(distance < 2)
		{
			transform.position = Vector3.MoveTowards(transform.position, playerPos.transform.position, 0.1f);
		}
	}
    
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Player")
		{
			Destroy(this.gameObject);
		}
	}
}
