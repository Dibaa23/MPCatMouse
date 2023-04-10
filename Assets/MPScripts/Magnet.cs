using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public GameObject manager;
    public float speed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = manager.GetComponent<Spawner>().currPlayer;
        if (Vector2.Distance(player.transform.position, transform.position) <= 5f)  
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
        }
    }
}
