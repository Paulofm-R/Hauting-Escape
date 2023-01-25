using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        
    }

    // O coletevel fica a rodar sobre o seu proprio eixo
    void Update(){
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
