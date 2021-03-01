using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : Controller
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        pawn.Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        base.Update();

        if (pawn.weapon != null)
        {
            if (Input.GetButton("Fire1") && Time.time >= pawn.weapon.nextTimeToFire)
            {
                pawn.weapon.nextTimeToFire = Time.time + pawn.weapon.rateOfFire;
                pawn.weapon.TriggerPulled();
            }
        }
    }
}
