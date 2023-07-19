using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instacia{ get; private set;}
    private MaquinaEstado maquinaEstado;
    private void Awake() {
        if(Instacia != null) Destroy(gameObject);
        else Instacia = this;
    }

    public void ActualizarMaquinaEstado(MaquinaEstado nuevoEstado)
    {
        switch (nuevoEstado)
        {
            case MaquinaEstado.Jugando:
                break;
            case MaquinaEstado.JuegoTerminado:
                Debug.Log("perdiste");
                break;
            case MaquinaEstado.JuegoGanado:
                Debug.Log("Juego Ganado");
                break;
            default:
                break;
        }

    }
}

public enum MaquinaEstado
{
    Jugando,
    JuegoTerminado,
    JuegoGanado
}