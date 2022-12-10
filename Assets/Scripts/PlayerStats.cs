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
	public int exp;
	public int expMax;	
	public float speed;
	public int power;
	public int defense;
	
	[Header("Gear")]
	public List<GameObject> Weapons;
	public List<GameObject> Passives;
	
	[Header("Others")]
	public int golds;
	public int kills;
	int exprests;
	
	
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
			expMax = expMax * 2;
			expSlider.maxValue = expMax;
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
			exp += 2;
			expSlider.value = exp;
			AS.PlayOneShot(AC, 1f);
		}
	}

}
