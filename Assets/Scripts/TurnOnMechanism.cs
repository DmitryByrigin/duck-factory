using System.Collections;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    public string boxTag = "Box";
    public Vector3 direction = Vector3.forward; // Направление движения
    public float moveDistance = 3f; // Расстояние на которое должна переместиться коробка
    public float moveTime = 2f; // Время за которое коробка должна переместиться
    public AudioSource audioSource; // Источник звука
    public AudioClip moveSound; // Звуковой клип

    public void MoveObject()
    {
        GameObject box = GameObject.FindGameObjectWithTag(boxTag);
        if (box != null)
        {
            StartCoroutine(MoveOverTime(box, direction, moveDistance, moveTime));
        }
    }

    IEnumerator MoveOverTime(GameObject objectToMove, Vector3 direction, float distance, float duration)
    {
        Vector3 startPosition = objectToMove.transform.position;
        Vector3 endPosition = startPosition + direction.normalized * distance;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            objectToMove.transform.position = Vector3.Lerp(startPosition, endPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        objectToMove.transform.position = endPosition;

        // Воспроизводим звук после перемещения
        if (audioSource != null && moveSound != null)
        {
            audioSource.PlayOneShot(moveSound);
        }
    }
}
