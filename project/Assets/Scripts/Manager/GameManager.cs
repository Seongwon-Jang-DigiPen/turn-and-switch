using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    WeaponManager _weaponManager => WeaponManager.Instance;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _weaponManager.IsRotate = true;
            _weaponManager.Rotate(RotateDirection.Counterclockwise);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _weaponManager.IsRotate = true;
            _weaponManager.Rotate(RotateDirection.Clockwise);
        }
        else
        {
            _weaponManager.IsRotate = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _weaponManager.ShootWeapon();
        }
    }
}
