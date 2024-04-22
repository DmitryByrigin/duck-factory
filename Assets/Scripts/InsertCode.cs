using UnityEngine;
using UnityEngine.UI; // Добавьте это для доступа к компоненту Image
using TMPro;
using System.Collections; // Добавьте это для использования корутин

public class PasswordChecker : MonoBehaviour
{
    private TextMeshProUGUI tasks; // Ссылка на ваш TextMeshProUGUI
    private Image partitionImage; // Ссылка на компонент Image вашей перегородки

    void Start()
    {
        // Находим объект по тегу
        GameObject taskObject = GameObject.FindWithTag("Tablet");
        GameObject partitionObject = GameObject.FindWithTag("Partition");

        // Получаем компонент TextMeshProUGUI
        if (taskObject != null)
        {
            tasks = taskObject.GetComponent<TextMeshProUGUI>();
        }

        // Получаем компонент Image
        if (partitionObject != null)
        {
            partitionImage = partitionObject.GetComponent<Image>();
        }
    }

    void Update()
    {
        // Проверяем, соответствует ли введенный пароль правильному
        if (tasks != null && tasks.text == "1222")
        {
            Debug.Log("Правильный пароль введен!");
            tasks.text = "DONE"; // Устанавливаем текст на "DONE"
            tasks.fontStyle = FontStyles.Bold; // Делаем текст жирным

            // Если у перегородки есть компонент Image, меняем его цвет на темно-зеленый
            if (partitionImage != null)
            {
                partitionImage.color = new Color(0, 0.5f, 0); // Темно-зеленый цвет
            }

            // Запускаем корутину для мигания текста
            StartCoroutine(FlashText());
        }
    }

    IEnumerator FlashText()
    {
        while (true)
        {
            // Мигаем текстом
            tasks.enabled = !tasks.enabled;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
