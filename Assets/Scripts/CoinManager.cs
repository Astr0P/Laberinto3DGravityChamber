using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public TMP_Text coinText;
    public TMP_Text finalTimeText;
    public float time = 0;
    public GameObject panel;
    public GameObject UI;
    public Transform NoGravity;
    public AudioSource BG;
    public int currentCoins = 0;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        coinText.text = "Monedas: " + currentCoins.ToString();
        panel.SetActive(false);
        UI.SetActive(true);
        //NoGravity.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (currentCoins == 4)
        {
            //NoGravity.SetActive(true);
            NoGravity.transform.position = new Vector3(31.58491f, 23f, 311.2008f);
        }
        
        if (currentCoins == 8)
        {
            //Cursor.lockState = CursorLockMode.None;
            panel.SetActive(true);
            UI.SetActive(false);
            finalTimeText.text = "Conseguiste todas las monedas en " + ((int)time).ToString() + " segundos";
            Time.timeScale = 0f;
            BG.Stop();
        }
    }
    

    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        coinText.text = "Monedas: " + currentCoins.ToString();
    }
}
