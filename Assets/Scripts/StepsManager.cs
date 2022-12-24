using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsManager : MonoBehaviour
{
    public GameObject footPrint1;
    public GameObject footPrint2;

    private Animator f1;
    private Animator f2;

    // Start is called before the first frame update
    void Start()
    {
        f1 = footPrint1.GetComponent<Animator>();
        f2 = footPrint2.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateFootPrint(int steps)
    {
        f1.SetBool("white", getBit(steps, 1));
        f2.SetBool("white", getBit(steps, 0));
    }

    bool getBit(int steps, int bitNumber)
    {
        return ((steps >> bitNumber) & 1) != 0;
    }

}
