using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    [SerializeField] float timeToAttack;
    float timer;

    MovementGracza playerMove;

    [SerializeField] GameObject projectilePrefab;

    private void Awake()
    {
        playerMove = GetComponentInParent<MovementGracza>();
    }



    private void Update()
    {
        if (timer < timeToAttack)
        {
            timer += Time.deltaTime;
            return;
        }

        timer = 0;
        SpawnProjectile();
    }

    private void SpawnProjectile()
    {
        GameObject spawnedProjectile = Instantiate(projectilePrefab);
        spawnedProjectile.transform.position = transform.position;
        spawnedProjectile.GetComponent<ProjectileWeaponProjectile>().SetDirection(playerMove.lastHorizontalVector, 0f);

    }
}
