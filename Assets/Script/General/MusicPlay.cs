using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlay : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    public bool isPlayOnEnable;
    private void OnEnable()
    {
        if(isPlayOnEnable)
            PlayMusic();
    }
    public void PlayMusic()
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
    public void StopMusic()
    {
        if (audioSource.clip != null)
        {
            audioSource.Stop();
        }
            
    }
}
