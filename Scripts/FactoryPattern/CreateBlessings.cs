using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlessings : CreateNPC
{
	public override string npcName => "Blessings";
	public override (GameObject, Transform) npcCreate( )
	{
		Creator creator = GameObject.Find("Creator").GetComponent<Creator>();
		return creator.createNPC(npcName);
	}
}
