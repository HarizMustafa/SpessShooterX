using UnityEngine;
using System.Collections;

public class AddToScoreOnDestroy : MonoBehaviour
{
	public int pointValue = 100;
	
	void OnTriggerEnter()
	{
		ScoreManager.Instance.score += pointValue;
	}
}
