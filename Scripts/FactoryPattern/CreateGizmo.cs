using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGizmo : CreateNPC
{
	public override string npcName => "Gizmo";
	public override (GameObject, Transform) npcCreate()
	{
		Creator creator = GameObject.Find("Creator").GetComponent<Creator>();
		return creator.createNPC(npcName);
	}
}
