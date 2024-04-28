using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock: MonoBehaviour
{ 
    public GameObject miniBullet;
    void Start()
    {
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Rigidbody2D fizik = col.GetComponent<Rigidbody2D>();
        if (col.gameObject.CompareTag("Projectile"))
        {
            //if (fizik.velocity.x < 0)
            //{
                
            //}
            //else
            //{
                
            //}
            GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().TasPatlama();

            GameObject yenimermi = Instantiate(miniBullet, transform.position, Quaternion.identity);
            Rigidbody2D mermifizik = yenimermi.GetComponent<Rigidbody2D>();
            mermifizik.velocity = new Vector2(5f, 0);
            Destroy(col.gameObject);
            Destroy(gameObject);  
        }
    }
}
