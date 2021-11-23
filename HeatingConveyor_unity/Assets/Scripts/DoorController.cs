
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject door;
    public float speed = 0.001f;

    public Vector3 maxPosition;
    public Vector3 minPosition;

    private bool up;
    private bool down;

    public void Up(bool state)
    {
        up = state;
    }

    public void Down(bool state)
    {
        down = state;
    }

    private void Update()
    {
        if (up && down)
        {
            Debug.LogError("[Door] ERROR");
        }

        if (up)
        {
            door.transform.localPosition = Vector3.MoveTowards(door.transform.localPosition, maxPosition, speed);
        }
        else if (down)
        {
            door.transform.localPosition = Vector3.MoveTowards(door.transform.localPosition, minPosition, speed);
        }
    }

    [ContextMenu("Up")]
    public void Up()
    {
        down = false;
        up = true;
    }

    [ContextMenu("Down")]
    public void Down()
    {
        up = false;
        down = true;
    }
}
