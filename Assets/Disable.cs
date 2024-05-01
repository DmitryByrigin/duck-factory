using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    public GameObject myObject;
    
    // Start is called before the first frame update
    void Start()
    {
        myObject.GetComponent<Renderer>().enabled = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
