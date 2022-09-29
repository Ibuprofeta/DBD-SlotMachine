using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class Data : MonoBehaviour
{
    public ListData data = new ListData();

    private void Awake()
    {
        LoadFromJson();
        
    }
    public void SaveIntoJson()
    {
        string dataString = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/Resources/Json/data.json", dataString);
    }

    public void LoadFromJson()
    {
        string jsonString = File.ReadAllText(Application.dataPath + "/Resources/Json/data.json");
        data = JsonUtility.FromJson<ListData>(jsonString);
    }

    public void SaveIntoDebugging(string debug)
    {
        try
        {
            File.WriteAllText(Application.dataPath + "/Resources/Debugging/debug.txt", debug);
        }
        catch (Exception e)
        {
            print("F");
        }
    }
}

[Serializable]
public class ListData
{
    public Killer[] Killers;
    public Survivor[] Survivors;
    public KillerPerk[] KillerPerks;
    public SurvivorPerk[] SurvivorPerks;
    
}
[Serializable]
public class Killer
{
    public string name;
    public string image;
    public bool active;
    public string id;
    public PerkID[] Perks;
}

[Serializable]
public class Survivor
{
    public string name;
    public string image;
    public bool active;
    public string id;
    public PerkID[] Perks;
}

[Serializable]
public class KillerPerk
{
    public string name;
    public string image;
    public string description;
    public string id;
}

[Serializable]
public class SurvivorPerk
{
    public string name;
    public string image;
    public string description;
    public string id;
}

[Serializable]
public class PerkID
{
    public string id;
    public bool active;
}