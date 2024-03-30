using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public string taskObjectName = "Text"; // Имя вашего объекта Text
    private Text taskText; // Ссылка на текстовый компонент вашего табло
    private int boxCount = 2; // Устанавливаем количество объектов с тегом Box равным 2

    void Start()
    {
        // Находим объект Text
        GameObject taskObject = GameObject.Find(taskObjectName);
        if (taskObject != null)
        {
            taskText = taskObject.GetComponent<Text>();
        }

        // Если компонент Text не найден, выводим ошибку
        if (taskText == null)
        {
            Debug.LogError("Task Text component not found on object " + taskObjectName);
            return;
        }

        // Изначально задаем текст задания
        taskText.text = "1. Task, clear the room.";
    }

    void Update()
    {
        // Если количество активных объектов с тегом Box стало меньше boxCount
        if (Box.ActiveBoxes.Count <= boxCount)
        {
            // Обновляем текст задания
            taskText.text = "1. Task, clear the room.\n2. Task, insert the fuses into the shield.";
            boxCount = Box.ActiveBoxes.Count; // Обновляем количество активных объектов с тегом Box
        }
    }
}
