using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private LightUp LightUpManager;

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            LightUpManager = GameObject.Find("GameManager").GetComponent<LightUp>();
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = LightUpManager.volume;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (name != "lowThreeTone")
            s.source.volume = LightUpManager.volume;
        else
        {
            if (LightUpManager.volume > 0)
                s.source.volume = LightUpManager.volume + 2;
        }            
        s.source.Play();
    }
}