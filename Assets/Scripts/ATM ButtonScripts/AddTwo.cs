using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using TMPro;

public class AddTwo : MonoBehaviour
{
    private TextMeshProUGUI tasks; // Ссылка на ваш TextMeshProUGUI

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
        if (tasks.text == "DONE")
        {
            return;
        }

        // При нажатии на кнопку добавляем 2 к паролю
        string password = tasks.text + "2";

        // Если пароль содержит более 4 символов, сбрасываем его
        if (password.Length > 4)
        {
            password = "";
        }

        // Обновляем текст на табло
        if (tasks != null)
        {
            tasks.text = password;
        }
    }
}
