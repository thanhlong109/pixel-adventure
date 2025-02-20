using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public Sound[] sounds;

    public AudioSource bgSource;
    public AudioSource sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
        DontDestroyOnLoad(Instance);
    }

    public void PlayerMusic(string name)
    {
        var music = sounds.FirstOrDefault(s => s.Name.Equals(name));
        if (music != null)
        {
            bgSource.clip = music.clip;
            bgSource.Play();
        }
    }

    public void PlayerSFX(string name)
    {
        var music = sounds.FirstOrDefault(s => s.Name.Equals(name));
        if (music != null)
        {
            sfxSource.PlayOneShot(music.clip);
        }
    }
}
