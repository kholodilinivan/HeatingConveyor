using System.Dynamic;

using UnityEngine;

public class Element : MonoBehaviour
{
    [SerializeField]
    public Rigidbody rb;

    [SerializeField]
    public Transform pivot;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public Vector3 GetCoordinate()
    {
        return pivot.transform.position;
    }
}

