using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsButtons : MonoBehaviour
{
    public new AudioSource audio;
    public AudioClip hoverSound;
    public AudioClip clickSound;

    public void HoverSound()
    {
        audio.PlayOneShot(hoverSound);
    }

    public void ClickSound()
    {
        audio.PlayOneShot(clickSound);
    }
}
