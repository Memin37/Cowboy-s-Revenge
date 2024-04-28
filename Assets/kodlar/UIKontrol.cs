using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class UIKontrol : MonoBehaviour
{
    [SerializeField]
    GameObject oyunBittiText = default;
    [SerializeField]
    GameObject oyunAdiText = default;
    [SerializeField]
    Text puanText1 = default;
    [SerializeField]
    Text puanText2 = default;
    [SerializeField]
    GameObject baslamaButonu = default;
    [SerializeField]
    GameObject yenidenBaslamaButonu = default;    
    int kalancan = 5;
    int dusmankalancan = 5;
    Dusmanspawner dusmanSpawner;
    //int puan;
    void Start()
    {
        dusmanSpawner = Camera.main.GetComponent<Dusmanspawner>();
        oyunBittiText.gameObject.SetActive(false);
        puanText1.gameObject.SetActive(false);
        puanText2.gameObject.SetActive(false);
        yenidenBaslamaButonu.gameObject.SetActive(false);
    }
    public void OyunBasladi() 
    {
        
        baslamaButonu.gameObject.SetActive(false);
        oyunAdiText.gameObject.SetActive(false);
        puanText1.gameObject.SetActive(true);
        puanText2.gameObject.SetActive(true);
       
        puanText1.text = "" + kalancan;
        puanText2.text = "" + dusmankalancan;
    }
    public void OyunuYenile() 
    {    
        puanText1.gameObject.SetActive(true);
        puanText2.gameObject.SetActive(true);
        kalancan = 5;
        puanText1.text = "" + kalancan;
        dusmankalancan = 5;
        puanText2.text = "" + dusmankalancan;
        yenidenBaslamaButonu.gameObject.SetActive(false);
        oyunBittiText.gameObject.SetActive(false);
    }
    public void OyunBitti() 
    {
        
        puanText1.gameObject.SetActive(false);
        puanText2.gameObject.SetActive(false);
        dusmanSpawner.OyunuBitir();
        oyunBittiText.gameObject.SetActive(true);
        yenidenBaslamaButonu.gameObject.SetActive(true);
        
    }
    public void PuaniGuncelle()
    {
        //puan += 10;
        //puanText.text = "PUAN:" + puan;
    }
    public int CaniGuncelle() 
    {
        kalancan -= 1;
        puanText1.text = ""+kalancan;
        return kalancan;
    }
    public int DusmanCaniGuncelle()
    {
        dusmankalancan -= 1;
        puanText2.text = "" + dusmankalancan;
        return dusmankalancan;
    }
}
