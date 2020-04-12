using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float flapPower;
    public AudioClip flap;
    public AudioClip hit;
    public AudioClip score;
    public MainScript mainScript;


    private Rigidbody2D body;
    private Quaternion upRotation = Quaternion.Euler(0,0,45);
    private Quaternion downRotation = Quaternion.Euler(0, 0, -90);
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {  
        body = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(flap);
            transform.rotation = upRotation;
            body.AddForce(Vector2.up * flapPower);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.name == "PileScore")
        {
            Destroy (obj);
            audioSource.PlayOneShot(score);
            mainScript.AddScore();
        }
        else
        {
            StartCoroutine("OnDie");
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
