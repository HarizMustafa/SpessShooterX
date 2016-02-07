using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	
	private static ScoreManager instance = null;
	public static ScoreManager Instance
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
		//DontDestroyOnLoad(this.gameObject);
		//gameObject.name = "$ScoreManager";
	}
	
	public int score = 0;
	
	void OnGUI()
	{
		var myStyle = new GUIStyle();
		myStyle.fontSize = 50;
		myStyle.normal.textColor = Color.white;
		GUILayout.Label("Score: " + score, myStyle);
	}
}
