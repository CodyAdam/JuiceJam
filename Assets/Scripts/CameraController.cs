using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.eulerAngles += 5 * new Vector3(x: -Input.GetAxis("Mouse Y"), y: Input.GetAxis("Mouse X"));
        }
    }
}
