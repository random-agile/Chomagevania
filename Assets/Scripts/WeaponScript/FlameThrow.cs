using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrow : MonoBehaviour
{
	int cooldown;
	bool isCool;
	int waitCool;
	ParticleSystem flameThrow;
	PlayerStats PS;
	BoxCollider boxCol;
	
	public int weaponDuration;
	public int weaponCooldown;
	
	
	void Start()
	{
		flameThrow = gameObject.GetComponent<ParticleSystem>();
		PS = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
		boxCol = gameObject.GetComponent<BoxCollider>();
	}
	
    void Update()
	{
		
		if(cooldown >= PS.weaponCooldown && !isCool)
		{
			flameThrow.Play();
			boxCol.enabled = true;
			isCool = true;
			cooldown = 0;
		}
		else if(isCool && waitCool <= weaponDuration)
		{
			waitCool++;
		}
		else if(isCool && waitCool >= weaponCooldown)
		{
			waitCool = 0;
			boxCol.enabled = false;
			flameThrow.Stop();
			isCool = false;
		}
		else if(!isCool)
		{
			cooldown++;
		}
		
		/*if(Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
		{
			gameObject.transform.rotation = Quaternion.Euler(0,-45,0);
		}
		else if(Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
		{
			gameObject.transform.rotation = Quaternion.Euler(0,-315,0);
		}
		else if(Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
		{
			gameObject.transform.rotation = Quaternion.Euler(0,-135,0);
		}
		else if(Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
		{
			gameObject.transform.rotation = Quaternion.Euler(0,-225,0);
		}
		else if(Input.GetKey(KeyCode.UpArrow))
		{
			gameObject.transform.rotation = Quaternion.Euler(0,-360,0);
		}
		else if(Input.GetKey(KeyCode.DownArrow))
		{
			gameObject.transform.rotation = Quaternion.Euler(0,180,0);
		}
		else if(Input.GetKey(KeyCode.LeftArrow))
		{
			gameObject.transform.rotation = Quaternion.Euler(0,-90,0);
		}
		else if(Input.GetKey(KeyCode.RightArrow))
		{
			gameObject.transform.rotation = Quaternion.Euler(0,-270,0);
		}*/
			    
    }
}
