using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
	public List<GameObject> monstersPref;

	int cooldownSpawn;
	public int cooldownRate;
	Vector3 randomPos;
	public int nombre;
	public float timer;
	public TextMeshProUGUI timerText;
	
	
	void Start()
	{
		Application.targetFrameRate = 60;
	}
	
    void Update()
	{	
		
	    cooldownSpawn += Random.Range(1,5);
	    
	    if(cooldownSpawn >= cooldownRate)
	    {	
	    	if(Random.Range(1,100) == 25 && timer >= 60)
	    	{
		    	randomPos = new Vector3(RandomExcept(-20,20,0,1,2,3,4,-1,-2,-3,-4),0,RandomExcept(-20,20,0,1,2,3,4,-1,-2,-3,-4));
		    	Instantiate(monstersPref[2], randomPos, Quaternion.identity);
		    	cooldownSpawn = 0;	
		    
	    	}
	    	
		    if(timer >= 60)
		    {
		    	randomPos = new Vector3(RandomExcept(-20,20,0,1,2,3,4,-1,-2,-3,-4),0,RandomExcept(-20,20,0,1,2,3,4,-1,-2,-3,-4));
		    	Instantiate(monstersPref[Random.Range(0,2)], randomPos, Quaternion.identity);
		    	cooldownSpawn = 0;	
		    }
	    	else
	    	{
		    	randomPos = new Vector3(RandomExcept(-20,20,0,1,2,3,4,-1,-2,-3,-4),0,RandomExcept(-20,20,0,1,2,3,4,-1,-2,-3,-4));
		    	Instantiate(monstersPref[0], randomPos, Quaternion.identity);
		    	cooldownSpawn = 0;		    	    		
	    	}
	    }
	    
	    timer += Time.deltaTime;
	    TimerDisplay(timer);

    }

	void TimerDisplay(float displayTime)
	{
		displayTime += 1;
		float minutes = Mathf.FloorToInt(displayTime / 60);
		float seconds = Mathf.FloorToInt(displayTime % 60);
		timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	}
	
	public int RandomExcept(int minus, int maxus, int zero, int one, int two, int three, int four, int negOne, int negTwo, int negThree, int negFour)
	{
		int randomNbr = zero;
		
		while(randomNbr == zero || randomNbr == one || randomNbr == two || randomNbr == three || randomNbr == four || randomNbr == negOne || randomNbr == negTwo || randomNbr == negThree || randomNbr == negFour)
		{
			randomNbr = Random.Range(minus,maxus);
		}
		
		return randomNbr;
	}
}
    

