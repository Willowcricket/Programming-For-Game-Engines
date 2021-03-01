using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPawn : Pawn
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (weapon != null)
        {
            if (Time.time >= weapon.nextTimeToFire)
            {
                weapon.nextTimeToFire = Time.time + weapon.rateOfFire;
                weapon.TriggerPulled();
            }
        }
        base.Update();
    }
}
