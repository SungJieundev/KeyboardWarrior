using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance = null;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<AudioManager>();

            return instance;
        }
    }

    
    [SerializeField] private Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();

    [SerializeField] AudioSource bgmPlayer = null;
    [SerializeField] AudioSource systemPlayer = null;


    public void PlayBGM(string clipName) => PlayAudio(clipName, bgmPlayer);
    public void PauseBGM() => bgmPlayer.Pause();
    public void PlaySystem(string clipName) => PlayAudio(clipName, systemPlayer);
    public void PauseSystem() => systemPlayer.Pause();

    public void PlayAudio(string clipName, AudioSource player)
    {
        if (!clips.ContainsKey(clipName))
        {
            Debug.LogWarning("오디오클립에 존재하지 않는 이름");
            return;
        }

        player.clip = clips[clipName];

        player.Play();
    }

}