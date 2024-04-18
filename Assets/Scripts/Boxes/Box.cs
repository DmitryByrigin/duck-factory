using UnityEngine;
using System.Collections.Generic;

public class Box : MonoBehaviour
{
    public static List<Box> ActiveBoxes = new List<Box>();

    private void OnEnable()
    {
        ActiveBoxes.Add(this);
    }

    private void OnDisable()
    {
        ActiveBoxes.Remove(this);
    }
}
