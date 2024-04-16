using TMPro;
using UnityEngine;

public class LightColorChanger : MonoBehaviour
{
    public Light light1;
    public Light light2;
    public TextMeshProUGUI taskText;

    public SocketObjectChecker redSocket;
    public SocketObjectCheckerGreen greenSocket;
    public SocketObjectCheckerBlue blueSocket;

    public GameObject requiredObjectRed; // Объект, который должен быть вставлен в RedSocket
    public GameObject requiredObjectGreen; // Объект, который должен быть вставлен в GreenSocket
    public GameObject requiredObjectBlue; // Объект, который должен быть вставлен в BlueSocket

    private bool hasChangedColor = false; // Добавляем новую переменную, чтобы отслеживать, был ли уже изменен цвет света

    void Update()
    {
        if (!hasChangedColor && redSocket.CheckObject(requiredObjectRed) && greenSocket.CheckObject(requiredObjectGreen) && blueSocket.CheckObject(requiredObjectBlue))
        {
            hasChangedColor = true; // Устанавливаем переменную в true, чтобы цвет света менялся только один раз

            if (light1 != null)
            {
                light1.color = Color.white;
                taskText.text = "1. Task, clear the room, using a machine.\n2. Task, insert the fuses into the shield.\n3. Task, clear the room by hands.";
            }

            if (light2 != null)
            {
                light2.color = Color.white;
            }
        }
    }
}
