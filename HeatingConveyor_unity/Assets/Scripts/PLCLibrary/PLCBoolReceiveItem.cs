using UnityEngine.Events;

public class PLCBoolReceiveItem : PLCReceiveItem
{
    public UnityEvent<bool> OnBoolReceive;

    public override void ChangeState(object value)
    {
        base.ChangeState(value);
        if (value != null)
        {
            OnBoolReceive?.Invoke((bool)value);
        }
    }
}
