using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeOnLevel3 : MonoBehaviour
{
    [SerializeField] GameObject whipWeapon;
    private Level levelScript;

    private void Update()
    {
        levelScript = GetComponent<Level>(); // Assuming Level script is attached to the same GameObject
        CheckLevelAndEnableWeapon();
    }

    private void CheckLevelAndEnableWeapon()
    {
        if (levelScript != null && levelScript.level >= 3)
        {
            whipWeapon.GetComponent<WhipWeapon>().whipDamage = 20;
            whipWeapon.GetComponent<WhipWeapon>().timeToAttack = 2f;
            this.enabled = false;
        }
    }
}
