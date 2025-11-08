using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioSource : MonoBehaviour
{
    [Header("Songs")]
    AudioSource audioSourcet;
    public AudioClip songToPlay;
    // Start is called before the first frame update
    void Start()
    {
        audioSourcet = GetComponent<AudioSource>();

        audioSourcet = GetComponent<AudioSource>();

        audioSourcet.clip = songToPlay;
        audioSourcet.loop = true;
        audioSourcet.Play();
    }
}
