using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour
{
    SpriteRenderer _staminaBar;
    Player _player;
    float _staminaBarXSize = 0;
    private void Awake()
    {
        _staminaBar = transform.Find("StaminaBar").gameObject.GetComponent<SpriteRenderer>();
        _player = GetComponentInParent<Player>();
        if(_staminaBar == null || _player == null)
        {
            string h = (_staminaBar == null) ? "null" : _staminaBar.name;
            string c = (_player == null) ? "null" : _player.name;
            Debug.Log($" StaminaBar Error -- Stamina Bar : {h} | character : {c}");
            return;
        }
        _staminaBarXSize = _staminaBar.size.x;
    }

    private void Update()
    {
        _staminaBar.size = new Vector2(Mathf.Min(_staminaBarXSize, (Mathf.Max(_staminaBarXSize * (_player.HP / _player.MaxHp), 0.0f))), _staminaBar.size.y);
    }

}
