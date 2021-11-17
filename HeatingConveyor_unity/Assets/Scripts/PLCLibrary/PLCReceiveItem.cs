
using UnityEngine;
using UnityEngine.Events;

public class PLCReceiveItem : MonoBehaviour
{
    public PLCDataItem data;
    public UnityEvent<object?> OnValueReceive;

    public virtual void ChangeState(object? value)
    {
        OnValueReceive?.Invoke(value);
    }
}
