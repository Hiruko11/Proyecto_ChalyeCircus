using UnityEngine;

public class pasoDeNivel : MonoBehaviour
{
  public void OnTriggerEnter2D(Collider2D collision) 
    {
     if(collision.CompareTag("Player"))
     {
        GameManager.Instance.ChangeScene("nivel2");
     }
    }
}
