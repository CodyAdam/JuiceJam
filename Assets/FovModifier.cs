using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovModifier : MonoBehaviour
{
    public float minFov = 15f;
    public float maxFov = 120f;

    public float speedToMaxFov = 10f;

    public Cinemachine.CinemachineVirtualCamera cam;
    private Rigidbody rb;

    public float lerpSpeed = 0.1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {    
        GameObject current = gameObject;
        float speed = rb.velocity.magnitude;
        while (current.transform.parent != null)
        {
            current = current.transform.parent.gameObject;
            if (current.GetComponent<Rigidbody>() != null)
            {
                speed += current.GetComponent<Rigidbody>().velocity.magnitude;
            }
        }
        float fov = Mathf.Lerp(minFov, maxFov, speed / speedToMaxFov);

        cam.m_Lens.FieldOfView = Mathf.Lerp(cam.m_Lens.FieldOfView, fov, lerpSpeed);
    }

}
