using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // Ссылки на объекты с разными цветами
    public GameObject redObject;
    public GameObject blueObject;
    public GameObject greenObject;

    void Start()
    {
        // Получите рендерер объекта
        Renderer rend = GetComponent<Renderer>();

        // Определите цвет объекта на основе его ссылки
        if (gameObject == redObject)
        {
            rend.material.color = Color.red;
        }
        else if (gameObject == blueObject)
        {
            rend.material.color = Color.blue;
        }
        else if (gameObject == greenObject)
        {
            rend.material.color = Color.green;
        }
        else
        {
            Debug.LogWarning("Unknown object color");
        }
    }
}
