using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private UnityEvent _event;

    public float MaxHealth => 100f;

    public float MinHealth => 0f;

    public float Health => _health;

    public void OnTakeDamage(float damage)
    {
        if (_health <= MinHealth) return;
        _health = Mathf.Clamp(_health - damage, MinHealth, MaxHealth);
        OnHealthValueChanged();
    }

    public void OnHeal(float heal)
    {
        if (_health >= MaxHealth) return;
        _health = Mathf.Clamp(_health + heal, MinHealth, MaxHealth);
        OnHealthValueChanged();
    }

    private void OnHealthValueChanged()
    {
        _event?.Invoke();
    }
}