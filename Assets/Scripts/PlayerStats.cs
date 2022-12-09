using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
	
	
	[Header("UI Elements")]
	public Slider hpSlider;
	public Slider expSlider;	
	public TextMeshProUGUI killCount;
	public TextMeshProUGUI hpCount;
	public TextMeshProUGUI lvlCount;
	
	void Awake()
	{
		hpSlider.maxValue = hpMax;
		hpSlider.value = hp;
		expSlider.maxValue = expMax;
		expSlider.value = exp;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Monster");
		{
			hp -= 5;
			hpSlider.value = hp;
			hpCount.text = hp.ToString();
		}
	}

}
