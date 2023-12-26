using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public float damage;
    [HideInInspector] public float speed;
    [HideInInspector] public Rigidbody2D rb;

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
        StartCoroutine(DetroySelfCoroutine());
    }
    private IEnumerator DetroySelfCoroutine()
    {
        yield return new WaitForSeconds(10f);
        PoolManager.Instance.RemoveObject(gameObject, PoolType.Bullet);
    }
}
