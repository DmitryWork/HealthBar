using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _bar;
    [SerializeField] private PlayerHealthComponent _playerHealth;

    private readonly float _speed = 25f;

    private Coroutine _coroutine;

    private void Awake()
    {
        _bar = GetComponent<Slider>();
    }

    private void Start()
    {
        _bar.maxValue = _playerHealth.MaxHealth;
        _bar.minValue = _playerHealth.MinHealth;
        _bar.value = _playerHealth.Health;
    }

    public void OnChange(float value)
    {
        CheckExistCoroutine();
        CheckInputValue(value, out float targetValue);
        _coroutine = StartCoroutine(ChangeValue(targetValue));
    }

    private void CheckExistCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private void CheckInputValue(float value, out float targetValue)
    {
        float finalValue = _bar.value + value;

        if (finalValue >= _bar.maxValue)
        {
            finalValue = _bar.maxValue;
        }
        else if (finalValue <= _bar.minValue)
        {
            finalValue = _bar.minValue;
        }

        targetValue = finalValue;
    }

    private IEnumerator ChangeValue(float targetValue)
    {
        while (_bar.value != targetValue)
        {
            _bar.value = Mathf.MoveTowards(_bar.value, targetValue, _speed * Time.deltaTime);
            yield return null;
        }

        _playerHealth.SetValue(_bar.value);
    }
}