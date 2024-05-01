using UnityEngine;
using UnityEngine.UI; // Добавьте это для доступа к компоненту Image
using TMPro;
using System.Collections;
using UnityEngine.Events; // Добавьте это для использования корутин

public class PasswordChecker : MonoBehaviour
{
    private TextMeshProUGUI tasks; // Ссылка на ваш TextMeshProUGUI
    private Image partitionImage; // Ссылка на компонент Image вашей перегородки
    public UnityEvent OnEnterEvent;
    public TextMeshProUGUI taskText;


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
        if (tasks != null && (tasks.text == "1222" || tasks.text == "DONE"))
        {
            taskText.text = "                        1. Task, clear the room, using a machine.\n                        2. Task, insert the fuses into the shield.\n                        3. Task, clear the room by hands.\n                        4. Enter the code about the execution of tasks in ATM\n                        5. Use knive to cut the box.";
            OnEnterEvent.Invoke();

            Debug.Log(taskText.text);
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
