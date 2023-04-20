using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacja : MonoBehaviour
{

    Animator animator;
    public float horizontal;


    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        animator.SetFloat("Horizontal", horizontal); //ustawia float dla animatora
    }
}