using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public bool isGrounded = false;
    public float force;
    public JumpTricks tree;
    public bool isSnapping = false;
    public AudioSource jumpSound;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void onJump()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        if (isGrounded && !isSnapping) //si on est pas sur le sol, la fonction le fait rien
        {
            jumpSound.gameObject.GetComponent<SfxRandomPitch>().ChangePitch();
            jumpSound.Play();

            Vector3 newVelocity = rb.velocity;
            newVelocity.y = 0;
            rb.velocity = newVelocity;
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            tree.DoJumpTrick();
            isGrounded = false;
        }
    }

    public void OnDeath()
    {
        // wait for the animation to finish
        // then load the end scene
        return;
        Rigidbody treeRb = tree.GetComponent<Rigidbody>();
        treeRb.constraints = RigidbodyConstraints.None;
        rb.AddForce(Vector3.up * force * 3, ForceMode.Impulse);
        treeRb.AddTorque(Vector3.up * force + Vector3.right * 1.3f * force, ForceMode.Impulse);
        tree.gameObject.layer = LayerMask.NameToLayer("Ragdoll");
        StartCoroutine(DeathAnimation());
    }

    private IEnumerator DeathAnimation()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("EndScene");
    }
}
