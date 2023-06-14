using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSound;

    private void Start()
    {
        
        button.onClick.AddListener(PlayClickSound);
    }

    private void PlayClickSound()
    {
        
        audioSource.PlayOneShot(clickSound);
    }
}
