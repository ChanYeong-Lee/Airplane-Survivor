using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float hp;
    public float damage;
    public float speed;

    private Transform pivot;
    private float distance = 2;
    private WaitForSeconds revoluteSec;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        revoluteSec = new WaitForSeconds(0.02f);
    }

    private void Start()
    {
        pivot = GameManager.Instance.player.transform;
    }
    public void Shot()
    {
        //StartCoroutine(RevolutionCoroutine());
        StartCoroutine(PoolManager.Instance.RemoveObject(gameObject, PoolType.Planet, 10f));
    }
    private void OnEnable()
    {
        angle = 0;
    }

    private void OnDisable()
    {
        transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
    }

    private float angle;
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime));
        angle += Time.deltaTime;
        float x = distance * Mathf.Cos(angle);
        float y = distance * Mathf.Sin(angle);
        transform.position = new Vector2(pivot.position.x + x, pivot.position.y + y);
        if (angle >= 2 * Mathf.PI) angle = 0;
    }
}
