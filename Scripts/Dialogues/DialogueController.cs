using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class DialogueController : MonoBehaviour
{

	public TextMeshProUGUI npcNameText;
	public TextMeshProUGUI dialogueText;

	public Image dialogueImage;
	public Image displayImage;
	private Sprite npcImage;

	public GameObject portal;
	public GameObject choicePnl;
	public GameObject npcGUI;

	private int[] currentLines;
	public bool speaking = false;
	public static bool startGame = false;
	private string npcName;

	private Color npcColour;
	private Graph<Dialogue> inputStream;
	
	public PlayerController player;
	private Npc whichNPC;

	public Button nextButton;
	public Button[] choiceBtn;
	private void Update( )
	{
		PortalOpen();
	}
	public void conversationStart(string _name, TextAsset _dialogue, Color _npcColour, Npc _npc, Sprite image)
	{
		whichNPC = _npc;
		speaking = true;
		npcName = _name;
		npcColour = _npcColour;
		npcImage = image;
		currentLines = new int[1] { 1 };
		Graph<Dialogue> inputStream = new Graph<Dialogue>();
		inputStream = divideText(_dialogue.text);
		nextButton.enabled = true;
		PrintDialogue();
	}

	Graph<Dialogue> divideText(string _dialogue)
	{
		string[] textLines = _dialogue.Split('/');

		inputStream = new Graph<Dialogue>();
		for (int i = 0; i < textLines.Length; i++)
		{
			Dialogue tempDialogue = JsonUtility.FromJson<Dialogue>(textLines[i]);
			inputStream.Add(tempDialogue);
		}
		return inputStream;
	}

	private void PrintDialogue( )
	{
		for (int j = 0; j < choiceBtn.Length; j++)
		{
			choiceBtn[j].gameObject.SetActive(false);
		}
		choicePnl.SetActive(false);
		dialogueText.text = "";
		int i = 0;
		foreach (int line in currentLines)
		{
			if (currentLines[0] != 0)
			{
				if (inputStream.Find(line)._data.dialoguePlayer == "" || speaking == true)
				{
					npcNameText.text = npcName;
					dialogueImage.color = npcColour;
					displayImage.sprite = npcImage;
					dialogueText.text = inputStream.Find(currentLines[0])._data.dialogueNPC;
					nextButton.gameObject.SetActive(true);
					speaking = false;
				}
				else
				{
					
					if (CheckInventory(inputStream.Find(line)._data.getItem))
					{
						
						npcNameText.text = "You";
						nextButton.gameObject.SetActive(false);
						//dialogueImage.color = playerColour;
						//string invItem = inputStream.Find(line)._data.getItem;
						choicePnl.SetActive(true);
						//for (int j = 0; j < currentLines.Length; j++)
						//{
						//	choiceBtn[j].gameObject.SetActive(true);
						//	choiceBtn[j].GetComponentInChildren<Text>().text = inputStream.Find(currentLines[j])._data.dialoguePlayer;
						//}
						choiceBtn[i].gameObject.SetActive(true);
						choiceBtn[i].GetComponentInChildren<TextMeshProUGUI>().text = inputStream.Find(currentLines[i])._data.dialoguePlayer;
					}
				}
				i++;
				//}
			}
			else
			{
				nextButton.enabled = true;
			}
		}
		


	}

	public void NextLine( )
	{
		string[] currentLineTemp = inputStream.Find(currentLines[0])._data.nextDialogue.Split(',');
		currentLines = new int[currentLineTemp.Length];
		for (int i = 0; i < currentLineTemp.Length; i++)
		{
			currentLines[i] = Convert.ToInt32(currentLineTemp[i]);
		}
		PrintDialogue();

		if (currentLines[0] == 0)
		{
			currentLines = new int[1] { 1 };
			nextButton.enabled = false;
		}

	}
	public void PrevLine( )
	{
		if (currentLines[0] > 1)
		{
			currentLines[0] = currentLines[0] - 1;
			PrintDialogue();

			if (currentLines[0] == 0)
			{
				startGame = true;
				currentLines = new int[1] { 1 };
				nextButton.enabled = false;
			}
		}
	}
	bool CheckInventory(string _item)
	{
		
		if (_item == "")
		{
			
			return true;
		}
		else
		{
			try
			{
				if (player.SearchInventory(_item).itemName.ToUpper() == _item.ToUpper())
				{
					
					return true;
				}
				else
				{
					return false;
				}
			}
			catch
			{
				return false;
			}
			
		}
	}
	public void PlayerChoice(int options)
	{
		int newline = Convert.ToInt32(inputStream.Find(currentLines[options])._data.nextDialogue);
		currentLines = new int[1] {newline };
		PrintDialogue();
	}
	public void PortalOpen( )
	{
		if (CheckInventory("Watch"))
		{
			portal.SetActive(true);
		}
		else
		{
			portal.SetActive(false);
		}

	}
	public void closeDialogue( )
	{

		npcGUI.SetActive(false);
		Cursor.visible = false;
		Time.timeScale = 1f;
		Cursor.lockState = CursorLockMode.Locked;

	}
}





