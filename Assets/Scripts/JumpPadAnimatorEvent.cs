using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadAnimatorEvent : MonoBehaviour
{
    [SerializeField] private JumpPad jumpPad;

    public void PlayJumpPad()
    {
        jumpPad.PlayJumpPadSound();
    }

}
