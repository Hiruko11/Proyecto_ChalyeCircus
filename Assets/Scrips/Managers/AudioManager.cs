using UnityEngine;

public class AudioManager : MonoBehaviour
{
 public static AudioManager Instance {get; private set;}
    [SerializeField] AudioSource MusicSource,SFXSource;
  
    void Awake()
    {
        if(Instance != null )
        {
            Destroy(this.gameObject);  
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void PlayMusic(AudioClip musicClip)

    {
        MusicSource.Stop();
        MusicSource.clip = musicClip;
        MusicSource.Play();
    }
    
    public void Playmusic(AudioClip musicClip)

    {
        MusicSource.PlayOneShot(musicClip);

    }

    public void PlaySFX(AudioClip sfxClip)

    {
        SFXSource.PlayOneShot(sfxClip);

    }


     

    public void Mute()

    {
        MusicSource.mute = true;
        SFXSource.mute = true;

    }

     public void UnMute()

    {
        MusicSource.mute = false;
        SFXSource.mute = false;

    }
}
