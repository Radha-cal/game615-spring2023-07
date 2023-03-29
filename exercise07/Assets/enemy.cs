using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemy : MonoBehaviour
{
    [SerializeField] Transform target;
   public NavMeshAgent navMesh;
    // Start is called before the first frame update
    void Start()
    {
        navMesh = gameObject.GetComponent<NavMeshAgent>;
    }

    // Update is called once per frame
    void Update()
    {
        navMesh.SetDestination(target.position);
    }
}
