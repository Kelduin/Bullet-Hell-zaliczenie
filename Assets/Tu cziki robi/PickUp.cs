using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
 


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Gracz c = collision.GetComponent<Gracz>();
        if (c != null )
        {
            GetComponent<PickUpObject>().OnPickUp(c);
            Destroy(gameObject);
        }
    }
}
