using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _bar;
    [SerializeField] private Player _player;

    private readonly float _speed = 25f;

    private Coroutine _coroutine;

    private void Awake()
    {
        _bar = GetComponent<Slider>();
    }

    private void Start()
    {
        _bar.maxValue = _player.MaxHealth;
        _bar.minValue = _player.MinHealth;
        _bar.value = _player.Health;
    }

    public void OnChange()
    {
        CheckExistCoroutine();
        _coroutine = StartCoroutine(ChangeValue());
    }

    private void CheckExistCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator ChangeValue()
    {
        while (_bar.value != _player.Health)
        {
            _bar.value = Mathf.MoveTowards(_bar.value, _player.Health, _speed * Time.deltaTime);
            yield return null;
        }
    }
}