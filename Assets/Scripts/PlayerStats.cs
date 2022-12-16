using System.Collections;
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
	public int power;
	public int defense;
	public float moveSpeed;
	
	public bool isMeditate;
	public int meditateDamage;	
	
	[Header("Special Stats")]
	public float weaponSpeed;
	public int weaponHit;
	public Vector3 weaponSize;
	public float weaponCooldown;
	public int weaponStayCooldown;
	public float attractionPower;
	public int meditateCooldown;
	
	[Header("Enemies Stats")]
	public float stunResistance;
	
	[Header("Gear")]
	public List<GameObject> Weapons;
	public List<GameObject> Passives;
	
	[Header("Others")]
	public int golds;
	public int kills;
	float exprests;
	public bool isStop;	
	
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
	
	public AudioSource ASBGM;
	public AudioClip ABCD;
	
	[Header("Animations Effects")]
	public Animator anims;
	public MMFeedbacks cameraFeed;
	public MMFeedbacks gameOverFeed;
	public ParticleSystem powerUp;
	public ParticleSystem hitUp;

	public GameObject gameOver;
	
	
	void Awake()
	{
		hpSlider.maxValue = hpMax;
		hpSlider.value = hp;
		expSlider.maxValue = expMax;
		expSlider.value = exp;
		hpCount.text = hp.ToString();
	}
	
	void Update()
	{
		
		if(isMeditate)
		{
			meditateDamage = 10;
		}
		else
		{
			meditateDamage = 0;
		}
		
		if(exp >= expMax)
		{
			LevelUp();
		}

	}
	
	public void GetExp()
	{
			exp += 2;
			expSlider.value = exp;
			AS.PlayOneShot(AC, 1f);
	}
	
	public void GetHit()
	{
		hp -= 5;
		hpSlider.value = hp;
		hpCount.text = hp.ToString();
		AS.PlayOneShot(ACDC, 0.25f);
		anims.SetBool("isHurt", true);
		cameraFeed?.PlayFeedbacks();
		hitUp.Play();
		if(hp <= 0)
		{
			Time.timeScale = 0f;
			isStop = true;
			GameOver();			
		}
	}
	
	void LevelUp()
	{
		powerUp.Play();
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
		hpCount.text = hp.ToString();
		moveSpeed += 0.001f;
		power +=1;
		weaponSpeed+=5f;
		Time.timeScale = 0f;
		isStop = true;
	}
	
	void GameOver()
	{
		gameOverFeed?.PlayFeedbacks();
		ASBGM.Stop();
		ASBGM.PlayOneShot(ABCD);
		gameOver.SetActive(true);
	}

}
