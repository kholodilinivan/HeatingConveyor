
using UnityEngine;

public class ElementSpawner : MonoBehaviour
{
    public Transform spawnPoint;

    public Element element;
    private Element lastElement;

    public float delta = 0.82f;

    private void Update()
    {
        if (lastElement != null && Vector3.Distance(spawnPoint.position, lastElement.transform.position) < delta)
            return;

        Create();
    }

    private void Create()
    {
        lastElement = Instantiate(element, spawnPoint);
        lastElement.transform.localPosition = Vector3.zero;
    }
}
