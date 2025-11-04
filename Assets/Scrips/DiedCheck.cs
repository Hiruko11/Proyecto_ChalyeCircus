using UnityEngine;
using UnityEngine.SceneManagement;

public class DiedCheck : MonoBehaviour
{
    Rigidbody2D playerRb;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathZone"))
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


}
