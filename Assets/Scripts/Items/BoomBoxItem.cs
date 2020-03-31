using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item that when used changes to the next song, when out of songs turns off, when used while off, plays first song.
/// 
/// TODO; It should auto play, randomise order potentially and go to next track when used.
///     In other words, act kind of like the radio in a GTA style game.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class BoomBoxItem : InteractiveItem
{
    protected AudioSource audioSource;
    [SerializeField] AudioClip[] clips;

    int song = 0;
    bool IsUsed = false;

    protected override void Start()
    {
        base.Start();
        audioSource = GetComponent <AudioSource>();
        audioSource.clip = clips[0];
    }

    public void PlayClip()
    {
        audioSource.clip = clips[song];
        audioSource.Play(); 
    }

    void Update()
    {
        if(!audioSource.isPlaying && IsUsed)
        {
           song++;

           if(song > clips.Length - 1)
            song = 0;

            PlayClip();
        }
    }

    public override void OnUse()
    {
        base.OnUse();
        IsUsed = true;

        if(song < clips.Length - 1)
        {
            song++;
            PlayClip();
        }
        else
        {
            audioSource.Stop();
            song = 0;
            IsUsed = false;
        }
    }
}
