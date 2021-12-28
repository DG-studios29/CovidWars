using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CreateNPC 
{
   	public abstract string npcName { get; }

    public abstract (GameObject, Transform) npcCreate();
}
