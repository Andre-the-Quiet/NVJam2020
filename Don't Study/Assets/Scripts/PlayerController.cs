using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator MyAnimator;
    public Rigidbody2D rb;
    public AudioClip[] FootstepAudio;
    public AudioSource Myaudio;
    public Animator transitionAnim;
    public string sceneName;

    public float MovementSpeed = 8f;
    
    Vector2 velocity;


    public GameObject taskPopup;
    bool canMove;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//defines the rigidbody we'll be using
        taskPopup.SetActive(false);
        canMove = true;
    }

    //all input here
    void Update()
    {

        if (canMove)
        {
            Vector2 MovementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            velocity = MovementDirection.normalized * MovementSpeed;

            MyAnimator.SetFloat("Horizontal", velocity.x);
            MyAnimator.SetFloat("Vertical", velocity.y);
            MyAnimator.SetFloat("Speed", velocity.sqrMagnitude);
        }
        else
        {
            velocity = Vector2.zero;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            canMove = false;
            MyAnimator.SetFloat("Speed", 0);
            taskPopup.GetComponent<TaskScript>().activate();
        }

    }

    //all movement here
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    void FootForward()
    {
        if (Mathf.Abs(velocity.x) <= Mathf.Abs(velocity.y))
        {
            int randomType = UnityEngine.Random.Range(0, 2);
            Myaudio.PlayOneShot(FootstepAudio[randomType]);
        }
    }

    void FootSide()
    {
        if (Mathf.Abs(velocity.x) >= Mathf.Abs(velocity.y))
        {
            int randomType = UnityEngine.Random.Range(0, 2);
            Myaudio.PlayOneShot(FootstepAudio[randomType]);
        }
    }

    public void move()
    {
        canMove = true;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == ("enemy")) 
        {
            StartCoroutine(LoadScene());
        }

    }
    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }


}
