using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterControler : MonoBehaviour
{ 
    private int vidas = 3;


  //float nivelPiso             = -2.68f; // este valor representa el nivel del piso para el personaje
    float nivelDelTecho         = 7.39f;  // este valor representa el nivel del techo para el personaje
  //float limiteR               = 10.11f; // este valor representa el limite derecho de la camara para el personaje
    float limiteL               = -10f;   // este valor representa el limite izquierdo de la camara para el personaje
    float velocidad             = 4f;     // este valor representa la velocidad de desplazamiento del personaje
    float fuerzaSalto           = 70;     // x veces la masa del personaje
    float fuerzaDesplazamiento  = 300;     // fuerza en newtons

    bool enELPiso = true;
    [SerializeField] private AudioSource salto_SFX;

    // Start is called before the first frame update
    void Start()
    {
        //personaje siempre inicia en la posicion (-0.03, -2.9)
        gameObject.transform.position = new Vector3(-0.03f, nivelDelTecho,0);
        Debug.Log("INIT");
        Debug.Log("vidas: " + vidas);
        
    }

    // Update is called once per frame
    void Update()
    { 
         if(gameObject.transform.rotation.z > 0.3 || gameObject.transform.rotation.z < 0.3)
         if(Input.GetKey("right")){
            Debug.Log("RIGHT");
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(fuerzaDesplazamiento, 0));
           
        }
         else if(Input.GetKey("left") && gameObject.transform.position.x > limiteL){
            Debug.Log("LEFT");
           gameObject.transform.Translate(-velocidad*Time.deltaTime,0 ,0);
        }
        if(Input.GetKeyDown("up") && enELPiso){
            Debug.Log("UP - enELPiso: " + enELPiso);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -fuerzaSalto*Physics2D.gravity[1]*gameObject.GetComponent<Rigidbody2D>().mass));
            enELPiso = false;
            salto_SFX.Play();
        }

        
        
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.transform.tag == "ground"){
            enELPiso = true;
            Debug.Log("GROUND COLLISION");
        }
        else if(collision.transform.tag == "roca"){
            enELPiso = true;
            Debug.Log("ROCA COLLISION");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("Caida");
        vidas -= 1;
        Debug.Log("vidas: " + vidas);
        if(vidas<= 0){
            Debug.Log("game over");
            vidas = 3;
        }
        gameObject.transform.position = new Vector3(-0.03f, nivelDelTecho,0);

    }
   
}
