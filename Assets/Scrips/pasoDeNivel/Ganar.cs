using UnityEngine;

public class Ganar : MonoBehaviour
{
  public void OnTriggerEnter2D(Collider2D collision) 
    {
     if(collision.CompareTag("Player"))
     {
        GameManager.Instance.ChangeScene("Ganar");
     }
    }
}
