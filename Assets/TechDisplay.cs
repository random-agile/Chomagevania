using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TechDisplay : MonoBehaviour
{
	public Card card;
	public TextMeshProUGUI name;
	public TextMeshProUGUI description;
	public TextMeshProUGUI cost;
	public TextMeshProUGUI power;
	public TextMeshProUGUI targetType;
	
	void Start()
	{
		name.text = card.name;
		description.text = card.description;
		cost.text = card.cost.ToString();
		power.text = card.power.ToString();
		targetType.text = card.targetType.ToString();
	}
}
