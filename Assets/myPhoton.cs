using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class myPhoton : MonoBehaviour
{
    PhotonView PV;
    DroneMovement DM;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        DM = GetComponent<DroneMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
