using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public static bool gamePause = false;
	public GameObject pauseUI;
	// Update is called once per frame
	void Update( )
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (gamePause)
			{
				resumeGame();
			}
			else
			{
				pauseGame();
			}
		}
	}
	public void resumeGame( )
	{
		pauseUI.SetActive(false);
		Time.timeScale = 1f;
		gamePause = false;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	void pauseGame( )
	{
		pauseUI.SetActive(true);
		Time.timeScale = 0f;
		gamePause = true;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
	public void loadMenu( )
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(0);
	}
	public void quitGame( )
	{
		Debug.Log("You quit the game");
		Application.Quit();
	}
	public void restartGame( )
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
