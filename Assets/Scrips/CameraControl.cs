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
        if (playerTransform.position.x > 0.5f)
        {
            FollowXPosition();
        }
    }

    void FollowXPosition()
        {
            Vector3 newPosition = playerTransform.position;
            newPosition.z = transform.position.z;
            newPosition.y = transform.position.y;
            transform.position = newPosition + offset;
            
        }
    
    void FollowYPosition()
    {
        float camPosY = Mathf.Clamp(playerTransform.position.y, 0, Mathf.Infinity);
        transform.position = new Vector3(transform.position.x, camPosY, transform.position.z) + offset;
    }

        

        //{
           // Vector3 newPosition = playerTransform.position;
            //newPosition.z = transform.position.z;
           // transform.position = newPosition + offset;
        //}
    



}  
