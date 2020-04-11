using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject scoreObj;
    // Start is called before the first frame update
    void Start()
    {
        scoreObj.GetComponent<Text>().text = MainScript.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onClickPlay()
    {
        MainScript.score = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);

    }

}
