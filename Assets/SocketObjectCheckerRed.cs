using UnityEngine;

public class SocketObjectChecker : MonoBehaviour
{
    public GameObject currentObject; // Объект, который в данный момент находится в сокете

    void Start()
    {
        currentObject = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        currentObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == currentObject)
        {
            currentObject = null;
        }
    }

    public bool CheckObject(GameObject requiredObject)
    {
        return currentObject == requiredObject;
    }
}
