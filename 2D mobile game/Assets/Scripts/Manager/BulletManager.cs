using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.tag == "Name of the enemy tag")
        {
            // collision.GetComponent < "the enemy" > ().TakeDamage(25);
                Destroy(gameObject);
        }
    }
}
