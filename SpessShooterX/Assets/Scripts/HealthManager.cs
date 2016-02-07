using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour
{
	private static HealthManager instance = null;
	private GameController gameController;
	public static HealthManager Instance
	{
		get { return instance; }
	}
	void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
			return;
		}
		else
		{
			instance = this;
		}

	}
	
	public Transform healthDisplay;
	public float maxHealth = 10.0f;
	private float currentHealth;
	private float healthOriginalYScale;
	
	// Use this for initialization
	void Start ()
	{
			GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
			if (gameControllerObject != null)
			{
				gameController = gameControllerObject.GetComponent <GameController>();
			}
			if (gameController == null)
			{
				Debug.Log ("Cannot find 'GameController' script");
			}
		
		currentHealth = maxHealth;
		healthOriginalYScale = healthDisplay.localScale.y;
	}
	
	public void DamagePlayer(float damageAmount)
	{
		if(damageAmount < 0)
		{
			Debug.LogError("You cannot pass a negative value to DamagePlayer!  Please use RestoreHealth instead!");
			return;
		}
		currentHealth -= damageAmount;
		healthDisplay.localScale = new Vector3(healthDisplay.localScale.x, healthOriginalYScale*(currentHealth/maxHealth),healthDisplay.localScale.x);
		if(currentHealth < 0)
		{
			GameObject mainCameraObject = GameObject.FindGameObjectWithTag ("MainCamera");
			Destroy (mainCameraObject.gameObject);
			gameController.gameOver = true;
			gameController.GameOver();
		}

	}
	
	public void RestoreHealth(float healthAmaount)
	{
		if(healthAmaount < 0)
		{
			Debug.LogError("You cannot pass a negative value to RestoreHealth!  Please use DamagePlayer instead!");
			return;
		}
		currentHealth += healthAmaount;
		if(currentHealth > maxHealth)
		{
			currentHealth = maxHealth;
		}
	}
}
