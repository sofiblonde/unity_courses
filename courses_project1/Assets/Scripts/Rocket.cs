using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // Start is called before the first frame update
    // ����������� ��� ������
    void Start()
    {
        
    }

    // Update is called once per frame
    //����������� ��� �����������
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
            //print("������� �����");
        }

        else if(Input.GetKey(KeyCode.D)) 
        {
            //print("������� �����");
        }
    }
}
