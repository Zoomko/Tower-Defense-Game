using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.CameraController
{
    public class CameraHandlerSettings
    {               
        public readonly float highZoomValue;
        public readonly float lowZoomValue;
        public readonly float speedOfTranslating;
        public CameraHandlerSettings(float lowZoomValue,float highZoomValue, float speedOfTranslating)
        {
            this.highZoomValue = highZoomValue;
            this.lowZoomValue = lowZoomValue;
            this.speedOfTranslating = speedOfTranslating;
        }
    }
}
