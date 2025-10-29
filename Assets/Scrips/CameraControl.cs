using System;
using System.Data.Common;
using Unity.Mathematics;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Transform playerTransform;
    public Vector3 offset;


    // Update is called once per frame
    void LateUpdate()
    {
        FollowYPosition();
        if (playerTransform.position.x <= -1)
        {
            Vector3 newPosition = playerTransform.position;
            newPosition.z = transform.position.z;
            newPosition.y = transform.position.y;
            transform.position = newPosition + offset;
        }
    }
    
    void FollowYPosition()
    {
        float camposY = Mathf.Clamp(playerTransform.position.y, 0f, Mathf.Infinity);
        transform.position = new Vector3(transform.position.x, camposY, transform.position.z) + offset;
    }

        

        //{
           // Vector3 newPosition = playerTransform.position;
            //newPosition.z = transform.position.z;
           // transform.position = newPosition + offset;
        //}
    



}  
