using System;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake() 
    {
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start() {
        Play("MainTheme");
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0) Destroy(gameObject);
    }

    public void Play (string clipName)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == clipName);
        s.source.Play();
    }
}
