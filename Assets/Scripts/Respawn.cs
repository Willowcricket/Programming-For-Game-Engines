using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float timeForDeath;
    public float nextTimeToDeath;
    public bool dead = false;
    public bool AI = false;

    // Update is called once per frame
    void Update()
    {
        if (dead == true)
        {
            if (timeForDeath > 0)
            {
                timeForDeath -= Time.deltaTime;
            }
            else
            {
                if (AI == true)
                {
                    Destroy(this.gameObject);
                }
                dead = false;
                timeForDeath = nextTimeToDeath;
                Lives();
            }
        }
    }

    void Lives()
    {
        GetComponent<Ragdoll>().TheyLive();
    }
}
