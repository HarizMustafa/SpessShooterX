using UnityEngine;
using System.Collections;

public class AutoType : MonoBehaviour
{
	public float LetterPause = 0.1f;
	public AudioClip sound;
	
	private bool _textFinished;
	private int _textIndex;
	private string[] _stanzas;
	
	public void Start()
	{
		_stanzas = new []{ "Homeworld status: Destroyed", "Enemies: Detected", "Engaging: Warp Drives", "Ship Status: Combat Ready", "" };
		
		_textFinished = true;
		_textIndex = -1;
	}
	
	public void Update()
	{
		if (_textFinished)
		{
			if (_textIndex++ >= (_stanzas.Length - 1))
			{
				_textIndex = 0;
			}
			
			SetText(_stanzas[_textIndex]);
			_textFinished = false; //stops text from infinitely typing
		}
	}
	
	private IEnumerator TypeText(float waitTime, string text)
	{
			_textFinished = false;
		
			GetComponent<GUIText>().text = "";
		
			foreach (char letter in text) 
			{
				GetComponent<GUIText>().text += letter;
				GetComponent<AudioSource>().PlayOneShot (sound);
				yield return new WaitForSeconds (waitTime);

			}

			_textFinished = true;
	}	
	
	private void SetText(string text)
	{
		StartCoroutine(TypeText(LetterPause, text));
	}
	
	public void OnGUI()
	{
		//GUI.Label(new Rect(10, 10, 150, 100), "Text:" + guiText.text);
	}
}