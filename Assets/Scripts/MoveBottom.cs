using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBottom : MonoBehaviour
{
     //Déclarer une variable pour le script de PlayerController
    private PlayerController playerControllerScript;

    //Variable pour vitesse des ennemis
    public float speed = 20;

    // Start is called before the first frame update
    void Start()
    {
        //Obtenir les données en lien avec le joueur dans le script de playerController
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //Ce qui se passe si le Game Over du script PlayerController est Faux
        if (playerControllerScript.gameOver == false ) { 
            //Permet de faire avancer l'ennemi en se basant sur la valeur de l'axe des z
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        //Ce qui se passe si le Game Over du script PlayerController est Vrai
        else if (playerControllerScript.gameOver == true ) { 
            //Permet d'arrêter le déplacement de l'ennemi
            transform.Translate(Vector3.forward * Time.deltaTime * 0);
        }
    }
}
