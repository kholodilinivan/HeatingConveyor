using UnityEngine.Events;

public class PLCFloatReceiveItem : PLCReceiveItem
{
    public UnityEvent<float> OnFloatReceive;

    public override void ChangeState(object value)
    {
        base.ChangeState(value);
        if (value != null)
        {
            OnFloatReceive?.Invoke((float)value);
        }
    }
}