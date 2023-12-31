using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorController : MonoBehaviour
{

    //Declarlo la variable de tipo RigidBody que luego asociaremos a nuestro Jugador
    private Rigidbody rb;
    private int contador;

    //Declaro la variable pública velocidad para poder modificarla desde la Inspector window
    public float velocidad;


    // Start is called before the first frame update
    void Start()
    {
        //Capturo esa variable al iniciar el juego
        rb = GetComponent<Rigidbody>();
        contador = 0;
    }

    // Para que se sincronice con los frames de física del motor
    void FixedUpdate () {
        //Estas variables nos capturan el movimiento en horizontal y vertical de nuestro teclado
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");

        //Un vector 3 es un trío de posiciones en el espacio XYZ, en este caso el que corresponde al movimiento
        Vector3 movimiento = new Vector3(movimientoH, 0.0f,movimientoV);

        //Asigno ese movimiento o desplazamiento a mi RigidBody
        rb.AddForce(movimiento * velocidad);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Coleccionable")){
            other.gameObject.SetActive (false);
            contador = contador + 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
