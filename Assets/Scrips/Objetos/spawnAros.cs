using UnityEngine;

public class spawnAros : MonoBehaviour
{
    public GameObject objetoPrefab;
    public float TiempoSpawn = 4f;
    


    void Update()
    {
     
        {
            if (Time.time >= TiempoSpawn)
            {
                TiempoSpawn = Time.time + 4f;
            
            Instantiate(objetoPrefab, transform.position, Quaternion.identity);
            }

           
          
        }
    }
}
