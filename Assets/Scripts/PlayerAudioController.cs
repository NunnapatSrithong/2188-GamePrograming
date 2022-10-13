using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SoAudioClip walkAudioClips;
    [SerializeField] private SoAudioClip jumpAudioClips;
    [SerializeField] private SoAudioClip fallAudioClips;
    [SerializeField] private SoAudioClip GetItemSound;

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpAudioClips.GetAudioClip());
    }

    public void PlayWalkSound()
    {
        audioSource.PlayOneShot(walkAudioClips.GetAudioClip());
    }
    public void PlayFallSound()
    {
        audioSource.PlayOneShot(fallAudioClips.GetAudioClip());
    }

    public void PlayGetItemSound()
    {
        audioSource.PlayOneShot(GetItemSound.GetAudioClip());
    }

}
