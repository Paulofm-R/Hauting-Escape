using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour{
    [SerializeField] float velocidade = 2.5f; // Velocidade do jogador
    [SerializeField] ParticleSystem fumacaTeleporte;

    public static Jogador instance;
    public GameObject[] teleportes = new GameObject[14];  // todos os teleportes do jogo
    public AudioClip coletavelSom;
    public AudioClip TeleporteSom;

    private int coleteveisAzuis = 0;
    private int coleteveisVerdes = 0;
    private int coleteveisVermelhos = 0;

    Vector3 frontal, lateral;
    Vector3 jogadorPosicaoOriginal;

    Quaternion jogadorOrientacaoOriginal;

    void Awake(){
        if (instance == null){
            instance = this;
        }
        else if (instance != this){
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start(){
        frontal = transform.forward;
        lateral = Quaternion.Euler(new Vector3(0, 90, 0))* frontal;
        jogadorOrientacaoOriginal = transform.rotation;
        jogadorPosicaoOriginal = JogoControlo.instance.Spawns[0].position;
        fumacaTeleporte.Stop();
    }

    // Update is called once per frame
    void Update(){
        Vector3 horizontal = lateral * velocidade * Time.deltaTime * Input.GetAxis("Horizontal"); 
        Vector3 vertical = frontal * velocidade * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 movimento = horizontal + vertical;
        transform.position += movimento;
        transform.LookAt(transform.position + movimento);
    }

    private void OnTriggerEnter(Collider other){   
        if (other.gameObject.CompareTag("Respawn")){   
            JogoControlo.instance.perderVida();
            transform.position = jogadorPosicaoOriginal;
            transform.rotation = jogadorOrientacaoOriginal;
        }

        else if (other.gameObject.CompareTag("Teleporte")){   
            for (int i = 0; i < teleportes.Length; i++){  // ver qual é o teleporte e teleportar para o seguinte ou anterior do array de teleportes
                if (i % 2 == 0 && other.gameObject == GameObject.Find($"Teleporte ({i+1})")){
                    if (JogoControlo.instance.nivel % 2 == 0){
                        transform.position = teleportes[i + 1].transform.position + new Vector3(-1, 0, 0);
                    }
                    else{
                        transform.position = teleportes[i + 1].transform.position + new Vector3(0, 0, -1);
                    }
                    break;
                }
                else if (i % 2 != 0 && other.gameObject == GameObject.Find($"Teleporte ({i+1})")) {
                    if (JogoControlo.instance.nivel % 2 == 0){
                        transform.position = teleportes[i - 1].transform.position + new Vector3(1, 0, 0);
                    }
                    else {
                        transform.position = teleportes[i - 1].transform.position + new Vector3(0, 0, 1);
                    }
                    break;
                }
            }
            fumacaTeleporte.Play();
            AudioSource.PlayClipAtPoint(TeleporteSom, transform.position);
        }

        else if(other.gameObject.CompareTag("Coletavel")){
            Debug.Log("Entrou 1");
            if (other.transform.parent.tag == "Azuis"){
                Debug.Log("Entrou 2");
                if (coleteveisAzuis == 0){
                    teleportes[0].SetActive(true);
                    coleteveisAzuis++;
                }
                else if (coleteveisAzuis == 1){
                    teleportes[6].SetActive(true);
                    coleteveisAzuis++;
                }
                else{
                    teleportes[10].SetActive(true);
                    teleportes[13].SetActive(true);
                    coleteveisAzuis++;
                }
            }
            else if (other.transform.parent.tag == "Verdes"){
                if (coleteveisVerdes == 0){
                    teleportes[3].SetActive(true);
                    coleteveisVerdes++;
                }
                else{
                    teleportes[5].SetActive(true);
                    coleteveisVerdes++;
                }
            }
            else if (other.transform.parent.tag == "Vermelhos"){
                teleportes[9].SetActive(true);
                coleteveisVermelhos++;
            }

            // Inspirado neste video -> https://www.youtube.com/watch?v=pa6yUuPZdrE
            AudioSource.PlayClipAtPoint(coletavelSom, other.transform.position);
            other.gameObject.SetActive(false);
        }

        else if(other.gameObject.CompareTag("CheckPoint")){   
            JogoControlo.instance.nivel++;
            AtualizarSpawn();
            other.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter (Collision other){
        if (other.gameObject.CompareTag("Obstaculo") || other.gameObject.CompareTag("Inimigo")){   
            JogoControlo.instance.perderVida();
            transform.position = jogadorPosicaoOriginal;
            transform.rotation = jogadorOrientacaoOriginal;
        }
    }

    private void AtualizarSpawn (){
        jogadorPosicaoOriginal = JogoControlo.instance.Spawns[JogoControlo.instance.nivel - 1].position;
    }
}