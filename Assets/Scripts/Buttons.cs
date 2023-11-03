using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject StartScreen;
    public AudioSource BG;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        StartScreen.SetActive(true);
        //Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTheGame()
    {
        StartScreen.SetActive(false);
        Time.timeScale = 1f;
        BG.Play();
        //Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void EndTheGame()
    {
        Application.Quit();
    }

    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
