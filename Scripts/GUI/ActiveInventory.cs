using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInventory : MonoBehaviour
{
	public GameObject uiInventory;
	public static bool inventoryIsActive = false;
	public GameObject inputText;
	

	public void Update( )
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			inventoryIsActive = true;

			if (inventoryIsActive)
			{
				uiInventory.SetActive(true);
				Cursor.visible = true;
				Time.timeScale = 0f;
				Cursor.lockState = CursorLockMode.None;
			}
		
		}
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			inventoryIsActive = false;
			if (!inventoryIsActive)
			{
				uiInventory.SetActive(false);
				Cursor.visible = false;
				Time.timeScale = 1f;
				Cursor.lockState = CursorLockMode.Locked;
			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			inputText.SetActive(true);
			Cursor.visible = true;
			Time.timeScale = 0f;
			Cursor.lockState = CursorLockMode.None;


		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			inputText.SetActive(false) ;
			Cursor.visible = false;
			Time.timeScale = 1f;
			Cursor.lockState = CursorLockMode.Locked;


		}
	}
	
}
	
