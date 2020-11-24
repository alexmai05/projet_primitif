using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    //Variable vitesse du projectile
    public float speed = 40;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Déterminer la position et la direction
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
