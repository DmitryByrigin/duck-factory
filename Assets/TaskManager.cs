using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TaskManager : MonoBehaviour
{
    public UnityEvent OnEnterEvent;
    public TextMeshProUGUI taskText;
    public int boxCount = 2;

    void Start()
    {
        taskText.text = "                        1. Task, clear the room, using a machine.";
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Box").Length <= boxCount)
        {
            OnEnterEvent.Invoke();
            taskText.text = "                        1. Task, clear the room, using a machine.\n                        2. Task, insert the fuses into the shield.\n                        3. Task, clear the room by hands.\n                        4. Enter the code about the execution of tasks in ATM.";
            boxCount = GameObject.FindGameObjectsWithTag("Box").Length;
        }
    }
}
