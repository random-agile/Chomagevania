﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBall : MonoBehaviour
{
	public Transform playerPos;
	public float rotationSpeed = 20f;
	
	[Header("Sound")]
	public AudioSource AS;
	public AudioClip AC;

	void Update()
	{
		transform.RotateAround(playerPos.position, -Vector3.up, rotationSpeed * Time.deltaTime);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Monster")
		{
			AS.PlayOneShot(AC, 0.1f);
		}
	}
	

}
