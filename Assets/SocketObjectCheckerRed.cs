using UnityEngine;

public class SocketObjectChecker : MonoBehaviour
{
    public GameObject currentObject; // Объект, который в данный момент находится в сокете

    public bool CheckObject(GameObject requiredObject)
    {
        if (currentObject == requiredObject)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
