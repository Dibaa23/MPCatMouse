using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class CatMove : MonoBehaviourPunCallbacks
{
    public GameObject boom;
    public Rigidbody2D rb2D;
    public TMP_Text countdownDisplay;
    public bool ready;
    public Camera cam;
    private float speed;
    PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        countdownDisplay = GameObject.Find("CountDown").GetComponent<TMPro.TextMeshProUGUI>();
        ready = false;
        view = GetComponent<PhotonView>();
        cam.orthographicSize = 15f;
        speed = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<CathyHealth>().alive && countdownDisplay.text == "GO!" && view.IsMine)
        {
            ready = true;
            rotation();
            thrust();
        }
    }


    public void rotation()
    {
        Vector3 catPos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 5), catPos - transform.position);
    }


    public void thrust()
    {
        rb2D.AddForce(transform.up * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Coin")
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Cheese")
        {
            GameObject clone2 = Instantiate(boom, col.gameObject.transform.position, Quaternion.identity);
            clone2.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f);
            Destroy(clone2.gameObject, 0.5f);
            Destroy(col.gameObject);

        }
    }
}
