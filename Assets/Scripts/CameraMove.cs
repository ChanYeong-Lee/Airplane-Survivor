using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float moveSpeed;
    [HideInInspector]
    public Transform player;

    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 direction = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, direction, moveSpeed * Time.fixedDeltaTime);
        }
    }
}
