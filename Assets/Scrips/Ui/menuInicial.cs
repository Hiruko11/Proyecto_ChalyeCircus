using UnityEngine;

public class menuInicial : MonoBehaviour
{    
       public void StartGame(string levelName)
    {
     GameManager.Instance.ChangeScene(levelName);
    }
}

