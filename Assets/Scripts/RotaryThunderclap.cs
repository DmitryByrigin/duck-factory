using System.Collections;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public string objectTag = "RotaryThunderclap";
    public float rotationSpeed = 0.5f; // Скорость вращения
    public Vector3 leftRotation = new Vector3(2.289f, 176.043f, 182.022f); // Позиция при максимальном повороте влево
    public Vector3 rightRotation = new Vector3(2.607f, 103.147f, 178.408f); // Позиция при максимальном повороте вправо

    void Start()
    {
        GameObject rotaryObject = GameObject.FindGameObjectWithTag(objectTag);
        if (rotaryObject != null)
        {
            StartCoroutine(RotateOverTime(rotaryObject.transform, leftRotation, rightRotation, rotationSpeed));
        }
    }

    IEnumerator RotateOverTime(Transform objectToRotate, Vector3 leftRotation, Vector3 rightRotation, float speed)
    {
        while (true)
        {
            // Вращаем объект влево
            for (float t = 0; t < 1; t += Time.deltaTime * speed)
            {
                objectToRotate.eulerAngles = Vector3.Lerp(rightRotation, leftRotation, t);
                yield return null;
            }

            // Вращаем объект вправо
            for (float t = 0; t < 1; t += Time.deltaTime * speed)
            {
                objectToRotate.eulerAngles = Vector3.Lerp(leftRotation, rightRotation, t);
                yield return null;
            }
        }
    }
}
