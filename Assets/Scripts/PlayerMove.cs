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

        state = (y >= 0) ? State.forward : State.backward;


        if (state == State.backward)
        {
            Vector2 backVelocity = rb.velocity / -(Vector2)transform.up;
            if (backVelocity.x > 0 && backVelocity.y > 0)
            {
                rb.AddForce(y * pivot.up * moveSpeed);
            }
        }
        else
        {
            rb.AddForce(y * pivot.up * moveSpeed);
        }

        player.isMoving = rb.velocity.magnitude > 1;
    }
}
