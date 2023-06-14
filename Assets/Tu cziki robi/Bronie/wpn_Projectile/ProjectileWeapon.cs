using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    [SerializeField] public float timeToAttack;
    [SerializeField] public int damage1 = 5;
    float timer;

    MovementGracza playerMove;

    [SerializeField] GameObject projectilePrefab;

    [SerializeField] float defaultHorizontalVector = -1f;
    private float lastHorizontalVector;

    [SerializeField] AudioSource spawnSound; 

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
        if (lastHorizontalVector == 0) spawnedProjectile.GetComponent<ProjectileWeaponProjectile>().SetDirection(defaultHorizontalVector, 0f);
        else spawnedProjectile.GetComponent<ProjectileWeaponProjectile>().SetDirection(playerMove.lastHorizontalVector, 0f);
        spawnedProjectile.GetComponent<ProjectileWeaponProjectile>().damage = damage1;

        PlaySpawnSound(); 
    }

    private void PlaySpawnSound()
    {
        if (spawnSound != null)
        {
            spawnSound.Play();
        }
    }

    public void Upgrade()
    {
        damage1 += 2;
        timeToAttack -= timeToAttack * 0.05f;
    }
}
