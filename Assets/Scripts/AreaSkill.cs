using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSkill : MonoBehaviour
{
    public GameObject areaPrefab;
    public float radius;

    private void OnEnable()
    {
        GameObject area = PoolManager.Instance.GenerateObject(PoolType.Area);
        area.SetActive(true);
        area.transform.localScale = new Vector3(radius, radius, 0);
    }

}
