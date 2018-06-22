using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script para hacer que un objeto rote y se vea mas llamativo
public class Rotador : MonoBehaviour {

	// Actualizar cada frame
	void Update () {
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime); //Multiplicando por un tiempo para que sea suave
		
	}

   
}
