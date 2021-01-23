using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialStateC : ProtonInitialState
{
    

    public override void Start()
    {
        base.Start();

        base.initialPosition = new Vector3(6, 2, 2);
        base.initialVelocity *= -1; 
    }

    public override void Update()
    {
        base.Update();
    }
}
