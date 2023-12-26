using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RevolutionSkill : Skill
{
    public GameObject planetPrefab;

    public int planetCount;
    public float shotRate;
    public float distance;
    public float damage;
    public float speed;

    WaitForSeconds shotRateSec;
    private void Awake()
    {
        shotRateSec = new WaitForSeconds(shotRate);
        skillType = SkillType.Active;
        skillName = SkillName.RevolutionSkill;
    }

    private void OnEnable()
    {
        StartCoroutine(RevolutionCoroutine());
    }

    private IEnumerator RevolutionCoroutine()
    {
        while (true)
        {
            float totalDamage = damage * GameManager.Instance.player.damage;
            for (int i = 0; i < planetCount; i++)
            {
                Planet planet = PoolManager.Instance.GenerateObject(PoolType.Planet).GetComponent<Planet>();
                planet.distance = distance;
                planet.damage = totalDamage;
                planet.speed = speed;
                planet.gameObject.SetActive(true);
                planet.Shot();
                yield return new WaitForSeconds(0.3f);
            }
            yield return shotRateSec;
        }
    }
} 
