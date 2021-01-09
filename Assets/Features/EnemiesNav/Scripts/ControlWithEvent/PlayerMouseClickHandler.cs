using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMouseClickHandler : MonoBehaviour, IPointerClickHandler
{
    public static event Action<Vector2> PlayerClickForPath; 

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerCurrentRaycast);
        Debug.Log(eventData.pointerCurrentRaycast.worldPosition);
        Debug.Log(eventData.pointerCurrentRaycast.distance);
        PlayerClickForPath?.Invoke(eventData.pointerCurrentRaycast.worldPosition);
    }
}
