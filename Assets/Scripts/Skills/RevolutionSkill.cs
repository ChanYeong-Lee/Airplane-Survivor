using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RevolutionSkill : Skill
{
    public GameObject planetPrefab;

    public int planetCount;
    public float shotRate;

    WaitForSeconds shotRateSec;
    private void Awake()
    {
        shotRateSec = new WaitForSeconds(shotRate);
        skillType = SkillType.Active;
    }

    private void OnEnable()
    {
        StartCoroutine(RevolutionCoroutine());
    }

    private IEnumerator RevolutionCoroutine()
    {
        while (true)
        {
            for (int i = 0; i < planetCount; i++)
            {
                GameObject planet = PoolManager.Instance.GenerateObject(PoolType.Planet);
                planet.SetActive(true);
                planet.GetComponent<Planet>().Shot();
                yield return new WaitForSeconds(0.3f);
            }
            yield return shotRateSec;
        }
    }
} 
