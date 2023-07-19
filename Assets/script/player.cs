using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    float velocidad = 3;
    private int pecesComidos = 0;
    private float tamano;

    [SerializeField]private Transform pezSprite;

    [SerializeField]private playerIU PlayerIU;

    void Start()
    {
        tamano = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        // movimiento
        float inputVertical = Input.GetAxis("Vertical") * Time.deltaTime * velocidad;
        float inputHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;

        transform.position = transform.position + new Vector3(inputHorizontal,inputVertical,0);

        // evitar salir de la pantalla
        Vector2 limitePantalla = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, limitePantalla.x * -1, limitePantalla.x),
            Mathf.Clamp(transform.position.y, limitePantalla.y * -1, limitePantalla.y),
            0
        );

        // rotacion
        if(inputHorizontal == 0) return;
        if(inputHorizontal < 0){
            pezSprite.rotation = Quaternion.Euler(new Vector3(0,180,0));
        } else {
            pezSprite.rotation = Quaternion.Euler(new Vector3(0,0,0));

        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Pez"))
        {

            movimentoPeces mp = collision.gameObject.GetComponent<movimentoPeces>();

            if (tamano >= mp.getTamano())
            {
                pecesComidos++; 
                PlayerIU.ActualizarPuntos(pecesComidos);
                transform.localScale = transform.localScale + new Vector3(0.1f,0.1f,0.1f); 
                tamano = transform.localScale.x;


                Destroy(collision.gameObject);

                if(pecesComidos >= 10){
                    GameManager.Instacia.ActualizarMaquinaEstado(MaquinaEstado.JuegoGanado);
                    velocidad = 0;
                }

            } else{
                GameManager.Instacia.ActualizarMaquinaEstado(MaquinaEstado.JuegoTerminado);
                Destroy(gameObject);
            }

            
        }
    }
}
