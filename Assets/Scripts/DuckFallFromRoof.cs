using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    public GameObject duckPrefab; // Префаб утки
    public int numberOfDucks = 10; // Количество уток
    public float spawnRate = 1f; // Скорость появления уток
    public float rotationSpeed = 20f; // Скорость вращения уток

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            for (int i = 0; i < numberOfDucks; i++)
            {
                SpawnDuck();
            }
            nextSpawnTime = Time.time + 1f / spawnRate;
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
    }
}
