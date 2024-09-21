using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAMovment : MonoBehaviour
{
    private NavMeshAgent nav;
    [Header("Enemy info")]
    [SerializeField]
    private float attackRange;
    [SerializeField]
    private float attackSpeed;
    [SerializeField]
    private float currentAttackCooldown;
    [SerializeField]
    private int[] attackDamege;
    public bool canAttack;

    [Header("Player info")]
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        nav=GetComponent<NavMeshAgent>();
        nav.stoppingDistance = attackRange;

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        if (canAttack)
        {
            Attack();
        }
        else
        {
            currentAttackCooldown -= Time.deltaTime;
            if (currentAttackCooldown < 0)
            {
                currentAttackCooldown = 0;
                canAttack = true;
                currentAttackCooldown = attackSpeed;
            }
        }
        Chase();
    }
    void Chase()
    {
        nav.SetDestination(player.position);
    }
    void Attack() 
    {
        canAttack = false;
        player.GetComponent<IDamageable>().TakeDamege(Random.Range(attackDamege[0], attackDamege[1]));
    }
}
