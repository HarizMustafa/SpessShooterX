using UnityEngine;
using System.Collections;

public class TiltAround : MonoBehaviour 
{
	private Quaternion localRotation; // 
	public float speed = 0.1f; // ajustable speed from Inspector in Unity editor

	public Transform Player;
	private float MinZRot, MaxZRot,MinXRot,MaxXRot,MinYRot,MaxYRot;
	private float ZRot;


	void Awake()
	{
		//minimum angle allowed for rotation in z-axis
	 	MinZRot = -60.0f; 
		//maximum angle allowed for rotation in z-axis
		MaxZRot = 60.0f;
		ZRot = 0;
		MinXRot = 40.0f;   //25.0f; //25.0f is suitable for third-person shooters
		MaxXRot = 320.0f;
		MinYRot = 40.0f;  //45.0f; //45.0f is suitable for third-person shooters
		MaxYRot = 320.0f; //325.0f; //325.0f is suitable for third-person shooters
	}

	// Use this for initialization
	void Start () 
	{
		// copy the rotation of the object itself into a buffer
		localRotation = transform.rotation;
	}
	
	
	void Update() // runs 60 fps or so
	{
		// find speed based on delta
		float curSpeed = Time.deltaTime * speed;
		// first update the current rotation angles with input from acceleration axis
		localRotation.y += Input.acceleration.x * curSpeed;
		localRotation.x += Input.acceleration.y * curSpeed;
			
		// then rotate this object accordingly to the new angle
		transform.rotation = localRotation;

		//locks movement of z-axis
		ZRot = -Mathf.Atan2(Player.position.x - transform.position.x, Player.position.y - transform.position.y) * (180 / Mathf.PI);
		ZRot = Mathf.Clamp(ZRot, MinZRot, MaxZRot);

		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, ZRot);

		//determines minimum and maximum angle allowed for rotating in x-axis
		if(transform.eulerAngles.x >= MinXRot && transform.eulerAngles.x < MaxXRot)
		{  
			if(transform.eulerAngles.x < 180)
			{  
				transform.eulerAngles = new Vector3(MinXRot, transform.eulerAngles.y, ZRot);  
			} 
			else
			{  
				transform.eulerAngles = new Vector3(MaxXRot, transform.eulerAngles.y, ZRot); 
			}  
		}

		//determines minimum and maximum angle allowed for rotating in y-axis
		if(transform.eulerAngles.y >= MinYRot && transform.eulerAngles.y < MaxYRot)
		{  
			if(transform.eulerAngles.y < 180)
			{  
				transform.eulerAngles = new Vector3(transform.eulerAngles.x, MinYRot, ZRot);  
			} 
			else
			{  
				transform.eulerAngles = new Vector3(transform.eulerAngles.x, MaxYRot, ZRot); 
			}  
		}
	}
	
}