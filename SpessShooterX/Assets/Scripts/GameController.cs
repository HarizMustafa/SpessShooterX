using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText restartTextOutline;
	public GUIText gameOverTextOutline;
	public GUIText quitText;
	public GUIText quitTextOutline;

	public bool gameOver;
	private bool restart;
	private bool quit;
	private int score;
	
	void Start ()
	{
		gameOver = false;
		restart = false;
		quit = false;
		restartText.text = "";
		restartTextOutline.text = "";
		gameOverText.text = "";
		gameOverTextOutline.text = "";
		quitText.text = "";
		quitTextOutline.text = "";

	}
	
	void Update ()
	{
		if (restart)
		{
			if(Input.GetButtonDown("Fire1"))
			{
				Application.LoadLevel (Application.loadedLevel);
				Time.timeScale = 1.0f;
			}
		}

		if (quit)
		{
			if (Input.GetKey("escape"))
			{
				Application.Quit();
			}
		}
	}
		
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOverTextOutline.text = "Game Over!";
		gameOver = true;

		if (gameOver)
		{
			restartText.text = "Tap to Restart";
			restartTextOutline.text = "Tap to Restart";
			restart = true;
			quitText.text = "Press back to Quit";
			quitTextOutline.text = "Press back to Quit";
			quit = true;
			Time.timeScale = 0.0f;
		}
	}
}