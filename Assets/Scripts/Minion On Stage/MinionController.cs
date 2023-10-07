using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionController : Attackable, ITurnAware
{
    public float AttackAnimationSpeed = 2f;
    private MinionDisplayComponent _minionDisplayComponent;
    private MinionCardData _minionData;
    private int _maxAttackTimes;
    private int _curAttackTimes = 0;

    protected override void Awake()
    {
        base.Awake();
        _minionDisplayComponent = GetComponent<MinionDisplayComponent>();
        if (!_minionDisplayComponent)
            Debug.LogError("minion on stage: no display component found");
    }

    public void SetLocalPosX(float posX)
    {
        transform.localPosition = new Vector3(posX, transform.localPosition.y, transform.localPosition.z);
    }

    public void Initialize(MinionCardData minionData)
    {
        _minionData = minionData;
        _minionDisplayComponent.Init(_minionData);
        attackValue = _minionData.Attack;
        _maxAttackTimes = _minionData.MaxAttackTimes;
        healthComponent.Init(_minionData.HP);
        if (minionData.IsCharge)
            RecoverAttackTimes();
    }

    public bool IsTaunt()
    {
        return _minionData.IsTaunt;
    }

    public bool CanAttack()
    {
        return _curAttackTimes > 0;
    }

    private void SetCurAttackTimes(int value)
    {
        _curAttackTimes = value;
        UpdateFrameHighlight();
    }

    public void RecoverAttackTimes()
    {
        SetCurAttackTimes(_maxAttackTimes);
    }

    public void Attack(Attackable target)
    {
        if (CanAttack())
        {
            StartCoroutine(AttackAnimation(target, target.transform.position));
            target.TakeDamage(attackValue);
            TakeDamage(target.attackValue);
            SetCurAttackTimes(_curAttackTimes - 1);
        }
    }

    public void UpdateFrameHighlight()
    {
        _minionDisplayComponent.SetFrameHighlight(CanAttack());
    }

    protected override void HandleDeath()
    {
        base.HandleDeath();
        if (PlayerStageManager.instance.TryRemoveMinion(this))
        {
            Destroy(gameObject);
        }
        else if (OpponentStageManager.instance.TryRemoveMinion(this))
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator AttackAnimation(Attackable target, Vector3 targetPos)
    {
        GameManager.instance.IsDraggingLocked = true; // lock dragging before animation finishes
        Vector3 initPos = gameObject.transform.position;
        Vector3 dirVector = (targetPos - initPos).normalized * AttackAnimationSpeed;
        while ((gameObject.transform.position - targetPos).magnitude > 1)
        {
            gameObject.transform.position += dirVector;
            yield return null;
        }
        target.Shake();
        while ((gameObject.transform.position - initPos).magnitude > 1)
        {
            gameObject.transform.position -= dirVector;
            yield return null;
        }
        Shake();
        GameManager.instance.IsDraggingLocked = false;
    }

    public void StartNewTurn()
    {
        RecoverAttackTimes();
    }

    public void EndTurn()
    {
        SetCurAttackTimes(0);
    }
}
