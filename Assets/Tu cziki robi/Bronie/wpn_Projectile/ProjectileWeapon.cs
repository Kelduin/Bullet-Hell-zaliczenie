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

    [SerializeField] float defaultHorizontalVector = -1f;
    private float lastHorizontalVector;

    private void Awake()
    {
        playerMove = GetComponentInParent<MovementGracza>();
    }



    private void Update()
    {
        lastHorizontalVector = playerMove.lastHorizontalVector;
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
        if(lastHorizontalVector == 0) spawnedProjectile.GetComponent<ProjectileWeaponProjectile>().SetDirection(defaultHorizontalVector, 0f);
        else spawnedProjectile.GetComponent<ProjectileWeaponProjectile>().SetDirection(playerMove.lastHorizontalVector, 0f);

    }
}
