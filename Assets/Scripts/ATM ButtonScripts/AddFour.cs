using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class AddFour : MonoBehaviour
{
    private TextMeshProUGUI tasks;

    void Start()
    {
        GameObject taskObject = GameObject.FindWithTag("Tablet");
        if (taskObject != null)
        {
            tasks = taskObject.GetComponent<TextMeshProUGUI>();
        }

        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        interactable.selectEntered.AddListener(IncrementCount);
    }

    void IncrementCount(SelectEnterEventArgs args)
    {
        if (tasks.text == "DONE")
        {
            return;
        }

        string password = tasks.text + "4";
        tasks.text = password.Length <= 4 ? password : "";
    }
}