using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.CameraController
{
    public class PhoneCameraHandler : CameraHandler
    {
        public PhoneCameraHandler(CinemachineVirtualCamera cam, CameraHandlerSettings settings) : base(cam, settings)
        {

        }
        public override void Input()
        {
            throw new System.NotImplementedException();
        }

        public override void Move(Vector2 vec)
        {
            throw new System.NotImplementedException();
        }

        public override void Zoom(float value)
        {
            throw new System.NotImplementedException();
        }
    }
}