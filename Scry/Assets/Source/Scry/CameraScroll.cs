using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraScroll : MonoBehaviour
{
    public GameSettingSO Settings;
    public Vector3EventSO CameraScrollEvent;
    
    private Vector3 targetPosition;

    private void Update()
    {
        if (!Settings.GameStarted) return;

        var mousePos = Input.mousePosition;
        var distanceFromCenter = Mathf.Abs((Screen.width / 2) - mousePos.x);

        if (distanceFromCenter > Settings.CameraMouseDeadzoneDistance)
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            UpdateTargetPosition(mouseWorldPosition);
        }   
        
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            Settings.CameraScrollingSpeed * Time.deltaTime);
    }

    public void OnEnable()
    {
        Reset();
        CameraScrollEvent.Event.AddListener(Scroll);
    }

    public void OnDisable()
    {
        CameraScrollEvent.Event.RemoveListener(Scroll);
    }

    public void Reset()
    {
        UpdateTargetPosition(Settings.CameraCenter);
    }

    private void UpdateTargetPosition(Vector3 pos)
    {
        var clampedPos = new Vector3()
        {
            x = Mathf.Clamp(pos.x, Settings.CameraLeftBounds, Settings.CameraRightBounds),
            y = Settings.CameraCenter.y,
            z = Settings.CameraCenter.z
        };

        targetPosition = clampedPos;
    }

    public void Scroll(Vector3 direction)
    {
        direction = direction.normalized;
        var startingPos = transform.position;

        var newPos = Vector3.Lerp(
            startingPos,
            startingPos + (direction * Settings.CameraScrollingSpeed),
            Time.deltaTime);


        newPos.x = Mathf.Clamp(newPos.x, Settings.CameraLeftBounds, Settings.CameraRightBounds);
    }
}
