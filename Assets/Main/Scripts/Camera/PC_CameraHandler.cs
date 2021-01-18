using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.CameraController
{
    public class PC_CameraHandler : CameraHandler
    {
        private Vector2 previousMousePosition = Vector2.zero;
        private const int LeftMouseButton = 0;
        public PC_CameraHandler(CinemachineVirtualCamera cam, CameraHandlerSettings settings) :base(cam, settings)
        {

        }
        public override void Input()
        {
            var mousePosition = UnityEngine.Input.mousePosition;

            var scrollDelta = UnityEngine.Input.mouseScrollDelta.y;           
            var mouseDelta = GetMousePositionDelta(mousePosition);

            Move(mouseDelta);
            Zoom(scrollDelta);            
        }
        private Vector2 GetMousePositionDelta(Vector2 mousePos)
        {
            var delta = mousePos - previousMousePosition;
            previousMousePosition = mousePos;
            return delta;
        }
        public override void Move(Vector2 delta)
        {
            if (UnityEngine.Input.GetMouseButton(LeftMouseButton))
            {
                var value = new Vector3(-delta.x, -delta.y, 0) * Time.deltaTime * Settings.speedOfTranslating;
                Camera.transform.position += value;
            }
        }

        public override void Zoom(float value)
        {
            var calculatedScrollValue = Camera.m_Lens.OrthographicSize + value;
            if (calculatedScrollValue < Settings.highZoomValue && calculatedScrollValue > Settings.lowZoomValue)
            {
                Camera.m_Lens.OrthographicSize = calculatedScrollValue;
            }
        }
    }
}
