using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    private Transform pivot;
    public float damage;

    private void Start()
    {
        pivot = GameManager.Instance.player.transform;
    }


    private void Update()
    {
        transform.position = pivot.position;    
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // damage 주는 것 구현
    }
}
