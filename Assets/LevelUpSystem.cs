using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpSystem : MonoBehaviour
{
	List<string> weapons;
	List<int> weaponsLvl;
	List<bool> slotTakenW;
	List<string> passives;
	List<int> passivesLvl;
	List<bool> slotTakenP;
	
	public List<GameObject> weaponPref;
	public List<GameObject> weaponIcon;
	public List<GameObject> passivesPref;
	
	
	void Start()
	{
		weapons.Add("MagicBalls");
		weaponsLvl.Add(0);
	}
	
	void AddNewWeapon(string weaponName)
	{
		switch(weaponName)
		{
		case "MagicBalls":
			Instantiate(weaponPref[0]);
			weapons.Add("MagicBalls");
			weaponsLvl.Add(0);
			break;
		}
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
				RB.wSpeed += 50f;
				break;
			case "Tornado":
				GameObject tornado = GameObject.Find("Tornado(Clone)");
				tornado.transform.localScale += new Vector3(0.1f,0.1f,0.1f);
				break;
			case "Katana":
				Katana K = GameObject.Find("Katana(Clone)").GetComponent<Katana>();
				K.katanaCooldown += 5;
				break;
			case "FlameThrow":
				FlameThrow FT = GameObject.Find("FlameThrow(Clone)").GetComponent<FlameThrow>();
				FT.weaponDuration += 20;
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
}
