using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Rocket : MonoBehaviour
{

    Rigidbody rigidBody;
    AudioSource audioSource;

    // Start is called before the first frame update
    // ����������� ��� ������
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    //����������� ���������
    void Update()
    {
        Launch();
        Rotation();
    }

    private void Launch()
    {
               if(Input.GetKey(KeyCode.Space))
        {
            //print("������ ������");

            rigidBody.AddRelativeForce(Vector3.up);

            if(!audioSource.isPlaying) 
                audioSource.Play();
        }
        else 
        { 
            audioSource.Pause();
        }  
    }

    void Rotation() 
    {


        if(Input.GetKey(KeyCode.A)) 
        {
            //print("������� �����");
            transform.Rotate(Vector3.forward);
        }

        else if(Input.GetKey(KeyCode.D)) 
        {
            //print("������� �����");
            transform.Rotate(-Vector3.forward);
        }
    }
}
