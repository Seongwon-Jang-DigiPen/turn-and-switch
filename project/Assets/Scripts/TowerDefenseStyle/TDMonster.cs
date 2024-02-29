using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using System;

public class TDMonster : CharacterBase
{
    Vector2 prevPos;
    Vector2 CurrPos;
    private int _aiListIdx = 0;
    public float Damage = 5;
    public MonsterAction[] AIList;

    AnimFloat animT = new AnimFloat(1);

    bool IsTiled => TilePos.x >= 0 && TilePos.y > 0 && TilePos.x < 5 && TilePos.y < 5;

    public bool IsActionDone => animT.isAnimating == false;

    public Animator Animator;
    public enum AnimState
    {
        Idle,
        Ready,
        Walking,
        Running,
        Jumping,
        Dead
    }
    private void Start()
    {
        prevPos = transform.position;
        CurrPos = prevPos;
        animT.value = 0;
        animT.target = 1f;
    }

    private void Update()
    {
        //if (animT.value == animT.target) { SetState(AnimState.Idle); }
        transform.position = Vector3.Lerp(prevPos, CurrPos, animT.value);
    }
    public void Move()
    {
        if (AIList.Length <= 0)
        {
            return;
        }
        prevPos = this.transform.position;

        switch (AIList[_aiListIdx].MonAction)
        {
            case MonsterAction.Action.Move:
                CurrPos = AttackTileManager.GetTile(AIList[_aiListIdx].Pos).transform.position;
                TilePos = AIList[_aiListIdx].Pos;
                animT.value = 0; animT.target = 1f;
                SetState(AnimState.Walking);
                break;
            case MonsterAction.Action.Wait:
                SetState(AnimState.Ready);
                animT.value = 0; animT.target = 1f;
                break;
            case MonsterAction.Action.Attack:
                Animator.SetTrigger("Attack");
                animT.value = 0; animT.target = 1f;
                Attack();
                break;
        }
        _aiListIdx = (_aiListIdx + 1 >= AIList.Length) ? 0 : _aiListIdx + 1;
    }

    void Attack()
    {
        Player.Instance.Hitted(Damage);
    }

    public void SetState(AnimState state)
    {
        foreach (var variable in new[] { "Idle", "Ready", "Walking", "Running", "Jumping", "Dead" })
        {
            Animator.SetBool(variable, false);
        }
        switch (state)
        {
            case AnimState.Idle: Animator.SetBool("Idle", true); break;
            case AnimState.Ready: Animator.SetBool("Ready", true); break;
            case AnimState.Walking: Animator.SetBool("Walking", true); break;
            case AnimState.Running: Animator.SetBool("Running", true); break;
            case AnimState.Jumping: Animator.SetBool("Jumping", true); break;
            case AnimState.Dead: Animator.SetBool("Dead", true); break;
            default: throw new NotSupportedException();
        }

        //Debug.Log("SetState: " + state);
    }

    public override void Hitted(float damage)
    {
        base.Hitted(damage);
        Animator.SetTrigger("Hit");
        if (HP <= 0) { this.gameObject.SetActive(false); }
    }
}



[Serializable]
public class MonsterAction
{
    public enum Action
    {
        Move, Wait, Attack
    }
    public Action MonAction;
    public Vector2Int Pos;
}