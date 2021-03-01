using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    public UnityEvent OnTriggerPulled;

    [Header("IK")]
    public Transform rightHandPoint;
    public Transform leftHandPoint;

    [Header("Ammo")]
    public GameObject ammo;
    public float rateOfFire;
    public float nextTimeToFire;

    [Header("Rifle")]
    public Transform bulletHole;

    [Header("Shotgun")]
    public Transform shot2;
    public Transform shot3;
    public Transform shot4;
    public Transform shot5;

    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void TriggerPulled()
    {
        OnTriggerPulled.Invoke();
    }
}
