using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPawn : Pawn
{
    public GameObject target;
    public Pawn pawn;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    public override void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        pawn = GetComponent<Pawn>();
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        GetComponent<Animator>().speed = pawn.speed;

        target = GameManager.Instance.player;
        agent.SetDestination(target.transform.position);

        Vector3 input = agent.desiredVelocity;
        pawn.Move(agent.desiredVelocity);

        if (currHealth <= 0)
        {
            Dies();
        }

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
        }

        if (weapon != null && agent.remainingDistance <= 5.5)
        {
            if (Time.time >= weapon.nextTimeToFire)
            {
                weapon.nextTimeToFire = Time.time + weapon.rateOfFire;
                weapon.TriggerPulled();
            }
        }

        base.Update();
    }

    void Dies()
    {
        currHealth = maxHeath;
        Destroy(weapon.gameObject);
        GetComponent<Ragdoll>().TheyDied();
        GetComponent<Respawn>().dead = true;
    }

    private void OnAnimatorMove()
    {
        agent.velocity = GetComponent<Animator>().velocity;
    }

}
