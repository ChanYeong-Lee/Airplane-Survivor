using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public Player player;
    public float rotatingSpeed = 1;
    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        if (player.isMoving)
        {
            if (player.move.state == PlayerMove.State.forward) 
            { 
                transform.Rotate(new Vector3(0, 0, -x / 3 * rotatingSpeed));
            }
            else 
            { 
                transform.Rotate(new Vector3(0, 0, x / 3 * rotatingSpeed));
            }
        }
    }
}
