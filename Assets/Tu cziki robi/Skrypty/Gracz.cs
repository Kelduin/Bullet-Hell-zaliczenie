using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gracz : MonoBehaviour
{
    public int maxHP = 1000;
    public int currentHP = 1000;

    public int armor = 0;

    [SerializeField] StatusBar hpBar;

    [SerializeField] public Level level;

    private Rigidbody2D rb;
    [SerializeField] private float speed = 5f; 

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
        ApplyArmor(ref damage);


        currentHP -= damage;

        if (currentHP <= 0)
        {
            SceneManager.LoadScene("Death");
        }
        hpBar.SetState(currentHP, maxHP);
    }

    private void ApplyArmor(ref int damage)
    {
        damage -= armor;
        if (damage < 0) { damage = 0;} 
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
        rb.velocity = movement * speed; 
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
