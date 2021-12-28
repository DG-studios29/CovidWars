using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEric : CreateNPC
{
	public override string npcName => "Eric";
	public override (GameObject, Transform) npcCreate( )
	{
		Creator creator = GameObject.Find("Creator").GetComponent<Creator>();
		return creator.createNPC(npcName);
	}
}
