using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpSystem : MonoBehaviour
{
	List<string> weapons;
	List<int> weaponsLvl;
	public List<bool> slotTakenW;
	List<string> passives;
	List<int> passivesLvl;
	public List<bool> slotTakenP;
	int chosenSlot;
	int index;
	int actualLevel;
	
	public List<GameObject> weaponPref;
	public List<GameObject> weaponIcon;
	public List<GameObject> passivesIcon;
	
	public List<Transform> canvasStockerW;
	public List<Transform> canvasStockerP;
	
	public Transform playerPos;
	
	PlayerStats PS;
	
	public GameObject LevelUpUI;
	
	
	void Awake()
	{		
		weapons = new List<string>();
		weaponsLvl = new List<int>();
		passives = new List<string>();
		passivesLvl = new List<int>();
		PS = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
		LevelUpUI.SetActive(true);
		LevelUpUI.SetActive(false);
	}
	
	void Start()
	{
		//CheckLevelWeapon("MagicBalls");
		//LevelUpWeapon("MagicBalls", actualLevel);
		//AddNewPassive("HPMax");
		//CheckLevelPassive("HPMax");
		//LevelUpPassives("HPMax", actualLevel);
	}
	
	void AddNewWeapon(string weaponName)
	{
		switch(weaponName)
		{
		case "MagicBalls":
			Instantiate(weaponPref[0], playerPos);
			weapons.Add("MagicBalls");
			weaponsLvl.Add(0);
			CheckSlotWeapon();
			Instantiate(weaponIcon[0], canvasStockerW[chosenSlot]);
			break;
		}
	}
	
	void AddNewPassive(string passiveName)
	{
		switch(passiveName)
		{
		case "HPMax":
			PS.hpMax+=20;
			PS.hpSlider.maxValue = PS.hpMax;
			passives.Add("HPMax");
			passivesLvl.Add(0);
			CheckSlotPassive();
			Instantiate(passivesIcon[0], canvasStockerP[chosenSlot]);
			break;
		}
	}
	
	
	
	void CheckSlotWeapon()
	{
		for(int i = 0; i < 5; i++)
		{
			if(slotTakenW[i])
			{
				Debug.Log(slotTakenW[i]);
			}
			
			else if(!slotTakenW[i])
			{
				slotTakenW[i] = true;
				chosenSlot = i;
				return;
			}
			
			if(slotTakenW.TrueForAll(x => x))
			{
				Debug.Log("full");
			}			
		}
	}
	
	void CheckSlotPassive()
	{
		for(int i = 0; i < 5; i++)
		{
			if(slotTakenP[i])
			{
				Debug.Log(slotTakenP[i]);
			}
			
			else if(!slotTakenP[i])
			{
				slotTakenP[i] = true;
				chosenSlot = i;
				return;
			}
			
			if(slotTakenP.TrueForAll(x => x))
			{
				Debug.Log("full");
			}			
		}
	}
	
	void CheckLevelWeapon(string weaponName)
	{
		index = weapons.IndexOf(weaponName);
		actualLevel = weaponsLvl[index];
	}
	
	void CheckLevelPassive(string passiveName)
	{
		index = passives.IndexOf(passiveName);
		actualLevel = passivesLvl[index];
	}
	
	void LevelUpWeapon(string weaponName, int weaponLevel)
	{
		switch(weaponLevel)
		{
		case 0:
			switch(weaponName)
			{
			case "MagicBalls":
				RotateBall RB = GameObject.Find("MagicBalls(Clone)").GetComponent<RotateBall>();
				RB.wSpeed += 1f;
				index = weapons.IndexOf("MagicBalls");
				weaponsLvl[index]+=1;
				break;
			case "Tornado":
				GameObject tornado = GameObject.Find("Tornado(Clone)");
				tornado.transform.localScale += new Vector3(0.1f,0.1f,0.1f);
				weaponsLvl[index]+=1;
				break;
			case "Katana":
				Katana K = GameObject.Find("Katana(Clone)").GetComponent<Katana>();
				K.katanaCooldown += 5;
				weaponsLvl[index]+=1;
				break;
			case "FlameThrow":
				FlameThrow FT = GameObject.Find("FlameThrow(Clone)").GetComponent<FlameThrow>();
				FT.weaponDuration += 20;
				weaponsLvl[index]+=1;
				break;
			case "Laser":
				break;
			}
			break;
		case 1:
			switch(weaponName)
			{
			case "a":
				break;
			case "b":
				break;
			case "c":
				break;
			case "d":
				break;
			case "e":
				break;
			}
			break;
		case 2:
			switch(weaponName)
			{
			case "a":
				break;
			case "b":
				break;
			case "c":
				break;
			case "d":
				break;
			case "e":
				break;
			}
			break;
		case 3:
			switch(weaponName)
			{
			case "a":
				break;
			case "b":
				break;
			case "c":
				break;
			case "d":
				break;
			case "e":
				break;
			}
			break;
		case 4:
			switch(weaponName)
			{
			case "a":
				break;
			case "b":
				break;
			case "c":
				break;
			case "d":
				break;
			case "e":
				break;
			}
			break;
		}
		
	}
	
	void LevelUpPassives(string passiveName, int passiveLevel)
	{
		switch(passiveLevel)
		{
		case 0:
			switch(passiveName)
			{
			case "HPMax":
				PS.hpMax+=20;
				PS.hpSlider.maxValue = PS.hpMax;
				index = passives.IndexOf("HPMax");
				passivesLvl[index]+=1;
				break;
			case "b":
				break;
			case "c":
				break;
			case "d":
				break;
			case "e":
				break;
			}
			break;
		case 1:
			switch(passiveName)
			{
			case "a":
				break;
			case "b":
				break;
			case "c":
				break;
			case "d":
				break;
			case "e":
				break;
			}
			break;
		case 2:
			switch(passiveName)
			{
			case "a":
				break;
			case "b":
				break;
			case "c":
				break;
			case "d":
				break;
			case "e":
				break;
			}
			break;
		case 3:
			switch(passiveName)
			{
			case "a":
				break;
			case "b":
				break;
			case "c":
				break;
			case "d":
				break;
			case "e":
				break;
			}
			break;
		case 4:
			switch(passiveName)
			{
			case "a":
				break;
			case "b":
				break;
			case "c":
				break;
			case "d":
				break;
			case "e":
				break;
			}
			break;
		}
	}
	
	//button public function onClick
	
	public void AddMagicBalls()
	{
		AddNewWeapon("MagicBalls");
		LevelUpUI.SetActive(false);
		Time.timeScale = 1f;
		PS.isStop = false;
	}
}
