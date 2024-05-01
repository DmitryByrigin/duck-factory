using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class MusicButton : MonoBehaviour
{
    public AudioSource myMusic; // Ссылка на ваш AudioSource
    public RotateObject myRotateObject; // Ссылка на ваш RotateObject
    public GameObject myObject; // Ссылка на ваш объект

    private Coroutine rotationCoroutine; // Для хранения Coroutine

    void Start()
    {
        // Получаем компонент XRBaseInteractable кнопки
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();

        // Добавляем обработчик события при нажатии на кнопку
        interactable.selectEntered.AddListener(ToggleMusicAndRotation);
    }

    void ToggleMusicAndRotation(SelectEnterEventArgs args)
    {
        // При нажатии на кнопку переключаем музыку и объект
        if (myMusic.isPlaying)
        {
            myMusic.Stop();
            if (rotationCoroutine != null)
            {
                StopCoroutine(rotationCoroutine); // Останавливаем вращение
                rotationCoroutine = null;
            }
            myObject.SetActive(false); // Выключаем объект
        }
        else
        {
            myMusic.Play();
            if (rotationCoroutine == null)
            {
                // Начинаем вращение
                rotationCoroutine = StartCoroutine(myRotateObject.RotateOverTime(myRotateObject.transform, myRotateObject.leftRotation, myRotateObject.rightRotation, myRotateObject.rotationSpeed));
            }
            myObject.SetActive(true); // Включаем объект
        }
    }
}
