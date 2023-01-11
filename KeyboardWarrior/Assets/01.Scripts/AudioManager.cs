using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager Instance = null;

    private void Awake() {
        
        if (Instance == null)
            Instance = this;
    }
    
    [SerializeField] private List<AudioClip> clips = new List<AudioClip>();

    public void PlayAudio(int index, AudioSource player)
    {

        player.clip = clips[index];

        player.Play();
    }

}