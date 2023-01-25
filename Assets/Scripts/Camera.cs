using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour{   
    public GameObject jogador;  // Objeto jogador
    private Vector3 diferenca;  // distancia entre a camara e o jogador

    // Calcular a diferença entre a camara e o jogador inicialmente
    void Start(){
        diferenca = transform.position - jogador.transform.position;    
    }

    // mexer a camara junto com o jogador
    void LateUpdate(){
        transform.position = jogador.transform.position + diferenca;
    }
}