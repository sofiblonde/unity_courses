using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.WSA;

public class Rocket : MonoBehaviour
{
    [SerializeField] float rotSpeed = 100f;
    [SerializeField] float flySpeed = 100f;

    Rigidbody rigidBody;
    AudioSource audioSource;

    enum State {Playing, Dead, NextLVL};
    State state = State.Playing;

    // Start is called before the first frame update
    // выполняется при старте
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    //выполняется покадрово
    void Update()
    {
        if (state == State.Playing) { 
        Launch();
        Rotation();
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (state != State.Playing)
        {
            return;
        }


        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("OK");
                break;
            case "Finish":
                state = State.NextLVL;
                Invoke("LoadNextLevel", 2f);
                break;
            case "Battery":
                print("Energy");
                break;
            default:
                state = State.Dead;
                Invoke("LoadFirstLVL", 2f);
                break;
        } 
    }


    void LoadNextLVL () //finish
    {
        SceneManager.LoadScene(1);
    }

    void LoadFirstLVL ()  //lose
    {
        SceneManager.LoadScene(0);
    }


    void Launch()
    {
               if(Input.GetKey(KeyCode.Space))
        {
            //print("зажали пробел");

            rigidBody.AddRelativeForce(Vector3.up * flySpeed);

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
        float rotationSpeed = rotSpeed * Time.deltaTime;


        rigidBody.freezeRotation = true;

        if(Input.GetKey(KeyCode.A)) 
        {
            //print("поворот влево");
            transform.Rotate(Vector3.forward * rotationSpeed);
        }

        else if(Input.GetKey(KeyCode.D)) 
        {
            //print("поворот влево");
            transform.Rotate(-Vector3.forward * rotationSpeed);
        }
        rigidBody.freezeRotation = false;
    }
}
