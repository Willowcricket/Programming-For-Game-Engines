using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public Weapon weapon;
    public Transform attachmentPoint;
    [SerializeField] private Animator _anim;

    public int currHealth = 100;
    public int maxHeath = 100;

    public float speed = 1;
    public float rotSpeed = 180f;

    // Start is called before the first frame update
    public virtual void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (currHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public virtual void Move(Vector3 moveDirection)
    {
        moveDirection.Normalize();

        moveDirection = transform.InverseTransformDirection(moveDirection);

        _anim.SetFloat("Forward", moveDirection.z * speed);
        _anim.SetFloat("Right", moveDirection.x * speed);
    }

    public virtual void EquipWeapon(Weapon weaponToEquip)
    {
        if (weapon)
        {
            Destroy(weapon.gameObject);
            weapon = null;
        }
        weapon = Instantiate(weaponToEquip) as Weapon;
        weapon.transform.SetParent(attachmentPoint);
        weapon.transform.localPosition = weaponToEquip.transform.localPosition;
        weapon.transform.localRotation = weaponToEquip.transform.localRotation;
    }

    public virtual void HealWithItem()
    {
        currHealth = maxHeath;
    }
}
