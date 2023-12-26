using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSkill : Skill
{
    public GameObject bulletPrefab;
    public int bulletCount;
    public float shotRate;
    private Transform pivot;
    public float damage;
    public float speed;

    private void Awake()
    {
        skillType = SkillType.Active;
        skillName = SkillName.ShotSkill;
    }

    private void Start()
    {
        pivot = GameManager.Instance.player.rotation.transform;
        StartCoroutine(ShotCoroutine());
    }

    private IEnumerator ShotCoroutine()
    {
        while (true)
        {
            float totalDamage = damage * GameManager.Instance.player.damage;
            for (int i = 0; i < bulletCount; i++)
            {
                float angle = -5 * (bulletCount / 2 - i);
                Vector3 shotAngle = new Vector3(transform.eulerAngles.x, transform.rotation.y, transform.eulerAngles.z + angle);
                Bullet bullet = PoolManager.Instance.GenerateObject(PoolType.Bullet).GetComponent<Bullet>();
                bullet.transform.position = pivot.position;
                bullet.transform.rotation = pivot.rotation;
                bullet.transform.Rotate(shotAngle);
                bullet.damage = totalDamage;
                bullet.speed = speed;
                bullet.gameObject.SetActive(true);
                bullet.GetComponent<Bullet>().Shot();
            }
            yield return new WaitForSeconds(shotRate);
        }
    }

}
