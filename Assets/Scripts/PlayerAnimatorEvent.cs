using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorEvent : MonoBehaviour
{
    [SerializeField] private PlayerAudioController audioController;

    public ParticleSystem dust;

    public void CreateDust()
    {
        dust.Play();
    }

    public void PlayWalkSound()
    {
        audioController.PlayWalkSound();
        CreateDust();
    }

}
