using UnityEngine;
using System.Collections;

public class ScrollTexture : MonoBehaviour
{
	public Vector2 scrollSpeed = Vector2.one;
	public Renderer rend;
	private Material mat;
	private bool canMove;
	
	// Use this for initialization
	void Start ()
	{
		rend = GetComponent<Renderer> ();
		rend.enabled = false; //hides whatever GameObject script is attached to
		canMove = false;
		scrollSpeed.x = 0;
		scrollSpeed.y = 0;
		mat = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update ()
	{
		StartCoroutine (Wait(20.0f));
		canMove = true;
		if (canMove == true) 
		{
			scrollSpeed.y = -5.0f;
		}
	}

	IEnumerator Wait(float waitTime) 
	{
		yield return new WaitForSeconds(waitTime);
		mat.mainTextureOffset += scrollSpeed*Time.deltaTime; 
		rend.enabled = true; //unhides GameObject attached to script after a certain amount of time
	}

}
