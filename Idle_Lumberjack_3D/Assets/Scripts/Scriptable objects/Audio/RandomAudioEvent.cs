using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomAudioEvent", menuName = "AudioEvent/Create RandomAudioEvent")]
public class RandomAudioEvent : AudioEvent
{
    [SerializeField] List<AudioClip> audioClips;
    public override void Play(AudioSource audioSource)
    {
        var audioClipIndex = Random.Range(0, audioClips.Count);
        audioSource.clip = audioClips[audioClipIndex];
        audioSource.Play();
    }
}
