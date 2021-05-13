using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource[] sounds;
    private AudioSource cursorMove;

    private int iterator;

    // Start is called before the first frame update
    void Start()
    {
        iterator = -1;

        sounds = GetComponents<AudioSource>();

        cursorMove = AddSound();
    }

    private AudioSource AddSound()
    {
        iterator++;
        return sounds[iterator];
    }

    public void PlayCursorMove()
    {
        cursorMove.Play();
    }
}
