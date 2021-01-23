using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtonInitialState : MonoBehaviour
{
    // our proton bunch GameObject in scene:
    protected GameObject ProtonBunch;
    protected Rigidbody rb;

    // controls for game flow:
    protected bool canApplyAcceleration = true;
    protected bool canReset = false;

    // initial state variables:
    protected Vector3 initialPosition = new Vector3(6, 2, 2);
    protected Vector3 initialVelocity = new Vector3(50, 0, 0);

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public virtual void Update()
    {
        // start the collision:
        if (Input.GetKeyDown(KeyCode.Space) && canApplyAcceleration)
        {
            rb.velocity = initialVelocity;

            canReset = true;
            canApplyAcceleration = false;
        }

        // reset to initial state:
        if (Input.GetKeyDown(KeyCode.R) && canReset)
        {
            Reset();
        }
    }

    public virtual void Reset()
    {
        rb.velocity *= 0;
        rb.position = initialPosition;
        canApplyAcceleration = true;
        canReset = false;
    }
}
