using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightSwitch : MonoBehaviour
{
    public string lightTag = "Light";
    private bool isLightOn = true;

    public void ToggleLight()
    {
        GameObject[] lights = GameObject.FindGameObjectsWithTag(lightTag);
        foreach (GameObject light in lights)
        {
            Light lightComponent = light.GetComponent<Light>();
            if (lightComponent != null)
            {
                lightComponent.enabled = !isLightOn;
                Debug.Log("Состояние света для " + light.name + ": " + lightComponent.enabled);
            }
        }
        isLightOn = !isLightOn;
        Debug.Log("Общее состояние света: " + isLightOn);
    }
}

