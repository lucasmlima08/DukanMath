using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Audio : MonoBehaviour
{
    public GameObject musicBackground;

    public void playSoundEffect()
    {
        AudioSource audioSource = musicBackground.GetComponent<AudioSource>();
        audioSource.Play();
    }
}
