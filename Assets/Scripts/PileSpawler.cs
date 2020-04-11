using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileSpawler : MonoBehaviour
{

    public GameObject pilePrefab;
    public float speed;
    public float spawnTime;
    public float displayTime;
    public float randomHeight;
    private float currentTime;



    // Start is called before the first frame update
    void Start()
    {
        spawnPile();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= spawnTime)
        {
            spawnPile();
            currentTime = 0;
        }

    }

    void spawnPile()
    {
        GameObject pile = Instantiate(pilePrefab, new Vector3(4, 0.5f, -1), Quaternion.identity);
        pile.transform.position += new Vector3(0,
            //randomHeight
            Random.Range(-randomHeight, randomHeight)
            , 0);
        pile.GetComponent<Pile>().speed = speed;
        Destroy(pile, displayTime);
    }
}
