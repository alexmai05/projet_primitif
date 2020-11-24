using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variable pour le deplacement du joueur
    public float horizontalInput;

    //Variable pour la vitesse du joueur
    public float speed = 10;

    //Variable pour la limite du deplacement
    public float xLimit = 5;

    //Déclarer un GameObject pour obtenir le prefab de projectile
    public GameObject Projectile;

    //Déclarer une variable pour le clip audio du son de projectile
    public AudioClip projectileSound;

    //Déclarer une variable pour la source audio du son de projectile
    private AudioSource playerAudio;

    //Déclarer une variable pour le clip audio du son de Game Over
    public AudioClip gameOverSound;

    //Déclarer un particle system pour obtenir les particules
    public ParticleSystem explosionParticle ;

    // Start is called before the first frame update
    void Start()
    {
        //Obtenir la source audio
         playerAudio = GetComponent<AudioSource>();  
    }

    // Update is called once per frame
    void Update()
    {
          //Ce qui arrive si le Game Over est égal à Faux
        if ( gameOver == false) {
            //Permet d'obtenir la valeur de l'axe horizontal du joueur
            horizontalInput = Input.GetAxis("Horizontal");

            //Permet de faire bouger le joueur en se basant sur la valeur de l'axe horizontal
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        }  

        //Ce qui arrive si le Game Over est égal à Vrai
        else if (gameOver == true) {
            //Permet d'arrêter le déplacement du joueur 
            transform.Translate(Vector3.forward * Time.deltaTime * 0);
        } 

        //Si la position x depasse la limite de la plateforme
        if ( transform.position.x > xLimit)  {
            transform.position = new Vector3(xLimit, 0, transform.position.z);

        } else if ( transform.position.x < -xLimit)  {

            transform.position = new Vector3(-xLimit, 0, transform.position.z);
        }

        //Ce qui se passe quand on pèse sur le barre espace
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Le son de projectile joue une fois au volume voulu
           playerAudio.PlayOneShot(projectileSound, 5f);

            //Instantiate ( le prefab , sa position , sa rotation)
            Instantiate( Projectile , transform.position + new Vector3(0, 0.5f, -1)  , transform.rotation);
        }

    }
    //Déclarer un booléen de Game Over
     public bool gameOver = false;

    //Déclaration d'une fonction pour la collision entre un ennemi et le joueur
    void OnCollisionEnter(Collision collision) {

        //Ce qui arrive si le joueur entre en collision avec un ennemi 
        if ( collision.gameObject.CompareTag("HitEnnemy") ) {
            
           //Permet de faire apparaitre un message dans la console de Game Over
           Debug.Log("Game Over");
           
           //Déclare le Game Over comme étant Vrai
            gameOver = true;

            //Le son de Game Over joue une fois au volume voulue
            playerAudio.PlayOneShot(gameOverSound, 5f);

            //Le système de particules s'active et joue 
            explosionParticle.Play();
        } 
    }
}