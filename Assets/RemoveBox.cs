using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBox : MonoBehaviour
{

    private void Start()
    {
        GetComponent<TriggerZone>().OnEnterEvent.AddListener(InsideConveyor);
    }
    public void InsideConveyor(GameObject go)
    {
        go.SetActive(false);
    }
}
