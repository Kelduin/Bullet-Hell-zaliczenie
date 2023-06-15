using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    public float knockbackForce = 5f;
    public float knockbackDuration = 0.5f;
    private Rigidbody2D rb;
    private bool isKnockbackActive = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ApplyKnockback(Vector2 knockbackDirection)
    {
        if (!isKnockbackActive)
        {
            rb.velocity = Vector2.zero; // Stop the current velocity
            rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            StartCoroutine(KnockbackCooldown());
        }
    }

    private IEnumerator KnockbackCooldown()
    {
        isKnockbackActive = true;
        yield return new WaitForSeconds(knockbackDuration);
        rb.velocity = Vector2.zero; // Stop the knockback force
        isKnockbackActive = false;
    }
}
