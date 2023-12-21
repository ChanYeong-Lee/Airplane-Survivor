using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float moveSpeed;

    Transform player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMove>().transform;
    }

    private void Update()
    {
        Vector3 direction = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, direction, 0.02f);
    }
}
