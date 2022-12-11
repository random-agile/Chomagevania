using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBall : MonoBehaviour
{
	public Transform playerPos;
	public float rotationSpeed = 20f;
	float meditateBoost;
	
	[Header("Sound")]
	public AudioSource AS;
	public AudioClip AC;
	PlayerStats PS;
	
	void Start()
	{
		PS = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
	}

	void Update()
	{
		if(PS.isMeditate)
		{
			meditateBoost = 2f;
		}
		else
		{
			meditateBoost = 1f;
		}
		
		transform.RotateAround(playerPos.position, -Vector3.up, PS.WeaponSpeed * Time.deltaTime * meditateBoost);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Monster")
		{
			AS.PlayOneShot(AC, 0.125f);
		}
	}
	

}
