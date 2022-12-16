using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
	public int katanaCooldown;
	int cooldown;
	bool isSlash;
	ParticleSystem swordSlash;
	BoxCollider boxCol;
	PlayerStats PS;
	PlayerMovements PM;
	public AudioClip AC;
	AudioSource AS;
	
	void Start()
	{
		swordSlash = gameObject.GetComponent<ParticleSystem>();
		PS = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
		PM = GameObject.FindWithTag("Player").GetComponent<PlayerMovements>();
		AS = GameObject.Find("SE").GetComponent<AudioSource>();
		boxCol = gameObject.GetComponent<BoxCollider>();
	}

    void Update()
    {
	    if(cooldown >= PS.weaponCooldown)
	    {
	    	swordSlash.Play();
	    	AS.PlayOneShot(AC, 0.1f);
	    	cooldown = 0 + katanaCooldown;
	    	boxCol.enabled = true;
	    }
	    else
	    {
	    	cooldown++;
	    	boxCol.enabled = false;
	    }
	    
	    if(PM.spritix.flipX == true)
	    {
	    	gameObject.transform.rotation = Quaternion.Euler(90,0,0);
	    }
	    else
	    {
	    	gameObject.transform.rotation = Quaternion.Euler(-90,0,0);
	    }
    }
}
