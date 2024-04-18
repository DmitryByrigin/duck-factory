using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LightColorChanger : MonoBehaviour
{
    public Light light1;
    public Light light2;
    public TextMeshProUGUI taskText;

    public SocketObjectChecker redSocket;
    public SocketObjectCheckerGreen greenSocket;
    public SocketObjectCheckerBlue blueSocket;

    public GameObject requiredObjectRed;
    public GameObject requiredObjectGreen;
    public GameObject requiredObjectBlue;

    public UnityEvent OnEnterEvent;
    private bool hasChangedColor = false;

    void Update()
    {
        if (!hasChangedColor && redSocket.CheckObject(requiredObjectRed) && greenSocket.CheckObject(requiredObjectGreen) && blueSocket.CheckObject(requiredObjectBlue))
        {
            hasChangedColor = true;

            OnEnterEvent.Invoke();
            if (light1 != null)
            {
                light1.color = Color.white;
                taskText.text = "                        1. Task, clear the room, using a machine.\n                        2. Task, insert the fuses into the shield.\n                        3. Task, clear the room by hands.";
            }

            if (light2 != null)
            {
                light2.color = Color.white;
            }
        }
    }
}
