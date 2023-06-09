using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wróg : MonoBehaviour, DemagableObjects
{
    Transform targetDestination;
    GameObject targetGameObject;
    Gracz targetCharacter;
    [SerializeField] float speed;
    [SerializeField] AudioClip deathSound;
    [SerializeField] int hp = 30;
    [SerializeField] int damage = 10;
    [SerializeField] int experience_reward = 400;

    private EnemyKnockback enemyKnockback;
    private Rigidbody2D rb;

    private bool isAttacking = false;

    private void Start()
    {
        enemyKnockback = GetComponent<EnemyKnockback>();
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.fixedDeltaTime);
    }


    private void OnTriggerStay2D(Collider2D collision)

    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartAttacking();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StopAttacking();
        }
    }

    private void StartAttacking()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            StartCoroutine(AttackRoutine());
        }
    }

    private void StopAttacking()
    {
        if (isAttacking)
        {
            isAttacking = false;
            StopCoroutine(AttackRoutine());
        }
    }

    private IEnumerator AttackRoutine()
    {
        while (isAttacking)
        {
            if (targetCharacter == null)
            {
                targetCharacter = targetGameObject.GetComponent<Gracz>();
            }

            targetCharacter.TakeDamage(damage);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        Vector2 knockbackDirection = (transform.position - targetDestination.position).normalized;
        enemyKnockback.ApplyKnockback(knockbackDirection);

        if (hp < 1)
        {
            targetGameObject.GetComponent<Level>().AddExperience(experience_reward);

            if (deathSound != null)
            {
                EnemyDeathSound.Instance.PlayDeathSound(deathSound);
            }
            Destroy(gameObject);
        }
    }

}