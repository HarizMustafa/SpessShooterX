using UnityEngine;
using System.Collections;

public class ShootForward : MonoBehaviour
{
	public GameObject muzzleFlash;
	public Rigidbody bullet;
	public float velocity = 10.0f;

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			Instantiate(muzzleFlash, transform.position, transform.rotation);
			Rigidbody newBullet = Instantiate(bullet,transform.position,transform.rotation) as Rigidbody;
			newBullet.AddForce(transform.forward*velocity,ForceMode.VelocityChange);
		}
	}
}
