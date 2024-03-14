using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    private Joystick joystick;
    private ExcelButton excelButton;

    Player player;
    private Rigidbody2D rb;
    private Transform pivot;
    public bool sprintPrepared = true;
    private float RPM;

    // 언젠간 쓸 것들
    //private float maxRPM = 2000;
    //private float RPMDiff = 400;
    //private float Torque = 400;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        pivot = player.rotation.transform;
        joystick = FindAnyObjectByType<Joystick>();
        excelButton = FindAnyObjectByType<ExcelButton>();

        excelButton.onPointerDown.AddListener(() => y = 1.0f);
        excelButton.onPointerUp.AddListener(() => y = 0.0f);
    }
    float y = 0.0f;
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (sprintPrepared)
            {
                StartCoroutine(Sprint());
            }
        }

        float maxRPM = 2000 * moveSpeed;
        float RPMDiff = 400;
        if (RPM >= 0 && RPM <= maxRPM)
        {
            if (y <= 0) { RPM -= Time.fixedDeltaTime * maxRPM / 3; }
            RPM += y * Time.fixedDeltaTime * RPMDiff;
        }
        if (RPM < 0) RPM = 0;
        if (RPM >= maxRPM) RPM = Mathf.Lerp(RPM, maxRPM, Time.fixedDeltaTime);
        Vector2 dir = transform.position + pivot.up * moveSpeed * RPM / 400 * Time.fixedDeltaTime;
        rb.MovePosition(dir);

        player.isMoving = Vector2.Distance(transform.position, dir) > 0;
    }
    private IEnumerator Sprint()
    {
        sprintPrepared = false;
        player.sprintPrepared?.Invoke(sprintPrepared);
        float amount = moveSpeed * 0.3f;
        moveSpeed += amount;
        yield return new WaitForSeconds(2f);
        moveSpeed -= amount;
        yield return new WaitForSeconds(10f);
        sprintPrepared = true;
        player.sprintPrepared?.Invoke(sprintPrepared);
    }
}
