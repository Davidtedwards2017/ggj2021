using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scry/Settings")]
public class GameSettingSO : ScriptableObject
{
    [Header("Camera")]
    public float CameraScrollingSpeed = 1;
    public float MouseDeadZone = 1;
    public float CameraMouseDeadzoneDistance = 50;
    public Vector3 CameraCenter = Vector3.zero;
    public float CameraLeftBounds;
    public float CameraRightBounds;

    [Header("Tags")]
    public const string TAG_REAGENT = "Reagent";
    public const string TAG_CAULDRON = "Cauldron";
}
