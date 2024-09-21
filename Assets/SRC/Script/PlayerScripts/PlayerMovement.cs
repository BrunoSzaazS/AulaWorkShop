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
        movment();
    }
    private void movment()
    {
        if (Input.GetMouseButtonDown(0)|| Input.GetMouseButton(0))
        {
            MenageMovment();
        }
    }
    private void MenageMovment()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            Debug.Log("hitando chao");
            nav.SetDestination(hit.point);
        }
    }
}
