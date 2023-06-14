using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int level = 1;
    int experience = 0;
    [SerializeField] ExperienceBar experienceBar;
    [SerializeField] GameObject projectileWeapon;
    [SerializeField] GameObject whipWeapon;
    [SerializeField] GameObject enemySpawner;

    [SerializeField] AudioSource levelUpSound; 

    int TO_LEVEL_UP
    {
        get
        {
            return level * 1000;
        }
    }

    private void Start()
    {
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        experienceBar.SetLevelText(level);
    }


    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }

    public void CheckLevelUp()
    {
        if (experience >= TO_LEVEL_UP)
        {
            experience -= TO_LEVEL_UP;
            level += 1;
            experienceBar.SetLevelText(level);
            whipWeapon.GetComponent<WhipWeapon>().Upgrade();
            enemySpawner.GetComponent<EnemiesMenager>().Upgrade();
            projectileWeapon.GetComponent<ProjectileWeapon>().Upgrade();

            if (level >= 2)
            {
                projectileWeapon.SetActive(true);
            }

            PlayLevelUpSound();
        }
    }

    private void PlayLevelUpSound()
    {
        if (levelUpSound != null)
        {
            levelUpSound.Play();
        }
    }
}
