using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnableOnLevel2 : MonoBehaviour
{
    [SerializeField] GameObject projectileWeapon;
    private Level levelScript;

    private void Update()
    {
        levelScript = GetComponent<Level>(); // Assuming Level script is attached to the same GameObject
        CheckLevelAndEnableWeapon();
    }

    private void CheckLevelAndEnableWeapon()
    {
        if (levelScript != null && levelScript.level >= 2)
        {
            projectileWeapon.SetActive(true);
            this.enabled = false;
        }
    }
}
