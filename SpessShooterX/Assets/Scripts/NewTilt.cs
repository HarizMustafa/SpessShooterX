using UnityEngine;
using System.Collections;

public class NewTilt : MonoBehaviour 
{
	public float Xsensitivity;
	public float Ysensitivity;
	public float Zsensitivity;

	private float rotationDirX = 0f;
	private float rotationDirY = 0f;
	private float rotationDirZ = 0f;

	private Vector3 dir = Vector3.zero; 

	void Start () 
	{
		Input.gyro.enabled = true; // Activate the gyroscope
	}

	void Update () 
	{

		float smoothnessX = Time.deltaTime * Xsensitivity;
		float smoothnessY = Time.deltaTime * Ysensitivity;
		float smoothnessZ = Time.deltaTime * Zsensitivity;

		dir.x = -Input.gyro.rotationRate.y * smoothnessX; //original
		dir.y =  Input.gyro.rotationRate.z * smoothnessZ;
		dir.z = -Input.gyro.rotationRate.x * smoothnessY;

		//transform.Rotate(dir.z * smoothnessY, dir.x * smoothnessX, dir.y * smoothnessZ); //original

		rotationDirX += dir.x ;
		rotationDirX = Mathf.Clamp (rotationDirX, -60, 60); //clamp min and max angles, in this case clamping rotation of X-axis from -60 degrees to 60 degrees.

		rotationDirY += dir.y ;
		rotationDirY = Mathf.Clamp (rotationDirY, -30, 30);

		rotationDirZ += dir.z ;
		rotationDirZ = Mathf.Clamp (rotationDirZ, -30, 30);
		
		transform.localEulerAngles = new Vector3(rotationDirZ, rotationDirX, rotationDirY);

		//transform.Rotate(dir.z , dir.x , dir.y); //original

	}
}
