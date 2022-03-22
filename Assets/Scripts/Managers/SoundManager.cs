using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager sound;

    AudioSource player;

    // Start is called before the first frame update
    void Start()
    {
        sound = this;
        player = GetComponent<AudioSource>();
    }

    public void SetAudioClip(AudioClip clip)
    {
        player.clip = clip;
    }

    public void playClip() { player.Play(); }

}
