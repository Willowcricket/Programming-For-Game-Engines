using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HumanoidPawn : Pawn
{
    public Transform target;
    public bool isSprinting = false;

    // Start is called before the first frame update
    public override void Start()
    {
        GameManager.Instance.player = this.gameObject;
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(0, 5, 0, ForceMode.Impulse);
        }
        base.Update();
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

    private void OnDestroy()
    {
        //SceneManager.LoadScene("Main");
    }
}
 