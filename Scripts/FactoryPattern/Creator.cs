using UnityEngine;

public class Creator : MonoBehaviour
{
	public GameObject[] npc;
	public Transform[] npcTransform;
	public (GameObject, Transform) createNPC(string name)
	{
		for (int i = 0; i < npc.Length; i++)
		{
			if (npc[i].GetComponent<Npc>().nameNPC.ToUpper() == name.ToUpper())
			{
				return (npc[i], npcTransform[i]);
			}
		}
		return (null, null);
	}

}
