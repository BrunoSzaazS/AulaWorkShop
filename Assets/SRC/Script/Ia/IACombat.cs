using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IACombat : MonoBehaviour
{
    [Header("Main Data")]
    private EnemyScriptabol brain;
    [Header("infornações de ataque")]
    [SerializeField] private bool canAttack;
    [SerializeField] private float currentAttackCooldown;
    [Header("informações do player")]

    private NavMeshAgent nav;
    public void Init(EnemyScriptabol pBrain)
    {
        brain = pBrain;
        nav = GetComponent<NavMeshAgent>();
        nav.stoppingDistance = brain.attackRange;
    }
    public bool CheckAndAttack(Transform target)
    {
        CoolDownRecovery();
        if (Vector3.Distance(transform.position, target.position) < brain.attackRange)
        {
            if (canAttack)
            {
                Attack(target);
            }
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Attack(Transform target)
    {
        canAttack = false;
        target.GetComponent<IDamageable>().TakeDamege(Random.Range(brain.attackDamege[0], brain.attackDamege[1]));
    }
    public void CoolDownRecovery()
    {
        currentAttackCooldown -= Time.deltaTime;
        if (currentAttackCooldown < 0)
        {
            currentAttackCooldown = 0;
            canAttack = true;
            currentAttackCooldown = brain.attackSpeed;
        }
    }
}
