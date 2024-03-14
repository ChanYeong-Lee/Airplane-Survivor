using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public Player player;
    public float rotatingSpeed = 1;
    private Joystick joystick;
    private void Awake()
    {
        joystick = FindAnyObjectByType<Joystick>();
    }

    private void Update()
    {
        //float x = Input.GetAxisRaw("Horizontal");
        float x = joystick.Horizontal;
        if (player.isMoving)
        {
            transform.Rotate(new Vector3(0, 0, -x * rotatingSpeed * Time.deltaTime * 60));
        }
    }
}
