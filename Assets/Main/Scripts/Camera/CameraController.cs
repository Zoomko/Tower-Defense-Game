using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace TowerDefense.CameraController
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private float highZoomValue;

        [SerializeField]
        private float lowZoomValue;

        [SerializeField]
        private float speed; 

        CinemachineVirtualCamera cam;
        CameraHandler cameraHandler;

        private void Awake()
        {
            cam = GetComponent<CinemachineVirtualCamera>();

            CameraHandlerSettings settings = new CameraHandlerSettings(
                lowZoomValue,
                highZoomValue,
                speed
                );            

            #if UNITY_EDITOR
                cameraHandler = new PC_CameraHandler(cam, settings);
            #endif
            #if UNITY_ANDROID
                cameraHandler = new PhoneCameraHandler(cam, settings);
            #endif

        }
        private void Update()
        {
            cameraHandler.Input();
        }

    }
}
