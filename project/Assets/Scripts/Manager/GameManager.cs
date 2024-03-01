using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private void Start()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
    }

    private void Update()
    {
        if (WeaponManager.Instance.IsRotateable())
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                WeaponManager.Instance.Rotate(RotateDirection.Counterclockwise);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                WeaponManager.Instance.Rotate(RotateDirection.Clockwise);
            }
        }
    }
}
