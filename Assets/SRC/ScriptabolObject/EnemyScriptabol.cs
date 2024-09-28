using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
[CreateAssetMenu(fileName ="Enemy",menuName = "ScriptableObjects/EnemyData", order = 0)]
public class EnemyScriptabol : ScriptableObject 
{
    [Header("Data")]
    public Status Status;

    [Header("CombatData")]
    public float attackRange;
    public float attackSpeed;
    public int[] attackDamege;
    [Header("GFX")]
    public GameObject GFX;
}
