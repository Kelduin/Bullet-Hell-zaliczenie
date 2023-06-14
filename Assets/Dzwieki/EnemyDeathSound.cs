using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathSound : MonoBehaviour
{
    public static EnemyDeathSound Instance { get; private set; }

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayDeathSound(AudioClip deathSound)
    {
        if (deathSound != null)
        {
            audioSource.clip = deathSound;
            audioSource.Play();
        }
    }
}

