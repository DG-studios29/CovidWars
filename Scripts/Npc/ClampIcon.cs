using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampIcon : MonoBehaviour
{
	public Transform miniMapCam;
	public float miniMapSize;
	Vector3 temp;

	private void Start( )
	{
		miniMapCam = GameObject.Find("MiniMapCamera").transform;
	}
	void Update( )
	{
		temp = transform.parent.transform.position;
		temp.y = transform.position.y;
		transform.position = temp;
		
	}

	void LateUpdate( )
	{
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, miniMapCam.position.x - miniMapSize, miniMapSize + miniMapCam.position.x),
		transform.position.y, Mathf.Clamp(transform.position.z, miniMapCam.position.z - miniMapSize, miniMapSize + miniMapCam.position.z));

	}

}
