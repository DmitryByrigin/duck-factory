using TMPro;
using UnityEngine;

public class OneTimeManipulator : MonoBehaviour
{
    public Manipulator manipulator;
    public TextMeshProUGUI taskText;
    public Light light1;
    public Light light2;
    private bool hasActivated = false;

    void Update()
    {
        if (!hasActivated && manipulator != null && manipulator.HasActivated())
        {
            hasActivated = true;
            manipulator.StopAll();
            manipulator.enabled = false;

            if (light1 != null)
            {
                light1.color = Color.red;
                light1.intensity *= 5;
                taskText.text = "1. Task, clear the room, using a machine.\n2. Task, insert the fuses into the shield.\n";

            }

            if (light2 != null)
            {
                light2.color = Color.red;
                light2.intensity *= 5;
            }

        }
    }
}
