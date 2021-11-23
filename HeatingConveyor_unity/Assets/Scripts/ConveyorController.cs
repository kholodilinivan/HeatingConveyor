using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    public LinearConveyor linearConveyor;

    public void SetState(bool state)
    {
        linearConveyor.enabled = state;
    }

    [ContextMenu("On")]
    private void On()
    {
        SetState(true);
    }

    [ContextMenu("Off")]
    private void Off()
    {
        SetState(false);
    }
}
