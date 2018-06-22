using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlJugador : MonoBehaviour {

    private Rigidbody2D objeto;  //Componente Rigidbody
    private float velocidad; //Velocidad del objeto 
    private float posicion1;  //Posicion de los pickups
    private float posicion2;  //posicion de los pickups
    private float min = -10.5f; //Minima posicion del tablero
    private float max = 10.5f; //Maxima posicion del tablero
    private int puntaje; //CAntidad de puntos
    public Text texto; //PAra mostrar los puntos
    public Text fin; //Para mostrar fin de juego
    public float tamSer = 2.25f; //Tamaño de una parte de la serpiente

	// Inicializacion
	void Start () {
        this.objeto = GetComponent<Rigidbody2D>(); //Obtener el Componente
        this.velocidad = 50f; //Empezar con una velocidad de 10
        this.posicion1 = 0f;
        this.posicion2 = 7.61f;
        this.puntaje = 0;
        this.setTexto();
        this.fin.text = "";

    }
	
	// Llamada antes de empezar un frame, Codigo de juego
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
    // Llamada antes de un calculo fisico, Codigo fisico
    void FixedUpdate(){
        
        float moHorizontal = Input.GetAxis("Horizontal"); //Variable de movimiento horizontal
        float moVertical = Input.GetAxis("Vertical"); //Variable de movimiento vertical
        Vector2 veMovimiento = new Vector2(moHorizontal,moVertical); //Vector de movimiento
        this.objeto.AddForce(veMovimiento*velocidad); //Añadir la fuerza


    }
    //Funcion para detectar coliciones
    void OnTriggerEnter2D (Collider2D otro){
        //Comparar si son objetos para recoger
        if (otro.gameObject.CompareTag("Pickup")){
            velocidad = velocidad + 10; //Subir la velocidad del jugado
            this.puntaje++;
            this.setTexto();
            this.posicion1 = Random.Range(min, max); //Nueva posicion X
            this.posicion2 = Random.Range(min, max); //Nueva posicion Y
            Instantiate(otro.gameObject, new Vector3(this.posicion1, this.posicion2, 0), Quaternion.identity); //Creo otro objeto
            otro.gameObject.SetActive(false); //Desactivar el objeto  
            Destroy(otro.gameObject);
           // this.cambioSerpiente();
        }
        //Si son las paredes pierde
        if (otro.gameObject.CompareTag("Mapa")){
           this.gameObject.SetActive(false); //Desactivar el jugador
            this.fin.text = "Fin del juego";
        }



    }
    //Poner el texto en el canvas
    private void setTexto()
    {
        this.texto.text = "Puntaje: " + puntaje.ToString();
    }
    //Funcion para hacer que la serpiente crezca
    private void cambioSerpiente()
    {
        Transform pos = this.objeto.transform;
        Vector3 vecPos = pos.position;
        Vector3 nuevaPos = new Vector3(0f,this.tamSer/2,0f);
        vecPos = vecPos + nuevaPos;
        Object ob = Instantiate(this.objeto.gameObject,vecPos, Quaternion.identity);
        ob.name = "cola";

    }
}
