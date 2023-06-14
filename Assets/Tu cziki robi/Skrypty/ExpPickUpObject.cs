using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPickUpObject : MonoBehaviour, PickUpObject
{

    [SerializeField] int expAmount;

    public void OnPickUp(Gracz gracz)
    {
        gracz.level.AddExperience(expAmount);
    }
}
