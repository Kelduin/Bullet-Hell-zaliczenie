using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] AudioSource pickupSound; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Gracz c = collision.GetComponent<Gracz>();
        if (c != null)
        {
            GetComponent<PickUpObject>().OnPickUp(c);
            PlayPickupSound(); 
            Destroy(gameObject);
        }
    }

    private void PlayPickupSound()
    {
        if (pickupSound != null)
        {
            pickupSound.Play();
        }
    }
}
