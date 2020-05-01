using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{

    public AudioSource myAudioSource;

    void Start()
    {
        myAudioSource.Play();
    }
}
