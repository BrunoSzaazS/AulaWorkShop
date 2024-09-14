using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerManager : MonoBehaviour
{
    private NavMeshAgent nav;
    [SerializeField]
    [Header("Layers")]
    private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(ray, Mathf.Infinity, groundLayer))
        {

        }
    }
}
