using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gracz : MonoBehaviour
{
    public int maxHP = 1000;
    public int currentHP = 1000;
    [SerializeField] StatusBar hpBar;

    [SerializeField] public Level level;

    private Rigidbody2D rb;
    [SerializeField] private float speed = 5f; // Adjust the speed factor as needed

    private void Awake()
    {
        level = GetComponent<Level>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        hpBar.SetState(currentHP, maxHP);
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Debug.Log("Player died. Game over!");
        }
        hpBar.SetState(currentHP, maxHP);
    }

    public void Heal(int amount)
    {
        if (currentHP <= 0)
            return;

        currentHP += amount;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }

        hpBar.SetState(currentHP, maxHP);
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * speed; // Apply speed factor to the movement vector
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 reflection = Vector2.Reflect(rb.velocity, collision.contacts[0].normal);
            rb.velocity = reflection;
        }
    }
}
