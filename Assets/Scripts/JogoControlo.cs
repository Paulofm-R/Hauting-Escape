using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JogoControlo : MonoBehaviour
{    
    [SerializeField] ParticleSystem fumaca;
    [SerializeField] Text VidasTexto;
    [SerializeField] GameObject camara1;
    [SerializeField] GameObject camara2;
    [SerializeField] GameObject GameOverText;
    
    public AudioClip morteSom;
    public GameObject[] CheckPoints = new GameObject[1];  // todos os CheckPoints do jogo
    public Transform[] Spawns = new Transform[2];  // todos os Spawns do jogo
    public static JogoControlo instance;
    public int nivel = 1;
    public int vidas = 3;

    private bool camara1Ativa = true;
    private bool camara2Ativa = false;


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
        fumaca.Stop();
        VidasTexto.text = "Vidas: " + vidas.ToString();

    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Q)){
            trocarCamara();
        }
    }

    public void perderVida(){
        vidas--;
        VidasTexto.text = "Vidas: " + vidas.ToString();

        if (vidas <= 0){
            gameOver();
        }
        else{
            // Inspirado neste video -> https://www.youtube.com/watch?v=BXh6LC1H5S0
            fumaca.Play();

            AudioSource.PlayClipAtPoint(morteSom, Jogador.instance.transform.position);
        }
    }

    public void gameOver(){
        GameOverText.SetActive(true);
        Time.timeScale = 0f;
    }

    private void trocarCamara(){
        camara1Ativa = !camara1Ativa;
        camara2Ativa = !camara2Ativa;

        camara1.SetActive(camara1Ativa);
        camara2.SetActive(camara2Ativa);
    }
}