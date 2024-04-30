using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class StartGameEffects : MonoBehaviour
{
    public AudioSource ringingSound; // Звук звонка
    private GameObject screenTelefon; // Экран телефона
    private Color originalColor; // Исходный цвет экрана
    private XRSocketInteractor socketInteractor; // Скрипт XR Socket Interactor
    private Coroutine blinkCoroutine; // Корутина мигания экрана
    public UnityEvent OnEnterEvent;

    void Start()
    {
        screenTelefon = GameObject.FindGameObjectWithTag("ScreenTelefon");
        originalColor = screenTelefon.GetComponent<Renderer>().material.color;


        // Воспроизвести звук звонка
        ringingSound.loop = true; // Звук будет повторяться
        ringingSound.Play();


        // Начать мигание экрана
        blinkCoroutine = StartCoroutine(BlinkScreen());

        // Получить скрипт XR Socket Interactor
        GameObject phoneSocket = GameObject.FindGameObjectWithTag("PhoneSocket");
        if (phoneSocket != null)
        {
            socketInteractor = phoneSocket.GetComponent<XRSocketInteractor>();
            if (socketInteractor != null)
            {
                socketInteractor.hoverExited.AddListener(StopRinging);
            }
            else
            {
                Debug.LogError("PhoneSocket object does not have XRSocketInteractor component.");
            }
        }
        else
        {
            Debug.LogError("No object with tag PhoneSocket found.");
        }
    }

    IEnumerator BlinkScreen()
    {
        while (true)
        {
            screenTelefon.GetComponent<Renderer>().material.color = Color.green;
            yield return new WaitForSeconds(0.5f);
            screenTelefon.GetComponent<Renderer>().material.color = originalColor;
            yield return new WaitForSeconds(0.5f);
        }
    }

    void StopRinging(HoverExitEventArgs args)
    {
        OnEnterEvent.Invoke();
        // Остановить звук звонка
        ringingSound.Stop();

        // Остановить мигание экрана и вернуть исходный цвет
        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
            screenTelefon.GetComponent<Renderer>().material.color = originalColor;
        }
    }
}
