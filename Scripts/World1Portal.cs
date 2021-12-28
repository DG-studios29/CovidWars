using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World1Portal : MonoBehaviour
{
	private Transform Destination;
	public AudioClip portalSound;

	private void OnTriggerEnter(Collider other)
	{
		other.gameObject.SetActive(false);
		Destination = GameObject.FindGameObjectWithTag("Portal1").GetComponent<Transform>();
		other.transform.position = Destination.position;
		other.gameObject.SetActive(true);
		AudioSource.PlayClipAtPoint(portalSound, transform.position);
		other.GetComponent<PlayerController>().agent.SetDestination(Destination.position);

	}
}
