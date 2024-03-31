using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public TextMeshProUGUI taskText; // Ссылка на текстовый компонент вашего табло
    public int boxCount = 2; // Устанавливаем количество объектов с тегом Box равным 0

    void Start()
    {
        // Изначально задаем текст задания
        taskText.text = "1. Task, clear the room.";
    }

    void Update()
    {
        // Если количество активных объектов с тегом Box стало меньше или равно boxCount
        if (GameObject.FindGameObjectsWithTag("Box").Length <= boxCount)
        {
            // Обновляем текст задания
            taskText.text = "1. Task, clear the room.\n2. Task, insert the fuses into the shield.";
            boxCount = GameObject.FindGameObjectsWithTag("Box").Length; // Обновляем количество активных объектов с тегом Box
        }
    }
}
