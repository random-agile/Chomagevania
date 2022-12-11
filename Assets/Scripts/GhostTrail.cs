using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTrail : MonoBehaviour
{
	public int ClonesPerSecond = 10;
	public SpriteRenderer sr;
	public Transform tf;
	private Transform thisTf;
	private List<SpriteRenderer> clones;
	public Vector3 scalePerSecond = new Vector3(1f, 1f, 1f);
	public Color colorPerSecond = new Color(255, 255, 255, 1f);
	PlayerMovements PM;
	
	void Start()
	{
		PM = GameObject.FindWithTag("Player").GetComponent<PlayerMovements>();
		thisTf = GetComponent<Transform>();
		//sr = GetComponent<SpriteRenderer>();
		clones = new List<SpriteRenderer>();
		StartCoroutine(trail());
	}
	
	void Update()
	{
		for (int i = 0; i < clones.Count; i++)
		{
			clones[i].color -= colorPerSecond * Time.deltaTime * 8;
			clones[i].transform.localScale -= scalePerSecond * Time.deltaTime * 8;
			if (clones[i].color.a <= 0f || clones[i].transform.localScale == Vector3.zero)
			{
				Destroy(clones[i].gameObject);
				clones.RemoveAt(i);
				i--;
			}
		}
	}
	
	IEnumerator trail()
	{
		for (; ; ) //while(true)
		{
			if (thisTf.position != tf.position)
			{
				var clone = new GameObject("trailClone");
				clone.transform.position = tf.position;
				clone.transform.localScale = tf.localScale;
				var cloneRend = clone.AddComponent<SpriteRenderer>();
				if(PM.spritix.flipX == true)
				{
					clone.GetComponent<SpriteRenderer>().flipX = true;
				}
				cloneRend.sprite = sr.sprite;
				cloneRend.sortingOrder = sr.sortingOrder - 1;
				clones.Add(cloneRend);
			}
			yield return new WaitForSeconds(0.1f / ClonesPerSecond);
		}
	}
	
	void LateUpdate()
	{
		thisTf.position = tf.position;
	}
}