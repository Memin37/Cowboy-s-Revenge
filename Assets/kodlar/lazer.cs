using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer : MonoBehaviour
{
    [SerializeField]
    GameObject dusmanpatlama;
    UIKontrol uiKontrol;
    Rigidbody2D fizik;
    bool destroy = false;
    

    void Start()
    {
        uiKontrol = Camera.main.GetComponent<UIKontrol>();
        fizik = GetComponent<Rigidbody2D>();
        
              
    }
    void OnCollisionEnter2D(Collision2D col)
    {       
        if (col.gameObject.CompareTag("Enemy")) 
        {
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().VurulmaSesi();
            if (uiKontrol.DusmanCaniGuncelle()==0) 
            {
                Destroy(col.gameObject);
                Instantiate(dusmanpatlama, transform.position, Quaternion.identity);
                uiKontrol.OyunBitti();
            }
        }
        if(col.gameObject.CompareTag("Yavaslatici")) 
        {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().FiciPatlama();
            fizik.AddForce(-fizik.velocity*Time.deltaTime,ForceMode2D.Impulse);
            if (destroy)
            {
                Destroy(gameObject);
            }
            Destroy(col.gameObject);
            destroy = true;
        }
        if (col.gameObject.CompareTag("Sise"))
        {
            uiKontrol.PuaniGuncelle();
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("dusmanlazeri"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);    
        }
        if (col.gameObject.CompareTag("kaktus"))
        {
            foreach (ContactPoint2D contact in col.contacts) 
            {
                if (contact.point.y > transform.position.y - transform.localScale.y / 6 && contact.point.y < transform.position.y + transform.localScale.y / 6)
                {
                    fizik.velocity = -fizik.velocity;
                    transform.Rotate(180, 0, 0);
                }
                else
                {

                }

            }
                
            float x = (col.transform.position.x - this.transform.position.x);
            float z = (col.transform.position.y - this.transform.position.y);
        }    
    }
    void OnTriggerExit2D(Collider2D col)
    {
        //if (col.gameObject.tag== "sektirici") 
        //{
        //    Vector2 konum = col.transform.position;
        //}
    }
}
    

    

