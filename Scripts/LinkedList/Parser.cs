using System.Collections.Generic;
using UnityEngine;

public class Parser
{
	delegate string ParseCommand(string[] parameters);
	public static string display;
	HashTable<ParseCommand> commands = new HashTable<ParseCommand>(20);

	PlayerController playerControl;
	WorldController worldControl;

	public Parser(PlayerController pController, WorldController wController)
	{
		AddCommands();
		worldControl = wController;
		playerControl = pController;
	}

	public void AddCommands( )
	{
		commands.Insert("look", Look);
		commands.Insert("Look", Look);

		commands.Insert("use", Use);
		commands.Insert("Use", Use);

		commands.Insert("pick", PickUp);
		commands.Insert("Pick", PickUp);
		commands.Insert("Pickup", PickUp);
		commands.Insert("pickup", PickUp);

		commands.Insert("walk", Walk);
		commands.Insert("Walk", Walk);

		commands.Insert("talk", Talk);
		commands.Insert("Talk", Talk);

	}

	public string Parse(string _input)
	{
		string[] words = GetWords(_input);

		ParseCommand controller;
		try
		{
			controller = commands.Search(words[0]);
			return controller(words);
		}
		catch
		{
			return "The act you tried did not work.";
		}
	}

	string[] GetWords(string s)
	{
		s = s.Trim().ToLower();
		return s.Split(' ');
	}

	string Look(string[] words)
	{
		string output = "";

		for (int i = 1; i < words.Length; i++)
		{
			Items tempAll = worldControl.allItems.Search(words[i]);
			Items tempInventory = playerControl.SearchInventory(words[i]);


			if (tempAll != null)
			{
				output = tempAll.discr;
				i = words.Length;
			}
			else if (tempInventory != null)
			{
				output = tempInventory.discr;
				i = words.Length;
			}

		}

		if (output == "")
		{
			output = "Could not find that item";
		}

		return output;
	}

	string PickUp(string[] words)
	{
		string output = "";
		List<Items> itemsPickedUp = new List<Items>();
		List<Items> itemsInventory = new List<Items>();


		for (int i = 1; i < words.Length; i++)
		{
			Items tempI = worldControl.allItems.Search(words[i]);
			Items tempInv = playerControl.SearchInventory(words[i]);

			if (tempI != null /*&& tempI.gameObject.activeSelf*/)
			{
				itemsPickedUp.Add(tempI);
			}
			else if (tempInv != null)
			{
				itemsInventory.Add(tempInv);
			}

		}

		if (itemsPickedUp.Count > 0)
		{


			output = "You picked up the ";

			for (int i = 0; i < itemsPickedUp.Count; i++)
			{

				Items temp = itemsPickedUp[i];
				output += itemsPickedUp[i].itemName;
				playerControl.addToInventory(temp);
				worldControl.deleteGameItem(itemsPickedUp[i]);
				worldControl.allItems.Remove(itemsPickedUp[i].itemName);

				if (i + 1 < itemsPickedUp.Count)
				{
					output += " and ";
				}
			}
		}
		else if (itemsInventory.Count > 0)
		{
			output = "You already have the item ";

			for (int i = 0; i < itemsInventory.Count; i++)
			{
				output += itemsInventory[i].itemName;

				if (i + 1 < itemsInventory.Count)
				{
					output += " and ";
				}
			}

			output += " in your Inventory.";
		}
		else
		{
			output = "You couldn't find that.";
		}

		return output;
	}

	string Use(string[] words)
	{
		string output = "";
		List<Items> useItems = new List<Items>();
		Items useItemObject = null;
		Items tempInventory = playerControl.SearchInventory(words[1]);
		useItems.Add(tempInventory);

		for (int i = 0; i < words.Length; i++)
		{

			Items tempO = playerControl.SearchInventory(words[i]);

			useItemObject = tempO;

		}

		if (useItems.Count == useItemObject.itemsNeeded.Length)
		{
			int itemsNeededAmount = 0;
			List<Items> itemsUsed = new List<Items>();

			for (int i = 0; i < useItemObject.itemsNeeded.Length; i++)
			{
				for (int j = 0; j < useItems.Count; j++)
				{

					if (useItems[j].itemName == useItemObject.itemsNeeded[i].itemName)
					{
						itemsUsed.Add(useItems[j]);
						itemsNeededAmount++;
					}
				}
			}

			if (itemsNeededAmount == useItemObject.itemsNeeded.Length)
			{
				output = useItemObject.taskComplete;
				worldControl.deleteGameItem(useItemObject);

				foreach (Items i in itemsUsed)
				{
					playerControl.deleteFromInventory(i);
				}
			}
			else
			{
				output = "You tried to use the item on the " + useItemObject.itemName + " but nothing seems to happen.";
			}
		}
		else if (useItemObject != null && useItems.Count != useItemObject.itemsNeeded.Length && useItems.Count > 0)
		{
			output = "You tried using the items but it doesn't seem right please try something else.";
		}
		else if (useItems.Count == 1)
		{
			output = "You don't seem to know what to use the ";
			output += useItems[0].itemName;
			output += " on.";
		}
		else if (useItems.Count > 1)
		{
			output = "Those items don't seem to do together.";
		}
		else
		{
			output = "You can't find anything to use.";
		}

		return output;
	}
	string Walk(string[] words)
	{
		string output = "";
		for (int i = 1; i < words.Length; i++)
		{
			Items tempI = worldControl.allItems.Search(words[i]);
			WorldObject tempObject = worldControl.allObjects.Search(words[i]);


			if (tempI != null)
			{
				output = "You walk over to the " + tempI.itemName.ToLower();
				playerControl.walkToItems = new List<Items>() { tempI };
				playerControl.WalkToItem();
				
				i = words.Length;
			}
			
			if(tempObject != null)
			{
				output = "You walk over to the " + tempObject.objectName.ToLower();
				playerControl.WalkToPotal();
			}
		}

		if (output == "")
		{
			output = "Could not find that";
		}

		return output;
	}

	string Talk(string[] words)
	{
		string output = "";

		for (int i = 1; i < words.Length; i++)
		{
			Npc tempNPC = worldControl.allNPCs.Search(words[i]);

			if (tempNPC != null)
			{
				output = "You walk over and talk to " + tempNPC.nameNPC;
				playerControl.WalkToNPC(tempNPC);
				i = words.Length;
			}
		}

		if (output == "")
		{
			output = "Could not find that person";
		}

		return output;
	}
}
