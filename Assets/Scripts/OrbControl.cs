using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbControl : MonoBehaviour
{
    Rigidbody rb;
    float MoveSpeed = 10f;
    float Jump = 8f;
    bool puedeSaltar = true;
    bool gravity = true;
    public GameObject GameOver;
    public Transform Camera;
    public AudioSource BG;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float HorInput = Input.GetAxis("Horizontal") * MoveSpeed;
        float VerInput = Input.GetAxis("Vertical") * MoveSpeed;

        rb.velocity = new Vector3(HorInput, rb.velocity.y, VerInput);

        if (Input.GetButtonDown("Jump") && puedeSaltar)
        {
            rb.velocity = new Vector3(rb.velocity.x, Jump, rb.velocity.z);
            puedeSaltar = false;
        }
        if (Input.GetKeyDown("g") && gravity)
        {
            rb.useGravity = false;
            gravity = false;
        }
        else if (Input.GetKeyDown("g") && gravity == false)
        {
            rb.useGravity = true;
            gravity = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            puedeSaltar = true;
        }
        if (collision.gameObject.name == "Enemy" || collision.gameObject.tag == "Void")
        {    
            GameOver.SetActive(true);
            Time.timeScale = 0f;
            BG.Stop();
            //Cursor.lockState = CursorLockMode.None;
        }
    }
    private void OnTriggerEnter(Collider Collision)
    {
        if (Collision.gameObject.name == "GravityChamber")
        {
            rb.useGravity = false;
        }
    }
    private void OnTriggerExit(Collider Collision)
    {
        if (Collision.gameObject.name == "GravityChamber")
        {
            rb.useGravity = true;
        }
    }
    
}
