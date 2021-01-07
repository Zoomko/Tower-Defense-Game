using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class NavMeshAgentMoveTesting :  MonoBehaviour, IPointerClickHandler
{
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        PlayerMouseClickHandler.PlayerClickForPath +=  Move;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void Move(Vector2 target)
    {
        navMeshAgent.SetDestination(target);
    }

    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Клик по герою, без рейкастов!");
    }
}
