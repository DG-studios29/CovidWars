using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
	public GameObject thirdPerson;
	public GameObject firstPerson;
	public int CameraMode;

	private void Update( )
	{
		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			if(CameraMode==1)
			{
				CameraMode = 0;
			}
			else
			{
				CameraMode += 1;
			}
			StartCoroutine(CameraChange());
		}
		//Cursor.lockState = CursorLockMode.Locked;
	}
	IEnumerator CameraChange()
	{
		yield return new WaitForSeconds(0.01f);
		if(CameraMode == 0)
		{
			thirdPerson.SetActive(true);
		   firstPerson.SetActive(false);
		}

		if (CameraMode == 1)
		{
			thirdPerson.SetActive(false);
			firstPerson.SetActive(true);
		}
	}

}
