using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculos : MonoBehaviour
{   
    private int sentido = 1; // Lado para qual o obstaculo vai se movimentar

    void Start(){
        
    }

    void Update(){   
        transform.Rotate(new Vector3(0, 0, 50 * sentido) * Time.deltaTime);
        if (transform.transform.eulerAngles.z >= 50 && transform.transform.eulerAngles.z <= 310){ //trocar o sentido da rotação do obstaculo
            sentido *= -1;
        }
    }
}
