using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float xLimitLeft = -10.0f;
public float xLimitRight = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
void Update() {
    float xPosition = Mathf.Clamp(transform.position.x, xLimitLeft, xLimitRight);
    transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
}

}
