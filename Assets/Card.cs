using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tech", menuName = "Tech")]
public class Card : ScriptableObject
{
	public new string name;
	public string description;
	public int cost;
	public int power;
	public string targetType;
	
}
