using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
	public string itemName;
	public string discr;
	public Sprite icon;
	public Items[] itemsNeeded;
	public string taskComplete;

	//private void OnTriggerEnter(Collider other)
	//{
	//	if (other.gameObject.tag == "Player")
	//	{
	//		other.GetComponent<PlayerController>().addToInventory(this);
	//		Destroy(this.gameObject);
	//	}
	//}
}
