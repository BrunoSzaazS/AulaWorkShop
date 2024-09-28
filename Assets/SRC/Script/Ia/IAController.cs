using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class IAController : MonoBehaviour
{
    [Header("Main Data")]
    [SerializeField] private EnemyScriptabol brain;
    [Header("Player Reference")]
    private Transform playerTransform;
    [Header("Transform Data")]
    [SerializeField] private Transform GFXtransfom;

    [Header("scripts References")]
    private IAStates IAStatesScript;
    private IACombat IACombatScript;
    private IAMovment IAMovmentScript;

    [Header("References Check")]
    [SerializeField] private bool referencesOk;
    private void Update()
    {
        if (!referencesOk) return;
        if (!playerTransform) return;
        if (IAStatesScript.States == IAStateType.chasing)
        {
            ChaseBehaviour();
            return;
        }
        if(IAStatesScript.States != IAStateType.attacking)
        {
            AttackBehaviour();
            return;
        }
    }
    void ChaseBehaviour()
    {
        var sucesso = IAMovmentScript.Chase(playerTransform);
        if(!sucesso) IAStatesScript.ChangeToStates(IAStateType.attacking);
    }
    void AttackBehaviour()
    {
       var sucesso = IACombatScript.CheckAndAttack(playerTransform);
        if (!sucesso)
        {
            IAStatesScript.ChangeToStates(IAStateType.chasing);
        }
    }
    void InstantiateGFX()
    {
        Instantiate(brain.GFX, GFXtransfom);
    }

    void FindPlayerReference()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void Init(EnemyScriptabol pBrain)
    {
        referencesOk = false;
        IAStatesScript = GetComponent<IAStates>();
        IACombatScript = GetComponent<IACombat>();
        IAMovmentScript = GetComponent<IAMovment>();
        brain = pBrain;
        IACombatScript.Init(brain);
        InstantiateGFX();
        FindPlayerReference();
        referencesOk = true;
    }
}
