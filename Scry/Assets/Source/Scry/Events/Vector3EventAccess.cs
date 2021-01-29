using UnityEngine;

public class Vector3EventAccess : MonoBehaviour
{
    public Vector3 Value;
    public Vector3EventSO Invoker;
    public void Invoke()
    {
        Invoker.Raise(Value);
    }
}
