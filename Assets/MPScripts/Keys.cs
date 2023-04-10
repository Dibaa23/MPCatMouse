using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Keys : MonoBehaviour
{
    public GameObject manager;
    public TMP_Text keytxt;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Spawner");
        keytxt = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = manager.GetComponent<Spawner>().currPlayer;
        keytxt.text = "×" + movement.keys.ToString("0");
        if (!player.GetComponent<health>().alive)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-780f, -579f);
        }
        else
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-80f, -275f);
        }
    }
}
