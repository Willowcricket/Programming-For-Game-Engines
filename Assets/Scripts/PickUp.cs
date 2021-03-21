using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUp : MonoBehaviour
{
    public Weapon gun;

    // Start is called before the first frame update
    public virtual void Start()
    {
        transform.parent = null;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (gun != null)
            {
                GameManager.Instance.player.GetComponent<HumanoidPawn>().EquipWeapon(gun);
            }
            else
            {
                GameManager.Instance.player.GetComponent<HumanoidPawn>().HealWithItem();
            }
            Destroy(this.gameObject);
        }
    }
}
