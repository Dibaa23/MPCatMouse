using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class playerName : MonoBehaviourPunCallbacks
{
    public TMP_Text Name;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Name.text = PhotonNetwork.NickName;
    }
}
