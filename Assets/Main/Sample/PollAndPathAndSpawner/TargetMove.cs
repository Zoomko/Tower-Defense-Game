using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TargetMove : MonoBehaviour
{
    public static event Action<GameObject> TargetAchivedEvent;

    [SerializeField] private Transform target;
    NavMeshAgent NavMeshAgent; 

    void Start()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
        if(target != null)
        {
            SetTarget(target);
        }
    }

    private void Update()
    {
        if (TargetAchived())
        {
            TargetAchivedEvent?.Invoke(this.gameObject);
        }
    }

    private bool TargetAchived()
    {
        return AproximateCompare(transform.position, target.position); 
    }

    private bool AproximateCompare(Vector3 a, Vector3 b)
    {
        return (int)a.x == (int) b.x &&
               (int)a.y == (int) b.y;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
        NavMeshAgent.SetDestination(target.position);
    }
}
