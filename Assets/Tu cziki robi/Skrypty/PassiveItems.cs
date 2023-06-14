using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItems : MonoBehaviour
{
    [SerializeField] List<Item> items;

    Gracz gracz;

    [SerializeField] Item armorTest;

    private void Awake()
    {
        gracz = GetComponent<Gracz>();
    }

    private void Start()
    {
        Equip(armorTest);
    }

    public void Equip(Item itemToEquip)
    {
        if(items == null)
        {
            items = new List<Item>();
        }
        items.Add(itemToEquip);
        itemToEquip.Equip(gracz);
    }

    public void UnEquip(Item itemToUnEquip)
    {
        
    }
}
