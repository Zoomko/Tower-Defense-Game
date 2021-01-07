using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class TestingNavMesh : MonoBehaviour
{
    public NavMeshAgent NavMeshAgent;

    public float Z;

    private void Start()
    {
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            var worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

            Debug.Log(pos);
            Debug.Log(worldPosition);
            Move(pos);
        }
    }

    public void Move(Vector2 target)
    {
       // NavMeshAgent.SetDestination(target);
    }
}
