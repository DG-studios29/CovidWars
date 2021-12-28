using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMeeta : CreateNPC
{
	public override string npcName => "Meeta";
	public override (GameObject, Transform) npcCreate( )
	{
		Creator creator = GameObject.Find("Creator").GetComponent<Creator>();
		return creator.createNPC(npcName);
	}
}
