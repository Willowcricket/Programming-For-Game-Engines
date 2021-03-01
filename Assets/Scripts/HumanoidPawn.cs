using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HumanoidPawn : Pawn
{
    [SerializeField] private Animator _anim;
    public float speed = 1;
    public float rotSpeed = 180f;
    public Transform target;
    public bool isSprinting = false;

    // Start is called before the first frame update
    public override void Start()
    {
        _anim = GetComponent<Animator>();
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

        moveDirection.Normalize();

        moveDirection = transform.InverseTransformDirection(moveDirection);

        _anim.SetFloat("Forward", moveDirection.z * speed);
        _anim.SetFloat("Right", moveDirection.x * speed);
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

    public void OnAnimatorIK(int layerIndex)
    {
        if (weapon != null)
        {
            _anim.SetIKPosition(AvatarIKGoal.LeftHand, weapon.leftHandPoint.position);
            _anim.SetIKPosition(AvatarIKGoal.RightHand, weapon.rightHandPoint.position);
        }
    }

    private void OnDestroy()
    {
        SceneManager.LoadScene("Main");
    }
}
 