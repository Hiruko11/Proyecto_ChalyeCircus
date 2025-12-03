using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set;}


    [SerializeField] bool isPaused;
    void Awake()
    {
       if(Instance !=null)
        {
            Destroy(this.gameObject);
        } 
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
     
     public void ChangeScene(string nameNewScene)
    {
        SceneManager.LoadScene(nameNewScene);

    }

    public void PausedGame()
    {
    isPaused = !isPaused;
    if(isPaused)
        {
            Time.timeScale = 0 ;
            if(AudioManager.Instance != null)
            {
                AudioManager.Instance.Mute();
            }

        }
        else
        {
            Time.timeScale = 1 ;

            if(AudioManager.Instance != null)
            {
                AudioManager.Instance.UnMute();
            }
        }
    }
}
