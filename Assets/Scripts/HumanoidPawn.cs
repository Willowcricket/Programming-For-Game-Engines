using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HumanoidPawn : Pawn
{
    public Transform target;
    public Pawn pawn;
    public int lives = 3;

    // Start is called before the first frame update
    public override void Start()
    {
        GameManager.Instance.player = this.gameObject;
        pawn = GetComponent<Pawn>();
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            pawn.speed = 1.5f;
            GetComponent<Animator>().speed = pawn.speed;
        }
        else
        {
            pawn.speed = 1.0f;
            GetComponent<Animator>().speed = pawn.speed;
        }

        if (currHealth <= 0)
        {
            Dies();
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(0, 5, 0, ForceMode.Impulse);
        }
        base.Update();
    }

    void Dies()
    {
        currHealth = maxHeath;
        if (weapon)
        {
            Destroy(weapon.gameObject);
            weapon = null;
        }
        GetComponent<Ragdoll>().TheyDied();
        GetComponent<Respawn>().dead = true;
    }

    public override void Move(Vector3 moveDirection)
    {
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
        base.Move(moveDirection);
    }

    bool IsGrounded()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, out hit, 0.15f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
 