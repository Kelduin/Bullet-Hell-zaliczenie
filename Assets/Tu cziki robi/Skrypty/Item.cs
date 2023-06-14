using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;
    public int armor;

    public void Equip(Gracz gracz)
    {
        gracz.armor += armor;
    }

    public void UnEquip(Gracz gracz)
    {
        gracz.armor -= armor;
    }
}
