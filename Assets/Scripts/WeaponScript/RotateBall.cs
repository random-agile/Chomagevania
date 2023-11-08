using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBall : MonoBehaviour
{
	Transform playerPos;
	
	[Header("Stats")]
	public float wSpeed;
	Vector3 wSize;
	float meditateBoost;
	
	[Header("Sound")]
	AudioSource AS;
	public AudioClip AC;
	PlayerStats PS;
	
	void Start()
	{
		playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
		PS = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
		AS = GameObject.Find("SE").GetComponent<AudioSource>();
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
		
		transform.Rotate(-Vector3.up, wSpeed + PS.weaponSpeed * Time.deltaTime * meditateBoost);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Monster")
		{
			AS.PlayOneShot(AC, 0.1f);
		}
	}

}
