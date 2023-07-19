using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPeces : MonoBehaviour
{

    private float spawnTime;
    [SerializeField]private GameObject pezPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        spawnTime = spawnTime - Time.deltaTime;
        if(spawnTime <= 0){
            Instantiate(pezPrefab , GetSpawnPosition(),Quaternion.identity);
            spawnTime = 1.5f;
        }
    }

    private Vector3 GetSpawnPosition(){
        Vector2 limitePantalla = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));

        float aleatorioVertical = Random.Range(-limitePantalla.y,limitePantalla.y);
        float aleatorioHorizotal = Random.Range(0,2) == 0 ?  -limitePantalla.x - 1 : limitePantalla.x + 1;

        return new Vector3(aleatorioHorizotal,aleatorioVertical,0);
    }

}
