
using System;

using UnityEngine;

public class PLCSendItem : MonoBehaviour
{
    public PLCDataItem data;
    public event Action<object?, PLCDataItem> OnValueChange;

    public void ChangeState(object? value)
    {
        OnValueChange?.Invoke(value, data);
    }
}
