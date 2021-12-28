using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue 
{
    public int dialogueID;
    public string dialoguePlayer;
    public string dialogueNPC;
    public string getItem;
    public string nextDialogue;
   

    public Dialogue(int _dialogueID, string _dialoguePlayer, string _dialogueNPC, string _getItem, string _nextDialogue)
	{
        dialogueID = _dialogueID;
        dialoguePlayer = _dialoguePlayer;
        dialogueNPC = _dialogueNPC;
        getItem = _getItem;
        nextDialogue = _nextDialogue;
       
    }

}
 