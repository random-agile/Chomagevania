﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MoreMountains.Feedbacks;

public class PlayerStats : MonoBehaviour
{
	[Header("General Stats")]
	public int level;
	public int hp;
	public int hpMax;
	public float exp;
	public float expMax;	
	public float speed;
	public int power;
	public int defense;
	
	public float WeaponSpeed;
	
	[Header("Gear")]
	public List<GameObject> Weapons;
	public List<GameObject> Passives;
	
	[Header("Others")]
	public int golds;
	public int kills;
	float exprests;
	
	
	[Header("UI Elements")]
	public Slider hpSlider;
	public Slider expSlider;	
	public TextMeshProUGUI killCount;
	public TextMeshProUGUI hpCount;
	public TextMeshProUGUI lvlCount;
	
	[Header("Sound")]
	public AudioSource AS;
	public AudioClip AC;
	public AudioClip ACDe;
	public AudioClip ACDC;
	
	[Header("Animations Effects")]
	public Animator anims;
	public MMFeedbacks cameraFeed;
	
	
	void Awake()
	{
		hpSlider.maxValue = hpMax;
		hpSlider.value = hp;
		expSlider.maxValue = expMax;
		expSlider.value = exp;
	}
	
	void Update()
	{
		if(exp >= expMax)
		{
			AS.PlayOneShot(ACDe, 1f);
			level++;
			lvlCount.text = "Lv. " + level.ToString();
			exprests = exp - expMax;
			exp = 0;
			expSlider.value = 0 + exprests;
			expMax = expMax * 1.25f;
			expSlider.maxValue = expMax;
			hpMax+= 5;
			hp+=5;
			hpSlider.maxValue = hpMax;
			hpSlider.value = hp;
			speed += 0.0025f;
			power +=1;
			WeaponSpeed*=1.25f;
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Monster")
		{
			hp -= 5;
			hpSlider.value = hp;
			hpCount.text = hp.ToString();
			AS.PlayOneShot(ACDC, 0.5f);
			anims.SetBool("isHurt", true);
			cameraFeed?.PlayFeedbacks();
		}
		
		if(other.transform.tag == "Experience")
		{
			if(other.transform.name == "ExpSmall(Clone)")
			{
			exp += 2;
			expSlider.value = exp;
			AS.PlayOneShot(AC, 1f);
			}
			else if(other.transform.name == "ExpMedium(Clone)")
			{
				exp += 50;
				expSlider.value = exp;
				AS.PlayOneShot(AC, 1f);
			}
		}
	}

}
