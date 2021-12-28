using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;
using System;

public static class FactoryPattern 
{

    private static Dictionary<string, Type> NPCByName;
    private static bool IsInitialised => NPCByName != null;

    public static void InitialiseFactory( )
    {
        if (IsInitialised)
            return;

        var NPCTypes = Assembly.GetAssembly(typeof(CreateNPC)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(CreateNPC)));

        NPCByName = new Dictionary<string, Type>();

        foreach (var type in NPCTypes)
        {
            var tempNPC = Activator.CreateInstance(type) as CreateNPC;
            NPCByName.Add(tempNPC.npcName, type);
        }
    }

    public static CreateNPC GetNPC(string NPCType)
    {
        InitialiseFactory();

        if (NPCByName.ContainsKey(NPCType))
        {
            Type type = NPCByName[NPCType];
            var npc = Activator.CreateInstance(type) as CreateNPC;
            return npc;
        }

        return null;
    }

    internal static IEnumerable<string> GetNPCNames( )
    {
        InitialiseFactory();
        return NPCByName.Keys;
    }
}

