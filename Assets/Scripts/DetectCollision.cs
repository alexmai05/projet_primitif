using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Ce qui se passe quand il y a une collision
     void OnTriggerEnter(Collider other)
    {
        //Détruit lui-même
        Destroy(gameObject);

        //Détruit l'autre GameObject 
        Destroy(other.gameObject);
        
       
    }
}
