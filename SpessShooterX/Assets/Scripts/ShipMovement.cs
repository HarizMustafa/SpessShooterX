using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{
	public float movementSpeed = 1.0f;
	public int invert = -1; //Negative 1 for invert, positive 1 for not


	// Update is called once per frame
	void Update ()
	{
				float horizontal = Input.GetAxis ("Horizontal");
				float vertical = Input.GetAxis ("Vertical");
		
				Vector3 direction = new Vector3 (horizontal, invert * vertical, 0);
				Vector3 finalDirection = new Vector3 (horizontal, invert * vertical, 1.0f);
		
				transform.position += direction * movementSpeed * Time.deltaTime;

				transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.LookRotation (finalDirection), Mathf.Deg2Rad * 50.0f);

	}
}
