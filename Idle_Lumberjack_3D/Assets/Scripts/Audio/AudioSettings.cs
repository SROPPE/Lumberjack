using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    public void OnChangeMainVolume(float value)
    {
        mixer.SetFloat("MainVolume", value);
    }
}
