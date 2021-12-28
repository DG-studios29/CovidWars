using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Npc : MonoBehaviour
{
	
	public TextAsset npcDialogue;
	public string nameNPC;
	public Color npcColour;
	public Sprite image;
	public  GameObject npcGUI;
	protected DialogueController controller;
	private LinkedList<Dialogue> dialogue = new LinkedList<Dialogue>();

	private void Start( )
	{
		npcGUI.SetActive(false);
	}

	private void Awake( )
	{
		npcGUI = GameObject.Find("NPC(GUI)");
		controller = GameObject.Find("DialgoueController").GetComponent<DialogueController>();
		
	}
	public void TriggerDialogue( )
	{
		npcGUI.SetActive(true);
		Cursor.visible = true;
		Time.timeScale = 0f;
		Cursor.lockState = CursorLockMode.None;
		controller.conversationStart(nameNPC, npcDialogue, npcColour, this,image);

	}
	//public void OnTriggerEnter(Collider other)
	//{
	//	if (other.gameObject.CompareTag("Player"))
	//	{
	//		npcGUI.SetActive(true);
	//		Cursor.visible = true;
	//		Time.timeScale = 0f;
	//		Cursor.lockState = CursorLockMode.None;
	//		TriggerDialogue();

	//	}
	//}
	//public void closeDialogue( )
	//{
		
	//	npcGUI.SetActive(false);
	//	//Cursor.visible = false;
	//	Time.timeScale = 1f;
	//	//Cursor.lockState = CursorLockMode.Locked;

	//}



}
