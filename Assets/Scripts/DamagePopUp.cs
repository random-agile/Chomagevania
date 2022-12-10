using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopUp : MonoBehaviour
{
	public void EndRarePops()
	{
		Destroy(transform.parent.gameObject);
	}
}