using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class TestingNavMesh : MonoBehaviour
{
    public NavMeshAgent NavMeshAgent;

    private void Start()
    {
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Move(pos);
        }
    }

    public void Move(Vector2 target)
    {
        NavMeshAgent.SetDestination(target);
    }
}
