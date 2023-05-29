using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour, DemagableObjects
{
    public void TakeDamage(int damage)
    {
        Destroy(gameObject);
    }
}
