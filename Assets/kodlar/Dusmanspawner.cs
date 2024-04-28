using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusmanspawner : MonoBehaviour
{
    [SerializeField]
    GameObject dusmanprefab;
    [SerializeField]
    GameObject asteroid;
    [SerializeField]
    GameObject fici;
    [SerializeField]
    GameObject yavaslatici;
    [SerializeField]
    GameObject sektirici;
    [SerializeField]
    GameObject sise;
    GeriSayimAraci geriSayimAraci;
    [SerializeField]
    GameObject oyuncu1;
    [SerializeField]
    GameObject oyuncu2;
    bool oyunbasladi=false;
    List<GameObject> objeList = new List<GameObject>();
    
    public void OyunuBaslat() 
    { 
        geriSayimAraci = gameObject.AddComponent<GeriSayimAraci>();
        geriSayimAraci.ToplamSure = 3;
        geriSayimAraci.Calistir();
        oyunbasladi = true;
        objeList.Add(Instantiate(oyuncu1,new Vector2(-13.72f,0), Quaternion.identity));
        objeList.Add(Instantiate(oyuncu2,new Vector2(13.55f,0),Quaternion.identity));
    }
    void Update()
    {
        if (oyunbasladi)
        {   
            //Vector2 vec = new Vector2(20, Random.Range(-6, 6));
            //Vector2 vec1 = new Vector2(20, Random.Range(-6, 6));
            Vector2 vec3 = new Vector2(Random.Range(-8, 9), Random.Range(-3.5f, 2.5f));
            Vector2 vec4 = new Vector2(Random.Range(-8, 9), Random.Range(-3.5f, 2.5f));
            //Vector2 vec5= new Vector2(Random.Range(-8, 9), Random.Range(-3.5f, 2.5f));
            //Vector2 vec6 = new Vector2(-13.72f, Random.Range(-4,3)); 
            if (geriSayimAraci.Bitti) 
            {
                objeList.Add(Instantiate(fici, vec3, Quaternion.identity));
                //Instantiate(dusmanprefab,vec,Quaternion.identity);
                //Instantiate(asteroid, vec1, Quaternion.identity);
                objeList.Add(Instantiate(yavaslatici, vec4, Quaternion.identity));
                //Instantiate(sise, vec6, Quaternion.identity);
                //Instantiate(sektirici, vec5, Quaternion.identity);
                geriSayimAraci.Calistir();
            }
        } 
    }
    public void OyunuBitir() 
    {
        oyunbasladi = false;
        Debug.Log("annen");
        for (int i = 0; i < objeList.Count; i++)
        {
            Destroy(objeList[i]);
        }
    }
}
