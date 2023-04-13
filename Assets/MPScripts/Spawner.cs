using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawner : MonoBehaviourPunCallbacks
{
    public GameObject currPlayer;
    public GameObject botPrefab;
    public GameObject cheesePrefab;
    public GameObject catPrefab;
    public GameObject coinPrefab;
    public GameObject[] playerPrefabs;
    public GameObject[] forestPrefabs;
    public List<GameObject> catPrefabs;
    public float numBots;
    public float forestObstacles;
    public float numCheese;
    public float maxCheese = 5f;
    public float numCoins;
    public float maxCoins = 10f;
    PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        currPlayer = playerPrefabs[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
        currPlayer.GetComponentInChildren<Camera>().enabled = true;
        PhotonNetwork.Instantiate(currPlayer.name, transform.position, Quaternion.identity);
        catPrefab = GameObject.FindGameObjectWithTag("Cat"); 
        numCheese = 0f;
        numCoins = 0f;
        spawnBots();
        spawnForestObstacles();
    }

    // Update is called once per frame
    void Update()
    {
        spawnCheese();
        spawnCoins();
    }


    void spawnBots() {
        for (int i = 0; i < numBots; i++)
        {
            GameObject botClone = PhotonNetwork.Instantiate(botPrefab.name, new Vector2(Random.Range(-50f, 50f), Random.Range(-33f, 33f)), Quaternion.identity);
            foreach (GameObject catPrefab in catPrefabs)
            {
                catPrefab.GetComponent<CatBot>().mice.Add(botClone);
                botClone.GetComponent<MiceAI>().Cat.Add(catPrefab);
            }
            //catPrefab.GetComponent<CatBot>().mice.Add(PhotonNetwork.Instantiate(botPrefab.name, new Vector2(Random.Range(-50f, 50f), Random.Range(-33f, 33f)), Quaternion.identity));
        }
    }

    void spawnCheese() {
        if ((numCheese < maxCheese) && (numCheese >= 0)) {
            PhotonNetwork.Instantiate(cheesePrefab.name, new Vector2(Random.Range(-50f, 50f), Random.Range(-33f, 33f)), Quaternion.identity);
            numCheese++;
        }
    }

    void spawnCoins()
    {
        if ((numCoins < maxCoins) && (numCoins >= 0))
        {
            PhotonNetwork.Instantiate(coinPrefab.name, new Vector2(Random.Range(-50f, 50f), Random.Range(-33f, 33f)), Quaternion.identity);
            numCoins++;
        }
    }

    void spawnForestObstacles()
    {
        for (int i = 0; i < forestObstacles; i++)
        {
            PhotonNetwork.Instantiate(forestPrefabs[Random.Range(0, 13)].name, new Vector2(Random.Range(-50f, 50f), Random.Range(-33f, 33f)), Quaternion.identity);
        }
    }
}
