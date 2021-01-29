using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilites
{
    public static class LayerExtensions
    {
        public static int ToLayer(this LayerMask layerMask)
        {
            int layerNumber = 0;
            int layer = layerMask.value;
            while (layer > 0)
            {
                layer = layer >> 1;
                layerNumber++;
            }
            return layerNumber - 1;
        }
    }
}