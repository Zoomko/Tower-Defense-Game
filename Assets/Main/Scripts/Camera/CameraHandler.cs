using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


namespace TowerDefense.CameraController
{
    
    public abstract class CameraHandler
    {
        
        private CameraHandlerSettings _cameraHandlerSettings;
        private CinemachineVirtualCamera _camera;
        public CameraHandlerSettings Settings { get => _cameraHandlerSettings; set => _cameraHandlerSettings = value; }
        protected CinemachineVirtualCamera Camera { get => _camera;}

        public CameraHandler(CinemachineVirtualCamera cam, CameraHandlerSettings settings)
        {
            _camera = cam;
            _cameraHandlerSettings = settings;
        }

        public abstract void Move(Vector2 delta);
        public abstract void Zoom(float value);
        public abstract void Input();
    }
}
