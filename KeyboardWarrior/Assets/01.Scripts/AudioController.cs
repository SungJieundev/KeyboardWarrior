using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public string group;
    public Slider slider;

    public void AudioControl(){
        float volume = slider.value;

        if(volume == -40f){
            audioMixer.SetFloat(group, -80);
        }
            audioMixer.SetFloat(group, volume);
    }
}
