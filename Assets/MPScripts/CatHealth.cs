using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class CatHealth : MonoBehaviourPunCallbacks
{
    public float HP;
    public GameObject boom;
    public Image healthBarimg;
    PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        HP = 1f;
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0f)
        {
            GameObject clone2 = Instantiate(boom, transform.position, Quaternion.identity);
            Destroy(clone2.gameObject, 0.5f);
            clone2.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
            Destroy(gameObject);   
        }
        Debug.Log(HP);
        HealthFill();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bot")
        {
            HP -= 0.025f;
        }

        if (col.gameObject.tag == "Mouse")
        {
            HP -= 0.05f;
        }
    }

    public void HealthFill()
    {
        healthBarimg.fillAmount = HP;
    }
}
