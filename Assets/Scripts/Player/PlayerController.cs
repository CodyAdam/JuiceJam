using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class PlayerController : MonoBehaviour
{
    public bool isGrounded = false;

    public AudioSource soundtrack;
    public GameObject jumpVFX;
    public GameObject hitVFX;
    public Mesh tree3life;
    public Mesh tree2life;
    public Image deathFade;

    public Mesh tree1life;

    private int life = 3;

    public float force;
    public JumpTricks tree;
    public bool isSnapping = false;
    public AudioSource jumpSound;
    Rigidbody rb;

    public MeshFilter treeMeshFilter;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        treeMeshFilter.mesh = tree3life;
    }
    public void onJump()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        if (isGrounded && !isSnapping) //si on est pas sur le sol, la fonction le fait rien
        {
            jumpVFX.SetActive(true);
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

    public void OnHit()
    {
        hitVFX.SetActive(true);
        life--;
        if (life == 2)
        {
            treeMeshFilter.mesh = tree2life;
        }
        else if (life == 1)
        {
            treeMeshFilter.mesh = tree1life;
        }
        else if (life == 0)
        {
            soundtrack.volume = 0.001f;
            tree.gameObject.SetActive(false);
            gameObject.layer = LayerMask.NameToLayer("Ragdoll");
            deathFade.DOFade(1, 6f).OnComplete(() => SceneManager.LoadScene("EndScene"));
        }

    }

}
