using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void loadTutorial( )
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(1);
	} 
	
	public void loadGame( )
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(2);
	}
	
	public void loadSettings( )
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(3);
	}
	public void quitGame( )
	{
		Debug.Log("You quit the game");
		Application.Quit();
	}
}
