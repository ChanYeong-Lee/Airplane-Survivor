using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;

    Player player;
    private Rigidbody2D rb;
    private Transform pivot;

    public enum State
    {
        forward,
        backward
    }

    public State state;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        pivot = player.rotation.transform;
    }

    private void Update()
    {
        float y = Input.GetAxisRaw("Vertical");

        rb.AddForce(y * pivot.up * moveSpeed);

        if (rb.velocity.magnitude > 1)
        {
            player.isMoving = true;
        }

        state = (y >= 0) ? State.forward : State.backward;
    }
}
