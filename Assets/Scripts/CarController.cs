using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject player;
    public JumpArea jumpArea;
    public TextMeshProUGUI crashScore;
    public TextMeshProUGUI jumpScore;

    public float speed = 0.3f;

    public bool isDead = false;

    Rigidbody rb;

    public float ragdollForce = 5f;
    public float ragdollTorque = 5f;

    private int framesToMove = 0;
    private Vector3 targetPosition;
    public float ragdollTime = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpArea.score = jumpScore;
    }

    public void OnDeath()
    {
        jumpArea.Detach();
        isDead = true;
        rb.constraints = RigidbodyConstraints.None;
        rb.AddForce(Vector3.up * ragdollForce, ForceMode.Impulse);
        rb.AddTorque(Vector3.right * ragdollTorque, ForceMode.Impulse);
        // remove collission from the car
        gameObject.layer = LayerMask.NameToLayer("Ragdoll");
        // start coroutine to destroy the car after a few seconds
        StartCoroutine(DestroyCar());
    }

    IEnumerator DestroyCar()
    {
        crashScore.GetComponent<JumpScore>().score += 10;
        yield return new WaitForSeconds(ragdollTime);
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (isDead)
            return;

        if (jumpArea.isAttached)
        {
            rb.drag = 1.2f;
            // select a random point in space and move the car towards it for X frames
            if (framesToMove > 0 && Vector2.Distance(new Vector2(transform.position.x, transform.position.z), targetPosition) > 10f)
            {
                targetPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.y);
                // move the car towards the target position
                rb.AddForce((targetPosition-transform.position).normalized * speed, ForceMode.Impulse);
                // rotate the car to look at the velocity direction
                transform.LookAt(transform.position + new Vector3(rb.velocity.x, transform.position.y, rb.velocity.z));
                // decrease the frames counter
                framesToMove--;
            }
            else
            {
                // select a new random point in space and reset the frames counter
                targetPosition = new Vector3(Random.Range(-400, 400), transform.position.y,  Random.Range(-400, 400));
                framesToMove = 400;
            }
        }
        else
        {
            rb.drag = 1f;
            // rotate the car to look at the player in the Y axis only
            Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

            // move the car towards the player 
            rb.AddForce((targetPosition-transform.position).normalized * speed, ForceMode.Impulse);

            // rotate the car to look at the velocity direction
            transform.LookAt(transform.position + new Vector3(rb.velocity.x, transform.position.y, rb.velocity.z));
        }
    }
}
