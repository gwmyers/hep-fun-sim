using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialStateA : MonoBehaviour
{
    public GameObject ProtonBunchA;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            rb.velocity = new Vector3(10, 0, 0);
        }
    }
}
