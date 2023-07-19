using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerIU : MonoBehaviour
{
    private TMP_Text puntosTexto;

    private void Awake() {
        puntosTexto = GetComponent<TMP_Text>();
    }
    public void ActualizarPuntos(int puntos)
    {
        puntosTexto.text = "peces comidos " + puntos.ToString();
    }
}
