using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class AttackTile : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private Color color;

    AnimFloat animT = new AnimFloat(0);
    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        animT.value = 0;
        animT.target = 1;
        animT.speed = 1;
    }

    private void Update()
    {
        _renderer.color = Color.Lerp(color, Color.white, Mathf.Max(0f, animT.value));
    }

    public void ChangeColor(Color c)
    {
        animT.value = 0;
        animT.target = 1;
        color = c;
    }
}
