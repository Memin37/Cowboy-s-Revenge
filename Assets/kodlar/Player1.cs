using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    Rigidbody2D fizik;
    [SerializeField]
    GameObject mermiprefab;
    GeriSayimAraci geriSayimAraci;
    Vector2 vec = new Vector2(0, 1); 
    void Start()
    {     
        fizik = GetComponent<Rigidbody2D>();
        fizik.AddForce(vec,ForceMode2D.Impulse);
        geriSayimAraci = gameObject.AddComponent<GeriSayimAraci>();
        geriSayimAraci.ToplamSure = 3;
        geriSayimAraci.Calistir();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameObject.CompareTag("Player") || Input.GetButtonDown("Jump") && gameObject.CompareTag("Player")) 
        {
            fizik.velocity = -fizik.velocity;
        }
        if (geriSayimAraci.Bitti)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                geriSayimAraci.Calistir();

                Vector2 vec = new Vector2(transform.position.x + 1.25f, transform.position.y - 0.1f);
                GameObject yenimermi = Instantiate(mermiprefab, vec, Quaternion.Euler(0,180,0));
                Rigidbody2D mermifizik = yenimermi.GetComponent<Rigidbody2D>();
                mermifizik.velocity = new Vector2(5f, 0);

                GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().Ates();
                GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().YenidenDoldur();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Deflector"))
        {
            fizik.velocity = -fizik.velocity;
        }
    }
}
