using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class engel : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag != "yöndegistirici") 
        {
            Destroy(col.gameObject); 
        }
       
        
    }
}
