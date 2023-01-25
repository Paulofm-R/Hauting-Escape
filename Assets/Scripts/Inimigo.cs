using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inimigo : MonoBehaviour{

    NavMeshAgent agente;
    public Transform jogador;
    // public float anguloVisao = 120;
    public float distanciaMax = 5;  // distancia maxima que o inimigo pode ver o jogador

    Vector3 inimigoPosicaoOriginal;

    void Start(){
        agente = GetComponent<NavMeshAgent>();
        inimigoPosicaoOriginal = transform.position;
    }

    void Update(){
        if (OnVision()){ // se o inimigo tiver a ver o jogador, ir atras dele
            agente.destination = jogador.position;
        }
        else{ // se não tiver a ver o jogador, voltar a sua posição inicial 
            agente.destination = inimigoPosicaoOriginal;
        }
    }

    // Campo de visão do inimigo
    // Esta parte do código foi inspirado no video: https://www.youtube.com/watch?v=T2Tp6odp6J8
    bool OnVision(){
        Vector3 direcao = jogador.position - transform.position;
        // float angulo = Vector3.Angle(direcao, transform.forward);

        float currentDis = Vector3.Distance(jogador.position, transform.position);  // calcular a distancia que o inimigo esta do jogador

        RaycastHit hit;

        // Ver se o jogador esta dentro do campo de visão do inimigo
        if(currentDis <= distanciaMax){
            if(Physics.Linecast(transform.position, jogador.position, out hit)){
                if (hit.transform.tag == "Player"){
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        }
        else{
            return false;
        }
    }
}
