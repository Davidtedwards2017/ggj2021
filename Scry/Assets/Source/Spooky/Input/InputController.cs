using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

namespace Spooky.Input
{
    public class InputController : Singleton<InputController>
    {
        public const float ANALOG_DEAD_ZONE = 0.35f;

        public InputDevice GetInputDevice(int deviceIndex)
        {
            if (InputManager.Devices.Count < deviceIndex + 1) return null;
            return InputManager.Devices[deviceIndex];
        }

        public Vector3 GetInputDirection(int deviceIndex)
        {
            return GetInputDirection(GetInputDevice(deviceIndex));
        }

        public Vector3 GetInputDirection(InputDevice device)
        {
            if (device == null)
            {
                return Vector3.zero;
            }

            Vector3 direction = Vector3.zero;

            float x = device.Direction.X;
            float y = device.Direction.Y;

            if (y > ANALOG_DEAD_ZONE)
            {
                direction.y = 1;
            }
            else if (y < -ANALOG_DEAD_ZONE)
            {
                direction.y = -1;
            }

            if (x > ANALOG_DEAD_ZONE)
            {
                direction.x = 1;
            }
            else if (x < -ANALOG_DEAD_ZONE)
            {
                direction.x = -1;
            }

            return direction;
        }
    }
}