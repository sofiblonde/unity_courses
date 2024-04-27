using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.WSA;

public class Rocket : MonoBehaviour
{
    [SerializeField] float rotSpeed = 100f;
    [SerializeField] float flySpeed = 100f;
    [SerializeField] AudioClip flySound;
    [SerializeField] AudioClip boomSound;
    [SerializeField] AudioClip finishSound;
    [SerializeField] ParticleSystem flyParticles;
    [SerializeField] ParticleSystem boomParticles;
    [SerializeField] ParticleSystem finishParticles;

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
                //можно например сюда сделать эффект для приземления, и может быть несколько платформ, например, сохранения. 
                break;
            case "Finish":
                Finish();
                break;
            case "Battery":
                print("Energy");
                break;
            default:
                Lose();
                break;
        } 
    }


     void Finish () 
    {
        state = State.NextLVL;
        audioSource.Stop();
        audioSource.PlayOneShot(finishSound);
        finishParticles.Play();
        Invoke("LoadNextLevel", 2f);
    }


    void Lose()
    {
        state = State.Dead;
        audioSource.Stop();
        audioSource.PlayOneShot(boomSound);
        boomParticles.Play();
        Invoke("LoadFirstLVL", 2f);
    }

    void LoadNextLVL () //finish
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentLevelIndex + 1;
        
        if(nextLevelIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextLevelIndex = 0;
        }

        SceneManager.LoadScene(nextLevelIndex);
    }

    void LoadFirstLVL ()  //lose
    {
        SceneManager.LoadScene(0);
    }


    void Launch()
    {
        if(Input.GetKey(KeyCode.W))
        {
                rigidBody.AddRelativeForce(Vector3.up * flySpeed * Time.deltaTime);

                if(!audioSource.isPlaying) 
                audioSource.PlayOneShot(flySound);
                flyParticles.Play();
        }
        else 
        { 
            flyParticles.Stop();
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
