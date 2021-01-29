using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scry/Events/Vector3")]
public class Vector3EventSO : ScriptableObject
{
    public Vector3Event Event = new Vector3Event();

    public void Raise(Vector3 value)
    {
        if (Event != null)
        {
            Event.Invoke(value);
        }
    }
}

public class Vector3Event : UnityEvent<Vector3> { }
