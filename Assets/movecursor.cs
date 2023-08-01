using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecursor : MonoBehaviour
{
	public int counter;
	public bool isLoop;

    void Update()
    {
	    if(counter < 60 && !isLoop)
	    {
	    	counter++;
	    	transform.position += new Vector3(0.25f, 0, 0);
	    }
	    
	    if(counter == 60 && !isLoop)
	    {
	    	isLoop = true;
	    }
	    
	    if(counter > 0 && isLoop)
	    {
	    	counter--;
	    	transform.position -= new Vector3(0.25f, 0, 0);
	    }
	    
	    if(counter == 0 && isLoop)
	    {
	    	isLoop = false;
	    }
    }
}
