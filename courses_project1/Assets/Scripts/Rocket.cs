using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // Start is called before the first frame update
    // выполняется при старте
    void Start()
    {
        
    }

    // Update is called once per frame
    //выполняется при раскадровке
    void Update()
    {
        ProcessInput(){ }
    }

    void ProcessInput() 
    {
        if(Input.GetKey(KeyCode.Space))
        {

        }

        if(Input.GetKey(KeyCode.A)) 
        {
            //print("поворот влево");
        }

        else if(Input.GetKey(KeyCode.D)) 
        {
            //print("поворот влево");
        }
    }
}
