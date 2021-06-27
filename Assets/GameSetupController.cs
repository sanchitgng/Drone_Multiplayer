using UnityEngine;
using Photon.Pun;
using System.IO;
using System;

public class GameSetupController : MonoBehaviour
{
    //static int yPOS = UnityEngine.Random.Range(3, 11);

    Vector3 pos = new Vector3(197.4f, 3.14f, 246.3f);

    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        Debug.Log("Creating player");
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Drone_red"), pos , Quaternion.identity);
    }

}
