using System;
using UnityEngine;

public class PlayerHealthComponent : MonoBehaviour
{
    [SerializeField] private float _health;

    private float _maxHealth = 100f;
    private float _minHealth = 0f;

    public float MaxHealth => _maxHealth;
    public float MinHealth => _minHealth;
    public float Health => _health;
    
    public void SetValue(float health)
    {
        _health = health;
    }
}