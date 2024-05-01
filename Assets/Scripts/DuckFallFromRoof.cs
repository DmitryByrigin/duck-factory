using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class DuckSpawner : MonoBehaviour
{
    public GameObject duckPrefab; // Префаб утки
    public int numberOfDucks = 10; // Количество уток
    public float spawnRate = 1f; // Скорость появления уток
    public float rotationSpeed = 20f; // Скорость вращения уток
    public float fadeInTime = 3.0f; // Время для появления текста
    public TextMeshProUGUI endText; // Объект TextMeshPro
    public AudioClip quackSound; // Звук крякания утки

    private float nextSpawnTime;
    private bool textShown = false; // Был ли текст уже показан

    void Start()
    {
        if (endText != null)
        {
            endText.color = new Color(endText.color.r, endText.color.g, endText.color.b, 0f); // Начинаем с полностью прозрачного текста
        }
      
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            for (int i = 0; i < numberOfDucks; i++)
            {
                SpawnDuck();
            }
            nextSpawnTime = Time.time + 1f / spawnRate;
            if (!textShown) // Если текст еще не был показан
            {
                StartCoroutine(ShowEndTextAfterDelay(3f)); // Запускаем корутину с задержкой в 1 секунду
                textShown = true; // Устанавливаем флаг, что текст был показан
            }
        }
    }

    void SpawnDuck()
    {
        // Находим все объекты с тегом Roof
        GameObject[] roofs = GameObject.FindGameObjectsWithTag("Roof");

        // Выбираем случайную крышу
        GameObject roof = roofs[Random.Range(0, roofs.Length)];

        // Получаем размеры крыши
        Renderer roofRenderer = roof.GetComponent<Renderer>();
        Vector3 roofSize = roofRenderer.bounds.size;

        // Генерируем случайную позицию вокруг крыши
        Vector3 spawnPosition = roof.transform.position + new Vector3(
            Random.Range(-roofSize.x / 2, roofSize.x / 2),
            0,
            Random.Range(-roofSize.z / 2, roofSize.z / 2)
        );

        // Создаем утку на крыше
        GameObject duck = Instantiate(duckPrefab, spawnPosition, Quaternion.identity);

        // Добавляем вращение утке
        duck.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * rotationSpeed;

        // Добавляем силу, чтобы утка падала вниз
        duck.GetComponent<Rigidbody>().AddForce(Vector3.down * 0.01f, ForceMode.Impulse);

        // Воспроизводим звук крякания утки с задержкой и случайной громкостью
        StartCoroutine(PlayQuackSound(duck));
    }

    IEnumerator PlayQuackSound(GameObject duck)
    {
        yield return new WaitForSeconds(0.5f); // Задержка в полсекунды

        AudioSource audioSource = duck.AddComponent<AudioSource>();
        audioSource.clip = quackSound;
        audioSource.volume = Random.Range(0.3f, 0.8f); // Случайная громкость от 30% до 100%
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

        endText.text = "THE END!"; // Устанавливаем текст в "THE END!"
        StartCoroutine(FadeIn());
        StartCoroutine(GoToStartSceneAfterDelay(15f)); // Запускаем корутину с задержкой в 10 секунд
    }

    IEnumerator GoToStartSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("1 Start Scene"); // Загружаем сцену "Start Scene"
    }
}
