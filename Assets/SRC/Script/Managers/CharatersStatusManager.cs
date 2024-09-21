using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharatersStatusManager : MonoBehaviour, IDamageable
{
    public Status status;
    public event Action OnTakeDamege;
    private void Start()
    {
        status.Init();
    }
    public void TakeDamege(int amount)
    {
        Debug.Log("TOMANDO " + amount + " DE DANO");
        status.Healt -= amount;
        OnTakeDamege?.Invoke();
        if(status.Healt <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(this.gameObject);
    }
}
