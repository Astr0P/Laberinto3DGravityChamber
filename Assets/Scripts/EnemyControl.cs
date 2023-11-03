using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public Transform Player;
    float MoveSpeed = 8.5f;

    // Start is called before the first frame update
    void Awake()
    {

    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var step = MoveSpeed * Time.deltaTime;
        transform.LookAt(Player);
        transform.position = Vector3.MoveTowards(transform.position, Player.position, step);
    }
}
