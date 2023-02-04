using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += 5 * new Vector3(x: transform.rotation.x, y: Input.GetAxis("Mouse X"));
        Quaternion rot = transform.rotation;
        rot.eulerAngles = new Vector3(0, rot.eulerAngles.y, 0);
        transform.rotation = rot;
    }
}
