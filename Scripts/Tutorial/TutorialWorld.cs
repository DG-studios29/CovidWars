using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FactoryPattern;
using UnityEngine.UI;
using TMPro;


public class TutorialWorld : MonoBehaviour
{
    public HashTable<Items> allItems;
    public InputField InputFieldText;
    
    public TextMeshProUGUI display;
    public HashTable<Npc> allNPCs;
    public HashTable<WorldObject> allObjects;
    public string[] npcNames;
    public tomNPC tutorialNPC;
    private void Awake( )
    {
        createNPCInWorld();
    }
    private void Start( )
    {
        allItems = new HashTable<Items>(10);
        allNPCs = new HashTable<Npc>(10);
        allObjects = new HashTable<WorldObject>(10);
        //GameObject[] gameobjects = GameObject.FindGameObjectsWithTag("item");

        //foreach (GameObject item in gameobjects)
        //{
        //    allItems.Insert(item.GetComponent<Items>().itemName, item.GetComponent<Items>());
        //}

        //GameObject[] gameobjectsNPC = GameObject.FindGameObjectsWithTag("npc");
        //foreach (GameObject npc in gameobjectsNPC)
        //{
        //    allNPCs.Insert(npc.GetComponent<Npc>().nameNPC, npc.GetComponent<Npc>());
        //}

        //foreach (WorldObject item in objects)
        //{
        //    allObjects.Insert(item.objectName, item);
        //}

        tutorialNPC.TriggerDialogue();
    }
    public void inputText( )
    {
        string output = "";
       
        InputFieldText.text = "";
        display.text = output;
    }
    public void deleteGameItem(Items item)
    {
        GameObject[] gameobjects = GameObject.FindGameObjectsWithTag("item");
        foreach (GameObject deleteItem in gameobjects)
        {
            if (deleteItem.GetComponent<Items>() == item)
            {
                Destroy(deleteItem);
            }
        }
    }
    public void createNPCInWorld( )
    {

        foreach (string name in npcNames)
        {
            CreateNPC tempNPC = FactoryPattern.GetNPC(name);
            if (tempNPC != null)
            {
                GameObject npcObject = Instantiate(tempNPC.npcCreate().Item1, tempNPC.npcCreate().Item2);
            }
        }
    }
}


