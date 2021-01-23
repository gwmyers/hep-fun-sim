using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialStateA : ProtonInitialState
{
    public override void Start()
    {
        base.Start();

        base.initialPosition = new Vector3(-6, 2, 2);
    }

    public override void Update()
    {
        base.Update();
    }
}
