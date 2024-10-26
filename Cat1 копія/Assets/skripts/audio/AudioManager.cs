using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] soundAudio;

    private AudioSource audioSource => GetComponent<AudioSource>();

    public void PlaySoynd(AudioClip clip , float volume  = 1f , bool destrouded = false , float p1 = 1f)
    {
        audioSource.PlayOneShot(clip,volume);

        if (destrouded)
        {
            AudioSource.PlayClipAtPoint(clip, transform.position, volume);
        }
        else
        {
            audioSource.PlayOneShot(clip , volume);
        }
    }
}
