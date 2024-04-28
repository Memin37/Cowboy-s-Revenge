using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    Rigidbody2D fizik;
    [SerializeField]
    GameObject mermiprefab;
    GeriSayimAraci geriSayimAraci;
    Vector2 vec = new Vector2(0, 1);
    void Start()
    {
        fizik = GetComponent<Rigidbody2D>();
        fizik.AddForce(vec, ForceMode2D.Impulse);
        geriSayimAraci = gameObject.AddComponent<GeriSayimAraci>();
        geriSayimAraci.ToplamSure = 3;
        geriSayimAraci.Calistir();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && gameObject.tag == "Player2")
        {
            fizik.velocity = -fizik.velocity;
        }
        if (geriSayimAraci.Bitti)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                geriSayimAraci.Calistir();

                Vector2 vec = new Vector2(transform.position.x - 1.25f, transform.position.y - 0.1f);
                GameObject yenimermi = Instantiate(mermiprefab, vec, Quaternion.identity);
                Rigidbody2D mermifizik = yenimermi.GetComponent<Rigidbody2D>();
                mermifizik.velocity = new Vector2(-5f, 0);

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
