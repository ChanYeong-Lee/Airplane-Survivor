using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSkill : Skill
{
    public GameObject bulletPrefab;
    public int bulletCount;
    public float shotRate;
    private Transform pivot;

    private void OnEnable()
    {
        pivot = GameManager.Instance.player.rotation.transform;
        StartCoroutine(ShotCoroutine());
    }

    private void Start()
    {
    }

    private IEnumerator ShotCoroutine()
    {
        while (true)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                float angle = -5 * (bulletCount / 2 - i);
                Vector3 shotAngle = new Vector3(transform.eulerAngles.x, transform.rotation.y, transform.eulerAngles.z + angle);
                GameObject bullet = PoolManager.Instance.GenerateObject(PoolType.Bullet);
                bullet.transform.position = pivot.position;
                bullet.transform.rotation = pivot.rotation;
                bullet.transform.Rotate(shotAngle);
                bullet.SetActive(true);
                bullet.GetComponent<Bullet>().Shot();
            }
            yield return new WaitForSeconds(shotRate);
        }
    }

}
