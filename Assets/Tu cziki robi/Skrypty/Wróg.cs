using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wróg : MonoBehaviour, DemagableObjects
{
    Transform targetDestination;
    GameObject targetGameObject;
    Gracz targetCharacter;
    [SerializeField] float speed;

    Rigidbody2D rgdbd2d;
    [SerializeField] int hp = 30;
    [SerializeField] int damage = 10;
    [SerializeField] int experience_reward = 400;

    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgdbd2d.velocity = direction * speed;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == targetGameObject)
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
            targetGameObject.GetComponent<Level>().AddExperience(experience_reward);
            Destroy(gameObject);
        }

    }
}
