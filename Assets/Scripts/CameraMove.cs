using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float moveSpeed;
    [HideInInspector]
    public Player player;

    private void FixedUpdate()
    {
        if (player != null)
        {
            moveSpeed = 5  * player.move.moveSpeed;
            Vector3 direction = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, direction, moveSpeed * Time.fixedDeltaTime);
        }
    }
}
