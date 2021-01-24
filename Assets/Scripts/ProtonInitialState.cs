using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class describing the initial state of one proton bunch
/// </summary>
public class ProtonInitialState : MonoBehaviour
{
    // our proton bunch and parton prefabs:
    public GameObject ProtonBunchObj;
    public Rigidbody ProtonBunchRigidBody;

    public GameObject partonPrefab;
    public GameObject[] partonObjs;
    public Rigidbody[] partonRigidBodies;


    // initial state variables:
    public Vector3 initialPosition = new Vector3(6, 2, 2);
    public Vector3 initialVelocity = new Vector3(50, 0, 0);
    protected PartonDistributionFunction pdf = new PartonDistributionFunction();

    // controls for game flow:
    protected bool canApplyAcceleration = true;
    protected bool canReset = false;

    /// <summary>
    /// Generates parton content inside our proton bunch:
    /// </summary>
    protected virtual void preparePartonInitialState()
    {
        List<int> partonComp = pdf.generatePartonContent();
        partonObjs = new GameObject[partonComp.Count];
        partonRigidBodies = new Rigidbody[partonComp.Count];

        // spawn our partons:
        for (int ii = 0; ii < partonComp.Count; ii++)
        {
            Vector3 postion = ProtonBunchObj.transform.position + Random.insideUnitSphere;
            GameObject clone = (GameObject)Instantiate(partonPrefab, postion, Quaternion.identity);
            clone.transform.parent = ProtonBunchObj.transform;
            partonObjs[ii] = clone;
            partonRigidBodies[ii] = clone.gameObject.GetComponent<Rigidbody>();
        }
    }

    /// <summary>
    /// Start
    /// </summary>
    public virtual void Start()
    {
        SetProtonBunchRenderAlpha(0.2f);
        ProtonBunchRigidBody = GetComponent<Rigidbody>();
        preparePartonInitialState();
    }

    /// <summary>
    /// Update 
    /// </summary>
    public virtual void Update()
    {
        // start the collision with 'SPACE' key:
        if (Input.GetKeyDown(KeyCode.Space) && canApplyAcceleration)
        {
            ProtonBunchRigidBody.velocity = initialVelocity;

            foreach (Rigidbody rb in partonRigidBodies)
            {
                rb.velocity = initialVelocity;
            }

            canReset = true;
            canApplyAcceleration = false;
        }

        // reset to initial state with 'R' key:
        if (Input.GetKeyDown(KeyCode.R) && canReset)
        {
            Reset();
        }

    }

    /// <summary>
    /// Reset the proton bunches to their initial state
    /// </summary>
    public virtual void Reset()
    {
        ProtonBunchObj.transform.position = initialPosition;
        ProtonBunchRigidBody.velocity *= 0;
        ProtonBunchRigidBody.position = initialPosition;

        foreach (GameObject obj in partonObjs)
        {
            Destroy(obj);
        }

        foreach (Rigidbody rb in partonRigidBodies)
        {
            Destroy(rb);
        }

        preparePartonInitialState();

        canApplyAcceleration = true;
        canReset = false;
    }

    public virtual void SetProtonBunchRenderAlpha(float newAlpha)
    {
        Renderer r = ProtonBunchObj.GetComponent<Renderer>();
        Color materialColor= r.material.color;
        r.material.color = new Color(materialColor.r, materialColor.g, materialColor.b, newAlpha);

    }
}
