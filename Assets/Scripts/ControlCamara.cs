using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour {

    public GameObject jugador;  //Referencia al objeto jugador
    private Vector3 diferencia; //Vector para que la camara siga el objeto


	// Inicializacion
	void Start () {
        this.diferencia = transform.position - this.jugador.transform.position;

		
	}
	
	// Cada frame, pero cuando todos los updates se han ejecutado
	void LateUpdate () {
        this.transform.position = this.jugador.transform.position + this.diferencia;
		
	}
}
