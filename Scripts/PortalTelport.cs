using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class PortalTelport : MonoBehaviour
{
	private Transform Destination;
	public AudioClip portalSound;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			other.gameObject.SetActive(false);
			Destination = GameObject.FindGameObjectWithTag("Portal2").GetComponent<Transform>();
			other.transform.position = Destination.position;
			other.gameObject.SetActive(true);
			AudioSource.PlayClipAtPoint(portalSound, transform.position);
			other.GetComponent<PlayerController>().agent.SetDestination(Destination.position);
		}
		
		
	}

}
