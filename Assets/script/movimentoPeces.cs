using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoPeces : MonoBehaviour
{
    private int dir = 1;
    [SerializeField]private float speed = 1.5f;
    Vector2 limitePantalla; 
    [SerializeField]private Transform pezSprite;
    private float tamano;

    
    void Start()
    {
        limitePantalla = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));

        if(transform.position.x <= limitePantalla.x / 2){
            dir= 1;
            pezSprite.rotation = Quaternion.Euler(new Vector3(0,0,0));

        } else{
            dir = -1;
            pezSprite.rotation = Quaternion.Euler(new Vector3(0,180,0));

        }
        // tamaño random
        float tamanoAleatorio = Random.Range(0.5f,2.5f);
        tamano = tamanoAleatorio;

        transform.localScale = new Vector3(tamanoAleatorio,tamanoAleatorio,tamanoAleatorio);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.right * dir * Time.deltaTime * speed);   

        if(transform.position.x <= - limitePantalla.x  -2 || transform.position.x > limitePantalla.x + 2){
            Destroy(gameObject);
        }
    }

    public float getTamano(){
        return tamano;
    }
}
