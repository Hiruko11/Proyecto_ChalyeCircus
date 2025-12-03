using UnityEngine;

public class musica : MonoBehaviour
{
     public AudioClip musicGame;
    
     void Start ()
     {
      AudioManager.Instance.PlayMusic(musicGame);
     } 
}
