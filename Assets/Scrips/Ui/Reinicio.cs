using UnityEngine;

public class Reinicio : MonoBehaviour
{
       public void ReinicioGame(string levelName)
    {
     GameManager.Instance.ChangeScene(levelName);
    }
}
