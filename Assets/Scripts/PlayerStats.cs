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
	public float speed;
	public int power;
	public int defense;
	
	public bool isMeditate;
	public int meditateDamage;
	
	public float WeaponSpeed;
	
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
	
	public Rigidbody rb;
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
			speed += 0.0025f;
			power +=1;
			WeaponSpeed*=1.25f;
		}

	}
	
	void OnCollisionEnter(Collision other)
	{
		if(other.transform.tag == "Monster")
		{
			rb.Sleep();
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
		
		if(other.transform.tag == "Experience")
		{
			rb.velocity = new Vector3(0,0,0);
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
	
	void GameOver()
	{
		gameOverFeed?.PlayFeedbacks();
		ASBGM.Stop();
		ASBGM.PlayOneShot(ABCD);
		gameOver.SetActive(true);
	}

}
