using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class AttackTile : MonoBehaviour
{
    private SpriteRenderer _renderer;

    AnimFloat animT = new AnimFloat(0);
    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        animT.target = 0;
    }

    private void Update()
    {
        _renderer.color = Color.Lerp(Color.white, Color.red, animT.value);
    }

    public void ChangeColor()
    {
        animT.value = 1;
        animT.target = 0;
        //_renderer.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
    }

    public void ChangeColor(Color32 color)
    {
        _renderer.color = color;
    }

}
