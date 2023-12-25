using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Image hpBar;

    public float maxHP;
    private float currentHP;
    public Transform rotation;

    [HideInInspector] public UnityEvent<float> onHPChange;
    [HideInInspector] public bool isSprinting;
    [HideInInspector] public Rigidbody2D rb;
    public float CurrentHP { get { return currentHP; }
        set
        {
            currentHP = value;
            if (currentHP <= 0)
            {
                currentHP = 0;
                Die();
            }
            onHPChange?.Invoke(currentHP / maxHP);
        }
    }
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        onHPChange.AddListener(HPBarUpdate);
    }
    private void OnEnable()
    {
        CurrentHP = maxHP;
    }
    public float exp;
    private void Die()
    {
        //
    }

    private void HPBarUpdate(float hpAmount)
    {
        hpBar.fillAmount = hpAmount;
    }
    public void TakeDamage(float damage)
    {
        CurrentHP -= damage;
    }
}

