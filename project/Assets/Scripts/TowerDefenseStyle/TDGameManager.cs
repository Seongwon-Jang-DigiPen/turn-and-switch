using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//battleManagement
public class TDGameManager : MonoBehaviour
{
    public enum ActionList
    {
        TurnRight, TurnLeft, Attack
    }

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

    private void PlayerAction(ActionList action)
    {
        switch (action)
        {
            case ActionList.TurnRight:
                _weaponManager.Rotate(RotateDirection.Clockwise);
                break;
            case ActionList.TurnLeft:
                _weaponManager.Rotate(RotateDirection.Counterclockwise);
                break;
            case ActionList.Attack:
                _weaponManager.Attack();
                break;
        }
        foreach (var mon in TDMonsterManager.Instance.Monsters)
        {
            mon.Move();
        }

        _turnCount++;
        if (_turnCount % 2 == 0)
        {
            TDMonsterGenerator.Instance.Generate();
        }

    }

    private void Update()
    {
        if (CanRotate == true)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                PlayerAction(ActionList.TurnRight);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                PlayerAction(ActionList.TurnLeft);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerAction(ActionList.Attack);
            }
        }

    }
    IEnumerator test()
    {
        // CanRotate = false;

        // while (_weaponManager.IsAttackDone == false)
        yield return null;


        // foreach (var mon in TDMonsterManager.Instance.Monsters)
        // {
        //     mon.Move();
        // }

        // while (TDMonsterManager.Instance.IsActionDone() == false)
        //     yield return null;

        // _turnCount++;
        // CanRotate = true;
    }


}
