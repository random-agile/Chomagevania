using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
	public List<GameObject> monstersPref;

	public int cooldownSpawn;
	public int cooldownRate;
	Vector3 randomPos;
	public int nombre;
	public float timer;
	public TextMeshProUGUI timerText;
	int res;
	public TextMeshProUGUI resText;
	public PlayerStats PS;
	
	
	void Start()
	{
		Application.targetFrameRate = 60;
		Screen.SetResolution(3840, 2160, FullScreenMode.ExclusiveFullScreen, 60);
	}
	
    void Update()
	{	
		
	    cooldownSpawn += Random.Range(1,5);
	    
		if(cooldownSpawn >= cooldownRate && !PS.isStop)
	    {	
	    	if(Random.Range(1,100) == 25 && timer >= 60)
	    	{
		    	randomPos = new Vector3(RandomExcept(-20,20,0,1,2,3,4,-1,-2,-3,-4),0,RandomExcept(-20,20,0,1,2,3,4,-1,-2,-3,-4));
		    	Instantiate(monstersPref[0], randomPos, Quaternion.identity);
		    	cooldownSpawn = 0;
		    
	    	}
	    	
		    if(timer >= 60)
		    {
		    	randomPos = new Vector3(RandomExcept(-20,20,0,1,2,3,4,-1,-2,-3,-4),0,RandomExcept(-20,20,0,1,2,3,4,-1,-2,-3,-4));
		    	Instantiate(monstersPref[Random.Range(1,4)], randomPos, Quaternion.identity);
		    	cooldownSpawn = 0;	
		    }
	    	else
	    	{
		    	randomPos = new Vector3(RandomExcept(-20,20,0,1,2,3,4,-1,-2,-3,-4),0,RandomExcept(-20,20,0,1,2,3,4,-1,-2,-3,-4));
		    	Instantiate(monstersPref[Random.Range(1,2)], randomPos, Quaternion.identity);
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
	
	public void ChangeRes()
	{
		res++;
		switch(res)
		{
		case 1:
			Screen.SetResolution(1280, 720, FullScreenMode.ExclusiveFullScreen, 60);
			resText.text = "1280x720";
			break;
		case 2:
			Screen.SetResolution(1366, 768, FullScreenMode.ExclusiveFullScreen, 60);
			resText.text = "1366x768";
			break;
		case 3:
			Screen.SetResolution(1920, 1080, FullScreenMode.ExclusiveFullScreen, 60);
			resText.text = "1920x1080";
			break;
		case 4:
			Screen.SetResolution(2560, 1440, FullScreenMode.ExclusiveFullScreen, 60);
			resText.text = "2560x1440";			
			break;
		case 5:
			Screen.SetResolution(2560, 1600, FullScreenMode.ExclusiveFullScreen, 60);
			resText.text = "2560x1600";			
			break;
		case 6:
			Screen.SetResolution(3840, 2160, FullScreenMode.ExclusiveFullScreen, 60);
			resText.text = "3840x2160";
			res = 0;
			break;
		}	
	}
	
	public void Exit()
	{
		Application.Quit();
	}
	
	public void Reset()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(0);
	}
	
}
    

