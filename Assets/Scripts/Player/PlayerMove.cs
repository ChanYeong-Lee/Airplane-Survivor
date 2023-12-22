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


    private float RPM;

    // 언젠간 쓸 것들
    //private float maxRPM = 2000;
    //private float RPMIncres = 250;
    //private float RPMDecres = 300;
    //private float Torque = 500;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        pivot = player.rotation.transform;
    }

    private void FixedUpdate()
    {
        float y = Input.GetAxisRaw("Vertical");

        if (RPM >= 0 && RPM <= 2000)
        {
            if (y <= 0) { RPM -= Time.fixedDeltaTime * 500; }
            RPM += y * Time.fixedDeltaTime * 400;
        }
        if (RPM < 0) RPM = 0;
        if (RPM > 2000) RPM = 2000;
        Vector2 dir = transform.position + pivot.up * moveSpeed * RPM / 400 * Time.fixedDeltaTime;
        rb.MovePosition(dir);

        player.isMoving = Vector2.Distance(transform.position, dir) > 0;
    }
}
