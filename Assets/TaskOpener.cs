using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TaskOpener : MonoBehaviour
{
    public GameObject tasks; // Ссылка на ваше табло

    void Start()
    {
        // Получаем компонент XRBaseInteractable кнопки
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();

        // Добавляем обработчик события при нажатии на кнопку
        interactable.selectEntered.AddListener(ToggleTasks);
    }

    void ToggleTasks(SelectEnterEventArgs args)
    {
        // При нажатии на кнопку переключаем видимость табло
        tasks.SetActive(!tasks.activeSelf);
    }
}
