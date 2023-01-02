using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
	Transform laserPos;
	public Transform playerPos;
	
	void Start()
	{
		laserPos = gameObject.GetComponent<Transform>();
	}
	
    void Update()
    {
	    laserPos.RotateAround(playerPos.position, Vector3.up, 50 * Time.deltaTime);
    }
}
