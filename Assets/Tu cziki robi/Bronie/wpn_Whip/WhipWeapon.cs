using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : MonoBehaviour
{
    [SerializeField] public float timeToAttack = 4f;
    float timer;

    [SerializeField] GameObject leftWhipObject;
    [SerializeField] GameObject rightWhipObject;

    MovementGracza MovementGracza;

    [SerializeField] Vector2 whipAttackSize = new Vector2(4f, 2f);
    [SerializeField] public int whipDamage = 10;

    [SerializeField] AudioSource attackSound; 

    private void Awake()
    {
        MovementGracza = GetComponentInParent<MovementGracza>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
        }
    }

    private void Attack()
    {
        timer = timeToAttack;

        if (MovementGracza.lastHorizontalVector > 0)
        {
            rightWhipObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipObject.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
        else
        {
            leftWhipObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }

        PlayAttackSound(); 
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            DemagableObjects e = colliders[i].GetComponent<DemagableObjects>();
            if (e != null)
            {
                e.TakeDamage(whipDamage);
            }

        }
    }

    private void PlayAttackSound()
    {
        if (attackSound != null)
        {
            attackSound.Play();
        }
    }

    public void Upgrade()
    {
        whipDamage += 2;
        GetComponent<WhipWeapon>().timeToAttack -= timeToAttack * 0.05f;
    }
}
