using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private UnityEvent _event;

    public static float MaxHealth => 100f;

    public static float MinHealth => 0f;

    public float Health => _health;

    public void OnTakeDamage(float damage)
    {
        if (_health <= MinHealth) return;
        GetNewHealthValue(-damage, out float newHealthValue);
        _health = newHealthValue;
        OnHealthValueChanged();
    }

    public void OnHeal(float heal)
    {
        if (_health >= MaxHealth) return;
        GetNewHealthValue(heal, out float newHealthValue);
        _health = newHealthValue;
        OnHealthValueChanged();
    }

    private void GetNewHealthValue(float value, out float newHealthValue)
    {
        float result = _health + value;

        if (result <= MinHealth)
        {
            result = MinHealth;
        }
        else if (result >= MaxHealth)
        {
            result = MaxHealth;
        }

        newHealthValue = result;
    }

    private void OnHealthValueChanged()
    {
        _event?.Invoke();
    }
}