using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSound : MonoBehaviour
{

    [SerializeField]
    private AudioClip[] walk;
    private AudioSource walkSource;
    [SerializeField]
    private AudioClip[] jump;
    private AudioSource jumpSource;
    [SerializeField]
    private AudioClip[] kick;
    private AudioSource kickSource;
    [SerializeField]
    private AudioClip[] pickupPowerUp;
    private AudioSource pickupPowerUpSource;
    [SerializeField]
    private AudioClip[] dropPowerUp;
    private AudioSource dropPowerUpSource;

    private float baseVolume = .3f;

    void Awake()
    {
        walkSource = gameObject.AddComponent<AudioSource>();
        walkSource.volume = baseVolume;
        jumpSource = gameObject.AddComponent<AudioSource>();
        jumpSource.volume = baseVolume;
        kickSource = gameObject.AddComponent<AudioSource>();
        kickSource.volume = baseVolume;
        pickupPowerUpSource = gameObject.AddComponent<AudioSource>();
        pickupPowerUpSource.volume = baseVolume;
        dropPowerUpSource = gameObject.AddComponent<AudioSource>();
        dropPowerUpSource.volume = baseVolume;
    }

    public void PlayWalk()
    {
        PlaySound(walk, walkSource);
    }

    public void PlayJump()
    {
        PlaySound(jump, jumpSource);
    }

    public void PlayPickupPowerUp()
    {
        PlaySound(pickupPowerUp, pickupPowerUpSource);
    }

    public void PlayDropPowerUp()
    {
        PlaySound(dropPowerUp, dropPowerUpSource);
    }

    public void PlayKick()
    {
        PlaySound(kick, kickSource);
    }

    void PlaySound(AudioClip[] clips, AudioSource source) {
        source.clip = clips[Random.Range(0, clips.Length)];
        source.Play();
    }

}
