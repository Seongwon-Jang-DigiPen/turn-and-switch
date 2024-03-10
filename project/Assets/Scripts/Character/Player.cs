using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterBase
{
    private static Player _instance;
    public static Player Instance { get { return _instance; } }

    private PlayerControl _control;
    public PlayerControl Control { get { return _control; } }
    private float _power;
    public float Power { get { return _power; } set { Power = _power; } }

    public float _stamina = 100;
    private float Stamina { get { return _stamina; } set { _stamina = value; } }

    private float _maxStamina = 100f;
    public float MaxStamina { get { return _maxStamina; } }
    public float Speed = 5;

    private void Start()
    {
        if (_instance != null)
        {
            Debug.LogError("Player MUST BE ONLY ONE OBJECT");
        }
        _instance = this;
        _control = GetComponent<PlayerControl>();
    }




}

