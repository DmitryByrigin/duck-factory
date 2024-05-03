using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class DuckSpawner : MonoBehaviour
{
    public GameObject duckPrefab;
    public int numberOfDucks = 10;
    public float spawnRate = 1f; 
    public float rotationSpeed = 20f; 
    public float fadeInTime = 3.0f; 
    public TextMeshProUGUI endText;
    public AudioClip quackSound; 
    private float nextSpawnTime;
    private bool textShown = false; 

    void Start()
    {
        if (endText != null)
        {
            endText.color = new Color(endText.color.r, endText.color.g, endText.color.b, 0f);
        }
      
    }

    void Update()
    {
        GameObject[] roofs = GameObject.FindGameObjectsWithTag("Roof");
        if (Time.time >= nextSpawnTime)
        {
            for (int i = 0; i < numberOfDucks; i++)
            {
                SpawnDuck();
            }
            nextSpawnTime = Time.time + 1f / spawnRate;
            if (!textShown && roofs.Length > 0) 
            {
                StartCoroutine(ShowEndTextAfterDelay(3f));
                textShown = true; 
            }
        }
    }

    void SpawnDuck()
    {

        GameObject[] roofs = GameObject.FindGameObjectsWithTag("Roof");

        if (roofs.Length == 0)
        {
            return;
        }


        GameObject roof = roofs[Random.Range(0, roofs.Length)];


        Renderer roofRenderer = roof.GetComponent<Renderer>();
        Vector3 roofSize = roofRenderer.bounds.size;


        Vector3 spawnPosition = roof.transform.position + new Vector3(
            Random.Range(-roofSize.x / 2, roofSize.x / 2),
            0,
            Random.Range(-roofSize.z / 2, roofSize.z / 2)
        );


        GameObject duck = Instantiate(duckPrefab, spawnPosition, Quaternion.identity);


        duck.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * rotationSpeed;


        duck.GetComponent<Rigidbody>().AddForce(Vector3.down * 0.01f, ForceMode.Impulse);


        StartCoroutine(PlayQuackSound(duck));
    }

    IEnumerator PlayQuackSound(GameObject duck)
    {
        yield return new WaitForSeconds(0.5f); 

        AudioSource audioSource = duck.AddComponent<AudioSource>();
        audioSource.clip = quackSound;
        audioSource.volume = Random.Range(0.3f, 0.8f) / 25;
        audioSource.Play();
    }



    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeInTime)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeInTime);
            endText.color = new Color(endText.color.r, endText.color.g, endText.color.b, alpha);
            yield return null;
        }
    }

    IEnumerator ShowEndTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        endText.text = "THE END!"; 
        StartCoroutine(FadeIn());
        StartCoroutine(GoToStartSceneAfterDelay(28f));
    }

    IEnumerator GoToStartSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("1 Start Scene");
    }
}
