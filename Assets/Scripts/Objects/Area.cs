using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    private Transform pivot;
    [HideInInspector] public float DPS;

    private void Start()
    {
        pivot = GameManager.Instance.player.transform;
    }


    private void Update()
    {
        transform.position = pivot.position;    
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Enemy>(out Enemy target))
        {
            target.TakeDamage(DPS * Time.deltaTime);
        }
        else if (collider.gameObject.GetComponent<Player>())
            return;
    }
}
