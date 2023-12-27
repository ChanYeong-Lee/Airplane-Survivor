using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chasing : MonoBehaviour
{
    private Enemy enemy;
    public float moveSpeed;
    public float rotatingSpeed;
    private float setMoveSpeed;
    private float setRotSpeed;
    public enum State { Backward, Forward };
    [HideInInspector] public State state;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        setMoveSpeed = moveSpeed;
        setRotSpeed = rotatingSpeed;
    }
    public void Init()
    {
        moveSpeed = setMoveSpeed;
        moveSpeed = setRotSpeed;
    }
    public void Upgrade(float amount)
    {
        setMoveSpeed *= amount;
        setRotSpeed *= amount;
    }

    private void FixedUpdate()
    {
        Player player = GameManager.Instance.player;
        Vector2 dir = new Vector2();

        state = enemy.isSprinting ? State.Forward : State.Backward;
        switch (state)
        {
            case State.Backward:
                dir = (Vector2)player.transform.position - (Vector2)transform.position;
                break;
            case State.Forward:
                dir = (Vector2)player.transform.position + (Vector2)player.rotation.transform.up - (Vector2)transform.position;
                break;
            default:
                break;
        }

        if (dir.magnitude >= 25)
        {
            PoolManager.Instance.RemoveObject(gameObject, PoolType.Enemy);
        }

        dir.Normalize();
        if ((Vector2)enemy.rotation.up != dir /*&& !enemy.isSprinting*/)
        {
            enemy.rotation.up = Vector2.Lerp(enemy.rotation.up, dir, Time.fixedDeltaTime * rotatingSpeed);
        }
            Vector2 dirPos = transform.position + enemy.rotation.up * moveSpeed * Time.fixedDeltaTime;
            enemy.rb.MovePosition(dirPos);
    }
}
