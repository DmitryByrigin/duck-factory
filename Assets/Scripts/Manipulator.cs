using System.Collections;
using UnityEngine;

public class Manipulator : MonoBehaviour
{
    public AudioSource audioSource; // Источник звука
    public AudioClip brokenSound; // Звук сломанного манипулятора
    public float particleDuration = 3f; // Продолжительность воспроизведения частиц
    public Vector3 startPosition = new Vector3(0, 0.3f, 1.227249e-14f); // Начальная позиция
    public Vector3 endPosition = new Vector3(0.02381663f, 0.1334263f, -0.06912978f); // Конечная позиция
    public float moveTime = 2f; // Время перемещения

    void Start()
    {
        // Отключаем все системы частиц при запуске игры
        GameObject robotArmB = GameObject.Find("robot-arm-b");
        if (robotArmB != null)
        {
            ParticleSystem[] particles = robotArmB.GetComponentsInChildren<ParticleSystem>();
            foreach (ParticleSystem particleSystem in particles)
            {
                particleSystem.Stop();
            }
        }
    }

    public void ActivateParticlesAndSound()
    {
        GameObject robotArmB = GameObject.Find("robot-arm-b");
        if (robotArmB != null)
        {
            ParticleSystem[] particles = robotArmB.GetComponentsInChildren<ParticleSystem>();
            foreach (ParticleSystem particleSystem in particles)
            {
                particleSystem.Play();
                StartCoroutine(StopParticlesAfterTime(particleSystem, particleDuration));
            }

            // Находим объект element_d и начинаем корутину для перемещения
            Transform elementD = robotArmB.transform.Find("element_a/element_b/element_c/element_d");
            if (elementD != null)
            {
                StartCoroutine(MoveOverTime(elementD, startPosition, endPosition, moveTime));
            }
        }

        // Воспроизводим звук сломанного манипулятора
        if (audioSource != null && brokenSound != null)
        {
            audioSource.PlayOneShot(brokenSound);
        }
    }

    IEnumerator MoveOverTime(Transform objectToMove, Vector3 startPosition, Vector3 endPosition, float duration)
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            objectToMove.localPosition = Vector3.Lerp(startPosition, endPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        objectToMove.localPosition = endPosition;

        // Перемещаем объект обратно на начальную позицию
        elapsed = 0.0f;
        while (elapsed < duration)
        {
            objectToMove.localPosition = Vector3.Lerp(endPosition, startPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        objectToMove.localPosition = startPosition;
    }

    IEnumerator StopParticlesAfterTime(ParticleSystem particleSystem, float delay)
    {
        yield return new WaitForSeconds(delay);
        particleSystem.Stop();
    }
}
