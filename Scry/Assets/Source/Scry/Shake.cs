using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    private Vector3 initialPosition;
    public float shakeMagnitude;

    private void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    private void OnDisable()
    {
        transform.localPosition = initialPosition;
    }

    // Update is called once per frame
    public void Update()
    {
        transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
    }
}
