using UnityEngine;

public class ModifyPlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerHealthBar _playerHealthBar;

    public void ChangeValue(float value)
    {
        _playerHealthBar.OnChange(value);
    }
}