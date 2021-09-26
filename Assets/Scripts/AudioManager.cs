using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    public Sound[] sounds;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
        
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.reverbZoneMix = 0f;
        }
    }

    public AudioSource Clip(string name)
    {
        Sound s = Array.Find<Sound>(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.Log("Sound " + name + " was not found");
            return null;
        }
        else
            return s.source;
    }
}
