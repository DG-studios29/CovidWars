using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
	public TutorialDialgoue tutorialDialgoue;
	public Button startButton;
	private void Update( )
	{
		if(tutorialDialgoue.startGame)
		{
			startButton.gameObject.SetActive(true);
			
		}
		else
		{
			startButton.gameObject.SetActive(false);
		}
	}

	public void startGame()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(2);
	}
}
