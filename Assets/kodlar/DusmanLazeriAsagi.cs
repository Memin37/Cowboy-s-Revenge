using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanLazeriAsagi : MonoBehaviour
{
    [SerializeField]
    GameObject dusmanpatlama;
    [SerializeField]
    GameObject saçma;
    Rigidbody2D fizik;
    Vector2 vec1;
    Vector2 vec2;
    UIKontrol uiKontrol;
    void Start()
    {
        fizik = GetComponent<Rigidbody2D>();
        uiKontrol = Camera.main.GetComponent<UIKontrol>();
        vec1= new Vector2(-0.3f,Random.Range(-0.1f,0.1f));
        vec2 = -vec1 / 2;
        fizik.AddForce(vec1, ForceMode2D.Impulse);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == ("Player"))
        { 
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().VurulmaSesi();
            if (uiKontrol.CaniGuncelle() == 0)
            {
                Instantiate(dusmanpatlama, transform.position, Quaternion.identity);
                Destroy(col.gameObject);
                uiKontrol.OyunBitti();
            }
        }
        if (col.tag == "Yavaslatici")
        {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().FiciPatlama();
            fizik.AddForce(vec2, ForceMode2D.Impulse);
            if (fizik.velocity == Vector2.zero)
            {
                Destroy(gameObject);
            }
            Destroy(col.gameObject);
        }
        if (col.tag == "PlayerRay")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
     
    
        


    


}
