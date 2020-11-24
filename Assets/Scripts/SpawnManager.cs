using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Ajouter des gameObjects
    public GameObject Ennemi;
    public GameObject Obstacle;

    //Variables pour apparition des éléments
    private float spawnRangeX = -5;
    private float spawnPosZ = 5;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("Nom fonction", délai, intervalle répétition);
        InvokeRepeating("SpawnEnnemi", 1 , 1);
        InvokeRepeating("SpawnObstacle", 5 , 3);
    }

    // Update is called once per frame
    void Update()
    {
          
    }

     void SpawnObstacle()
    {
        //Setter une variable pour déterminer position
            Vector3 spawnPosition = new Vector3(0, 4, 2);

        //Faire apparaitre et déterminer la position d'apparition
           Instantiate(Obstacle, spawnPosition, Obstacle.transform.rotation);
    }

     void SpawnEnnemi()
    {
        //Déterminer une variable pour déterminer la position
            Vector3 spawnPos = new Vector3(Random.Range(-spawnPosZ, spawnPosZ), 0.5f, spawnRangeX);

        //Faire apparaitre et déterminer la position
           Instantiate(Ennemi, spawnPos, Ennemi.transform.rotation);
    }

}