using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spooky.Utilities.Effects
{
    public class CameraBillboard : MonoBehaviour
    {
        private void LateUpdate()
        {
            transform.forward = new Vector3(
                UnityEngine.Camera.main.transform.forward.x,
                transform.forward.y, 
                UnityEngine.Camera.main.transform.forward.z);
        }
    }
}