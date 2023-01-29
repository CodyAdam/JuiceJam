using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float rotX;
    float rotZ;
    // Start is called before the first frame update
    void Start()
    {
        rotX = transform.rotation.x;
        rotZ = transform.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.eulerAngles += 5 * new Vector3(x: transform.rotation.x, y: Input.GetAxis("Mouse X"));
        }
    }
}
