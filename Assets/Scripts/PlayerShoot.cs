using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float maxVerticalSpeed;
    public GameObject bullets;
    Transform frontalShoot;
    Transform sideShoot;
    Transform sideShoot2;
    Transform sideShoot3;
    private void Awake()
    {
         
        frontalShoot = transform.GetChild(0).transform;
        sideShoot = transform.GetChild(1).transform;
        sideShoot2 = transform.GetChild(2).transform;
        sideShoot3 = transform.GetChild(3).transform;
         
    }
    private void Update()
    {
        Shoting();
    }
    public void Shoting() 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject a = Instantiate(bullets, frontalShoot.position, frontalShoot.rotation);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject a = Instantiate(bullets, sideShoot.position, sideShoot.rotation);
            GameObject b = Instantiate(bullets, sideShoot2.position, sideShoot2.rotation);
            GameObject c = Instantiate(bullets, sideShoot3.position, sideShoot3.rotation);
        }
    }

}
