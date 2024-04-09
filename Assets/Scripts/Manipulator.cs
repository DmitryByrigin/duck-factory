using System.Collections;
using UnityEngine;

public class Manipulator : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip brokenSound;
    public float particleDuration = 3f;
    public Vector3 startPosition = new Vector3(0, 0.3f, 1.227249e-14f);
    public Vector3 endPosition = new Vector3(0.02381663f, 0.1334263f, -0.06912978f);
    public float moveTime = 2f;
    private bool hasActivated = false;

    void Start()
    {
        GameObject robotArmB = GameObject.Find("robot-arm");
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
        hasActivated = true;
        GameObject robotArmB = GameObject.Find("robot-arm");
        if (robotArmB != null)
        {
            ParticleSystem[] particles = robotArmB.GetComponentsInChildren<ParticleSystem>();
            foreach (ParticleSystem particleSystem in particles)
            {
                particleSystem.Play();
                StartCoroutine(StopParticlesAfterTime(particleSystem, particleDuration));
            }

            Transform elementD = robotArmB.transform.Find("element_a/element_b/element_c/element_d");
            if (elementD != null)
            {
                StartCoroutine(MoveOverTime(elementD, startPosition, endPosition, moveTime));
            }
        }

        if (audioSource != null && brokenSound != null)
        {
            audioSource.PlayOneShot(brokenSound);
        }
    }

    public bool HasActivated()
    {
        return hasActivated;
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
    public void StopAll()
    {
        StopAllCoroutines();
    }

}
