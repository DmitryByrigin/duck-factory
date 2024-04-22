using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class AddOne : MonoBehaviour
{
    private TextMeshProUGUI tasks; // Ссылка на ваш TextMeshProUGUI
    private string password = ""; // Пароль

    void Start()
    {
        // Находим объект по тегу
        GameObject taskObject = GameObject.FindWithTag("Tablet");

        // Получаем компонент TextMeshProUGUI
        if (taskObject != null)
        {
            tasks = taskObject.GetComponent<TextMeshProUGUI>();
        }

        // Получаем компонент XRBaseInteractable кнопки
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();

        // Добавляем обработчик события при нажатии на кнопку
        interactable.selectEntered.AddListener(IncrementCount);
    }

    void IncrementCount(SelectEnterEventArgs args)
    {
        // Если уже введен правильный пароль, не добавляем цифру
        if (tasks.text == "DONE")
        {
            return;
        }

        // При нажатии на кнопку добавляем 1 к паролю
        password = tasks.text + "1";

        // Если пароль содержит более 4 символов, сбрасываем его
        if (password.Length > 4)
        {
            password = "";
        }

        // Обновляем текст на табло
        tasks.text = password;
    }
}
