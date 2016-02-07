using UnityEngine;
using System.Collections;

public class SwipeSimpleCS : MonoBehaviour {

	public Transform player; // Drag your player here
	private Vector2 fp; // first finger position
	private Vector2 lp; // last finger position
	
	void Update () {
		foreach(Touch touch in Input.touches)
		{
			if (touch.phase == TouchPhase.Began)
			{
				fp = touch.position;
				lp = touch.position;
			}
			if (touch.phase == TouchPhase.Moved )
			{
				lp = touch.position;
			}
			if(touch.phase == TouchPhase.Ended)
			{
				if((fp.x - lp.x) > 80) // left swipe
				{
					player.Rotate(0,-90,0);
				}
				else if((fp.x - lp.x) < -80) // right swipe
				{
					player.Rotate(0,90,0);
				}
				else if((fp.y - lp.y) < -80 ) // up swipe
				{
					// add your jumping code here
				}
			}
		}
	}
}
