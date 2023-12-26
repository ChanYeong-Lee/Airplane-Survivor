using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    private Enemy enemy;
    public float sprintRate;
    public float sprintPower;
    public float sprintDuration;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        StartCoroutine(SprintCoroutine());    
    }

    private IEnumerator SprintCoroutine()
    {
        yield return new WaitForSeconds(3);
        while (true)
        {
            float gapTime = sprintRate - sprintDuration;
            enemy.isSprinting = true;
            for (int i = 0; i < sprintDuration / 0.02; i++)
            {
                enemy.chasing.moveSpeed += sprintPower * 0.02f / sprintDuration;
                yield return new WaitForSeconds(0.02f);
            }
            enemy.isSprinting = false;
            for (int i = 0; i < gapTime / 0.02; i++)
            {
                enemy.chasing.moveSpeed -= sprintPower * 0.02f / gapTime;
                yield return new WaitForSeconds(0.02f);
            }
            yield return new WaitForSeconds(gapTime);
        }
    }

}
