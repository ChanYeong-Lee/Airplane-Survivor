using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletChasing : MonoBehaviour
{
    public Transform bullet;
    private Transform target;
    private bool chasingPrepared;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy target) && this.target == null)
        {
            this.target = target.transform;
        }
    }
    private void OnEnable()
    {
        chasingPrepared = false;
        StartCoroutine(ChasingCoroutine());
    }

    private void FixedUpdate()
    {
        if (target != null && chasingPrepared)
        {
            Vector2 targetPos = target.position;
            Vector2 dir = targetPos - (Vector2)transform.position;
            dir.Normalize();
            if ((Vector2)bullet.transform.up != dir)
            {
                bullet.transform.up = Vector2.Lerp(bullet.transform.up, dir, Time.fixedDeltaTime * 10);
            }
            Vector2 dirPos = transform.position + bullet.transform.up * Time.fixedDeltaTime;
            bullet.GetComponent<Bullet>().rb.MovePosition(dirPos);
        }
    }

    private IEnumerator ChasingCoroutine()
    {
        yield return new WaitForSeconds(1f);
        chasingPrepared = true;
    }
}
