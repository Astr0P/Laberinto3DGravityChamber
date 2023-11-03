using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCubo : MonoBehaviour
{
    Rigidbody fisicas;
    public float movX, movZ;
    float speed = 50f;
    bool quiereSaltar = false;

    // Start is called before the first frame update
    void Start()
    {
        fisicas = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            quiereSaltar = true;
        }
    }

    private void FixedUpdate() 
    { 
        Vector3 nuevaVelocidad = new Vector3(movX * speed,fisicas.velocity.y ,movZ * speed);
        fisicas.velocity = nuevaVelocidad;

        if (quiereSaltar)
        {
            fisicas.AddForce(Vector3.up * 100 ,ForceMode.Impulse );
            quiereSaltar = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}
