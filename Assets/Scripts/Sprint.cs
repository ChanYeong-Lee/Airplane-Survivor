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

    private void Start()
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
            enemy.rb.AddForce(enemy.rotation.up * sprintPower);
            yield return new WaitForSeconds(sprintDuration);
            enemy.isSprinting = false;
            yield return new WaitForSeconds(gapTime);
        }
    }

}
