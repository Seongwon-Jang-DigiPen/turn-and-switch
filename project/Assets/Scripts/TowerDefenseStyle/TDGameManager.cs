using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//battleManagement
public class TDGameManager : MonoBehaviour
{
    static private TDGameManager _instance;
    static public TDGameManager Instance { get { return _instance; } }

    WeaponManager _weaponManager;
    bool CanRotate = true;
    public int TurnCount { get { return _turnCount; } }
    private int _turnCount = 0;


    private void Start()
    {
        if (_instance != null) { Destroy(this.gameObject); return; }
        _instance = this;



        _weaponManager = FindAnyObjectByType<WeaponManager>();
    }

    private void Update()
    {
        if (CanRotate == true)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                _weaponManager.Rotate(RotateDirection.Clockwise);
                StartCoroutine(test());

            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                _weaponManager.Rotate(RotateDirection.Counterclockwise);
                StartCoroutine(test());
            }
        }

    }
    IEnumerator test()
    {
        CanRotate = false;

        while (_weaponManager.IsAttackDone == false)
            yield return null;


        foreach (var mon in TDMonsterManager.Instance.Monsters)
        {
            mon.Move();
        }

        while (TDMonsterManager.Instance.IsActionDone() == false)
            yield return null;

        _turnCount++;
        CanRotate = true;
    }


}
