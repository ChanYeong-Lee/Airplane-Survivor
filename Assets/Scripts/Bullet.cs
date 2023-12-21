using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float speed;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnDisable()
    {
        transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
    }

    public void Shot()
    {
        rb.velocity = transform.up * speed;
        StartCoroutine(PoolManager.Instance.RemoveObject(gameObject, PoolType.Bullet, 2f));
    }
}
