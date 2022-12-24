using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public float flapPower;
    public AudioClip flap;
    public AudioClip hit;
    public AudioClip score;

    public StepsManager stepsManager;
    public MainScript mainScript;


    private Rigidbody2D body;
    private Quaternion upRotation = Quaternion.Euler(0, 0, 45);
    private Quaternion downRotation = Quaternion.Euler(0, 0, -60);
    private AudioSource audioSource;
    private Animator animator;

    private int steps = 2;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && steps != 0)
        {
            if (steps == 2)
            {
                stepsManager.updateFootPrint(0b01);
            }
            else
            {
                stepsManager.updateFootPrint(0b11);
            }
            steps--;
            audioSource.PlayOneShot(flap);
            body.AddForce(Vector2.up * flapPower);
            transform.rotation = upRotation;
            animator.SetTrigger("jump");
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, Time.deltaTime);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.name == "Ground")
        {
            StartCoroutine("OnDie");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.name == "PileScore")
        {
            steps = 2;
            stepsManager.updateFootPrint(0b00);
            Destroy(obj);
            audioSource.PlayOneShot(score);
            mainScript.AddScore();
        }
    }
   

    private IEnumerator OnDie()
    {
        Time.timeScale = 0.01f;
        audioSource.PlayOneShot(hit);
        yield return new WaitForSeconds(0.005f);
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
