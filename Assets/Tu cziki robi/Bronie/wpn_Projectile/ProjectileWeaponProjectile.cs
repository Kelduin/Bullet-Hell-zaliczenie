using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponProjectile : MonoBehaviour
{

    Vector3 direction;
    [SerializeField] float speed;
    [SerializeField] public int damage = 5;
    [SerializeField] float lifeTime;


    

    public void SetDirection(float dir_x, float dir_y)
    {
        direction = new Vector3 (dir_x, dir_y);

        if (dir_x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }
    }


    bool hitDetected = false;
    
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (Time.frameCount % 6 == 0 ) 
        {
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.1f);
            foreach (Collider2D c in hit)
            {
                Wróg wróg = c.GetComponent<Wróg>();
                if (wróg != null)
                {

                    wróg.TakeDamage(damage);
                    hitDetected = true;
                    break;
                }
            }
            if (hitDetected == true)
            {
                Destroy(gameObject);
            }
        }

        
    }
    
}
