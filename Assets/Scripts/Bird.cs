using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float flapPower;

    private Rigidbody2D body;

    public MainScript mainScript;

    private Quaternion upRotation = Quaternion.Euler(0,0,45);
    private Quaternion downRotation = Quaternion.Euler(0, 0, -90);

    // Start is called before the first frame update
    void Start()
    {
        
        body = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
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
            mainScript.AddScore();
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }
}
