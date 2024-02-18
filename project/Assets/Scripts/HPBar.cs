using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    SpriteRenderer _hpBar;
    CharacterBase _character;
    float _hpBarXSize = 0;
    private void Awake()
    {
        _hpBar = transform.Find("HPBar").gameObject.GetComponent<SpriteRenderer>();
        _character = GetComponentInParent<CharacterBase>();
        if(_hpBar == null || _character == null)
        {
            string h = (_hpBar == null) ? "null" : _hpBar.name;
            string c = (_character == null) ? "null" : _character.name;
            Debug.Log($" HPBar Error -- hp Bar : {h} | character : {_character}");
            return;
        }
        _hpBarXSize = _hpBar.size.x;
    }

    private void Update()
    {
        _hpBar.size = new Vector2(Mathf.Min(_hpBarXSize, (Mathf.Max(_hpBarXSize * (_character.HP / _character.MaxHp), 0.0f))), _hpBar.size.y);
    }

}
