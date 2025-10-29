using UnityEngine;

public class DiedCheck : MonoBehaviour
{
    Rigidbody2D playerRb;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void OCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            Debug.Log("Has muerto");
            playerRb.linearVelocity = Vector2.zero;
            transform.position = new Vector3(-7.5f, 1.5f, 0f);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }


}
