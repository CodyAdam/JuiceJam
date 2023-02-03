using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxRandomPitch : MonoBehaviour
{
    private AudioSource audioSource;

    public float minPitch = 0.9f;
    public float maxPitch = 1.1f;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        ChangePitch();
    }

    public void ChangePitch()
    {
        audioSource.pitch = Random.Range(minPitch, maxPitch);
    }
}
