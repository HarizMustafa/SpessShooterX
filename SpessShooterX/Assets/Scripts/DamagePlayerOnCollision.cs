using UnityEngine;
using System.Collections;

public class DamagePlayerOnCollision : MonoBehaviour
{
	public float damageAmount = 1.0f;
	public float coolDownTime = 1.0f;
	
	private bool inCooldown = false;
	
	void OnCollisionEnter()
	{
		if(!inCooldown)
		{
			HealthManager.Instance.DamagePlayer(damageAmount);
			inCooldown = true;
			Invoke("Uncool",coolDownTime);
		}
	}
	
	void Uncool()
	{
		inCooldown = false;
	}
}
