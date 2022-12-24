using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{

    public GameObject scoreObj;
    public static int score;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void AddScore()
    {
        score++;
        scoreObj.GetComponent<Text>().text = score.ToString();
    }

}
