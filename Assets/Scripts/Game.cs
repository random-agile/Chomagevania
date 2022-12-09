using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
	public GameObject ghostPref;
	int cooldownSpawn;
	public int cooldownRate;
	Vector3 randomPos;
	public int nombre;
	
	void Start()
	{
		Application.targetFrameRate = 60;
	}
	
    void Update()
    {
	    cooldownSpawn += Random.Range(1,3);
	    
	    if(cooldownSpawn >= cooldownRate)
	    {	    	
	    	randomPos = new Vector3(Random.Range(-10,10),0,Random.Range(-10,10));
	    	Instantiate(ghostPref, randomPos, Quaternion.identity);
		    cooldownSpawn = 0;
	    }
	    
	    Debug.Log(cooldownSpawn);
    }
}
