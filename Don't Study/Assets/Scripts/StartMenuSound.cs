using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuSound : MonoBehaviour
{
    public AudioClip HoverFX;
    public AudioSource StartMenuSoundFX;
    public AudioClip PressedFX;

    public void Hover()
    {
        StartMenuSoundFX.PlayOneShot(HoverFX);
    }
    public void Pressed()
    {
        StartMenuSoundFX.PlayOneShot(PressedFX);
        
        
    }
}
