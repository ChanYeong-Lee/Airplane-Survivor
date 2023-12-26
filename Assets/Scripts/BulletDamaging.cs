using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamaging : MonoBehaviour
{
    public Bullet bullet;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Enemy>(out Enemy target))
        {
            target.TakeDamage(bullet.damage);
            PoolManager.Instance.RemoveObject(bullet.gameObject, PoolType.Bullet);
        }
        else if (collider.gameObject.GetComponent<Player>())
            return;
    }
}
