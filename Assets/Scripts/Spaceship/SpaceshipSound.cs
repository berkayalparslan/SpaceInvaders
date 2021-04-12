using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipSound : MonoBehaviour
{
    private AudioSource _spaceshipAudio;
    //[SerializeField]
    //private AudioClip _movementSound;
    [SerializeField]
    private AudioClip _shootingSound;
    [SerializeField]
    private AudioClip _explosionSound;

    //public void PlayMovementSound()
    //{
    //    PlayClip(_movementSound);
    //}

    public void PlayShootingSound()
    {
        PlayClip(_shootingSound);
    }

    public void PlayExplosionSound()
    {
        PlayClip(_explosionSound);
    }

    private void Awake()
    {
        _spaceshipAudio = GetComponent<AudioSource>();
    }

    private void PlayClip(AudioClip audioClip)
    {
        if (!_spaceshipAudio.isPlaying)
        {
            _spaceshipAudio.clip = audioClip;
            _spaceshipAudio.Play();
        }
        
    }
}
