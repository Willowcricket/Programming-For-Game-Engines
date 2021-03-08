using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    public Animator bigAnim;
    public Rigidbody bigRigidbody;
    public CapsuleCollider bigCapsuleCollider;
    public HumanoidPawn bigHumanoidPawn;
    public AIPawn bigAIPawn;
    public IKControl bigIKControl;

    public Rigidbody[] littleRigidbodies;
    public CapsuleCollider[] littleCapsuleColiders;

    public BoxCollider littleBoxCollider1;
    public BoxCollider littleBoxCollider2;
    public SphereCollider littleSphereCollider;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Rigidbody item in littleRigidbodies)
        {
            item.detectCollisions = false;
        }
        foreach (CapsuleCollider item in littleCapsuleColiders)
        {
            item.enabled = false;
        }

        littleBoxCollider1.enabled = false;
        littleBoxCollider2.enabled = false;
        littleSphereCollider.enabled = false;
    }

    public void TheyLive()
    {
        bigAnim.enabled = true;
        bigRigidbody.detectCollisions = true;
        bigRigidbody.useGravity = true;
        bigCapsuleCollider.enabled = true;
        if (bigHumanoidPawn != null)
        {
            bigHumanoidPawn.enabled = true;
        }
        if (bigAIPawn != null)
        {
            bigAIPawn.enabled = true;
        }
        bigIKControl.enabled = true;

        foreach (Rigidbody item in littleRigidbodies)
        {
            item.detectCollisions = false;
        }
        foreach (CapsuleCollider item in littleCapsuleColiders)
        {
            item.enabled = false;
        }

        littleBoxCollider1.enabled = false;
        littleBoxCollider2.enabled = false;
        littleSphereCollider.enabled = false;
    }

    public void TheyDied()
    {
        bigAnim.enabled = false;
        bigRigidbody.detectCollisions = false;
        bigRigidbody.useGravity = false;
        bigCapsuleCollider.enabled = false;
        if (bigHumanoidPawn != null)
        {
            bigHumanoidPawn.enabled = false;
        }
        if (bigAIPawn != null)
        {
            bigAIPawn.enabled = false;
        }
        bigIKControl.enabled = false;

        foreach (Rigidbody item in littleRigidbodies)
        {
            item.detectCollisions = true;
        }
        foreach (CapsuleCollider item in littleCapsuleColiders)
        {
            item.enabled = true;
        }

        littleBoxCollider1.enabled = true;
        littleBoxCollider2.enabled = true;
        littleSphereCollider.enabled = true;
    }
}
