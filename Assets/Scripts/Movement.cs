using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;

    [SerializeField] ParticleSystem mainEngineParticles;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        ProcessRotation();
        ProcessThrust();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Thrusters activated");
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

            if(!mainEngineParticles.isPlaying)
            {
                mainEngineParticles.Play();
            }
           
        }
        else
        {
            mainEngineParticles.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(rotationThrust);
            if(!mainEngineParticles.isPlaying) 
            {
                mainEngineParticles.Play();
            }
            Debug.Log("Turning Left");
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            ApplyRotation(-rotationThrust);
            if (!mainEngineParticles.isPlaying)
            {
                mainEngineParticles.Play();
            }
                Debug.Log("Turning Right");
        }
        else
        {
           mainEngineParticles.Stop();
           
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
    }
}
