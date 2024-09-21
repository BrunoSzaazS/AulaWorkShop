using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Status
{
    public int Healt;
    public int Armor;
    public int MagicResist;
    public void Init()
    {
        Healt = 100;
        Armor = 20;
        MagicResist = 20;
    }
}
