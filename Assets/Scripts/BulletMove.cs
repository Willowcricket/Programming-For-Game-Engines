using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private float timerUntilDeath = 2.0f;
    [SerializeField] private float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        if (timerUntilDeath > 0)
        {
            timerUntilDeath -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Bullet Has Dropped Off.");
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bullet Has Hit Something.");
        if (other.tag == "Player" || other.tag == "Enemy")
        {
            other.GetComponent<Pawn>().currHealth -= 15;
        }
        Destroy(this.gameObject);
    }
}
