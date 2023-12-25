using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : MonoBehaviour
{
    private Enemy enemy;
    public float moveSpeed;
    public float rotatingSpeed;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    private void FixedUpdate()
    {
        Vector2 playerPos = GameManager.Instance.player.transform.position;
        Vector2 dir = playerPos - (Vector2)transform.position;
        dir.Normalize();
        if ((Vector2)enemy.rotation.up != dir && !enemy.isSprinting)
        {
            enemy.rotation.up = Vector2.Lerp(enemy.rotation.up, dir, Time.fixedDeltaTime * rotatingSpeed);
        }
        if (!enemy.isSprinting)
        {
            Vector2 dirPos = transform.position + enemy.rotation.up * moveSpeed * Time.fixedDeltaTime;
            enemy.rb.MovePosition(dirPos);
        }
    }
}
