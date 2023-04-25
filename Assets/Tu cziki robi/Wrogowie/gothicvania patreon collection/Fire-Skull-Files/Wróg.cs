using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wr�g : MonoBehaviour
{
    [SerializeField] Transform targetDestination;
    GameObject targetGameObject;
    Gracz targetCharacter;
    [SerializeField] float speed;

    Rigidbody2D rgdbd2d;
    [SerializeField] int hp = 30;
    [SerializeField] int damage = 1;

    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
        targetGameObject = targetDestination.gameObject;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgdbd2d.velocity = direction * speed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
       if(targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<Gracz>();
        }

       targetCharacter.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp < 1)
        {
            Destroy(gameObject);
        }

    }
}
