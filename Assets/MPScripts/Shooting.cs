using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Shooting : MonoBehaviourPunCallbacks
{
    public Transform ball;
    public GameObject bullet;
    public bool ready = true;
    PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && view.IsMine)
        {
            shoot();
        }
    }

    void shoot()
    {
        if (!ready)
        {
            return;
        }
        StartCoroutine(CD());
    }

    public IEnumerator CD()
    {
        ready = false;
        GameObject clone = (GameObject)Instantiate(bullet, ball.position, ball.rotation);
        yield return new WaitForSeconds(0.25f);
        ready = true;
        Destroy(clone, 3f);
    }
}