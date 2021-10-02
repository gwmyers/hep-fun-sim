using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to manage one parton object
/// </summary>
public class Parton : MonoBehaviour
{
    public GameObject partonObj;
    public Rigidbody partonRigidBody;
    public Vector3 initialPosition = new Vector3(6, 2, 2);
    public Vector3 initialVelocity = new Vector3(50, 0, 0);

    public int flavor;
    public double mass;
    public double spin;
    public double charge_U1;
    public double charge_SU2;
    public double charge_SU3;

    // controls for game flow:
    protected bool canApplyAcceleration = true;
    protected bool canReset = false;

    /// <summary>
    /// Start
    /// </summary>
    public virtual void Start()
    {
        partonRigidBody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Update 
    /// </summary>
    public virtual void Update()
    {
        // start the collision with 'SPACE' key:
        if (Input.GetKeyDown(KeyCode.Space) && canApplyAcceleration)
        {
            partonRigidBody.velocity = initialVelocity;

            canReset = true;
            canApplyAcceleration = false;
        }

        // reset to initial state with 'R' key:
        if (Input.GetKeyDown(KeyCode.R) && canReset)
        {
            Reset();
        }

        // quit application on escape:
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    /// <summary>
    /// Reset the proton bunches to their initial state
    /// </summary>
    public virtual void Reset()
    {
        partonObj.transform.position = initialPosition;
        partonRigidBody.velocity *= 0;
        partonRigidBody.position = initialPosition;
        canApplyAcceleration = true;
        canReset = false;
    }
}
