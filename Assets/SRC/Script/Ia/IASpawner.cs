using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IASpawner : MonoBehaviour
{
    public EnemyScriptabol[] enemiesBrain;
    public GameObject enemyPrefab;
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, 1);
    }
    public void SpawnEnemy()
    {
        var enemy = Instantiate(enemyPrefab, transform.position,Quaternion.identity);
        enemy.GetComponent<IAController>().Init(enemiesBrain[Random.Range(0, enemiesBrain.Length)]);
    }
}
