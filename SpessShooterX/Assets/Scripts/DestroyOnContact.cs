using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour
{
	public GameObject explosion;
	private GameController gameController;
	public float damageAmount = 100.0f;

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

	}

	void OnTriggerEnter(Collider other) 
	{
		Instantiate(explosion, transform.position, transform.rotation);

		if (other.tag == "Player")
		{
			gameController.GameOver ();
		}

		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}