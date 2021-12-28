using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapFollow : MonoBehaviour
{
	public Transform player;

	private void LateUpdate( )
	{
		Vector3 miniMapFollow = player.position;
		miniMapFollow.y = transform.position.y;
		transform.position = miniMapFollow;
	}
}
