using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Projectile"))
        {
            Rigidbody2D rigidbody = col.GetComponent<Rigidbody2D>();
            if (rigidbody != null)
            {
                rigidbody.velocity /= 2;
                GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().FiciPatlama();
                Destroy(gameObject);
            }
        }
    }
}
