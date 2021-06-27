using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneGunScript : MonoBehaviour
{
    public Transform gunTransform;
    public GameObject bulletPrefab;
    public float fireRate = 6f;
    private float waitTillNextFire = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootingBullets();
    }

    private  void ShootingBullets()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if(waitTillNextFire <= 0)
            {
                Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
                waitTillNextFire = 1f;
            }
        }
        waitTillNextFire -= fireRate * Time.deltaTime;
    }
}
