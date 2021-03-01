using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Projectile : Weapon
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public void RifleShoot()
    {
        Instantiate(ammo, bulletHole);
    }

    public void ShotgunShoot()
    {
        Instantiate(ammo, bulletHole);
        Instantiate(ammo, shot2);
        Instantiate(ammo, shot3);
        Instantiate(ammo, shot4);
        Instantiate(ammo, shot5);
    }
}
